using FluentValidation.Results;
using Newtonsoft.Json;
using System.Resources;
using System;
using System.Text.Json;
using WP.Common.Enums;
using WP.Common.Managers;
using WP.Common.Models;

namespace WP.Common
{
    public class ResponseHandler
    {
        private WPError[] _responses;

        public ResponseHandler()
        {
            PopulateErrorCodes();

        }
        public ResponseObject<TDto> SetErrorCode<TDto>(ResponseObject<TDto> response,
        ErrorCode code) where TDto : class =>
        response.AddErrorCode(GetResponse(code, null, null));

        public async Task<ResponseObject<TDto>> SetErrorCodes<TDto>(ResponseObject<TDto> response,
            ValidationResult validationResult)
            where TDto : class
        {
            if (validationResult.IsValid)
            {
                return response;
            }

            JsonNamingPolicy namingStrategy = JsonNamingPolicy.CamelCase;

            string[] props = Array.Empty<string>();
            #region Filter sensitive properties

            #endregion

            foreach (ValidationFailure error in validationResult.Errors)
            {
                string propertyName = namingStrategy
                    .ConvertName(error.PropertyName)
                    .Split('.')
                    .LastOrDefault()?
                    .Trim('_');


                string attemptedValue = error.AttemptedValue?.ToString()?.StartsWith("System.Collections") == true
                ? string.Empty
                    : error.AttemptedValue?.ToString();

                response.AddErrorCode(GetResponse(ErrorCodeExt.FromString(error.ErrorCode),
                    propertyName,
                    attemptedValue));

            }

            return response;
        }
        private void PopulateErrorCodes()
        {
            try
            {
                string resourcePath = $"{this.GetType().Assembly.GetName().Name}.Resources.errorCodes.json";
                Stream resource = this.GetType().Assembly
                    .GetManifestResourceStream(resourcePath);

                using StreamReader streamReader = new(resource);
                _responses = JsonConvert.DeserializeObject<WPError[]>(streamReader.ReadToEnd());
            }
            catch (Exception e)
            {
                throw new Exception(
                "Error occured when trying to open errorCodes.json, check inner exception.", e);
            }
        }
        private WPError GetResponse(ErrorCode code,
        string property,
        string value)
        {
            WPError err = _responses.SingleOrDefault(x => x.Code == (int)code);
            if (err == null)
            {
                throw new Exception($"Error key unable to find: {code}");
            }

            WPError errorBuilder = new()
            {
                Code = err.Code,
                Message = err.Message
            };

            if (!string.IsNullOrEmpty(property))
            {
                errorBuilder.Message += $"; Property: {property}";
            }

            if (!string.IsNullOrEmpty(value))
            {
                errorBuilder.Message += $"; Value: {value}";
            }

            return errorBuilder;
        }
    }
   
}
