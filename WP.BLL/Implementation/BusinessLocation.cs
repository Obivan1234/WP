using Microsoft.EntityFrameworkCore;
using WP.BLL.Interfaces;
using WP.Common.Enums;
using WP.Common;
using WP.Common.Models;
using AutoMapper;
using WP.DAL.Context;
using WP.DAL.Entities;
using WP.Common.Managers;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.IdentityModel.Tokens;

namespace WP.BLL.Implementation
{
    public class BusinessLocationService : IBusinessLocationService
    {
        private readonly WorkPlaceContext _context;
        private readonly ResponseHandler _responseHandler;
        private readonly IMapper _mapper;
        public BusinessLocationService(WorkPlaceContext context, ResponseHandler responseHandler, IMapper mapper)
        {
            _context = context;
            _responseHandler = responseHandler;
            _mapper = mapper;
        }

        public async Task<ResponseObject<IdDto<long>>> CreateBusinessLocation(string customerId, BusinessLocationPostDto businessLocationPostDto)
        {
            ResponseObject<IdDto<long>> result = new();

            #region Validation

            if (string.IsNullOrEmpty(customerId) || !long.TryParse(customerId, out _))
            {
                _responseHandler.SetErrorCode(result, ErrorCode.InvalidValue);
            }

            long.TryParse(customerId, out long parsedCustomerId);
            bool vehicleExist = await _context.Customers
                .AnyAsync(x => x.CustomerId == parsedCustomerId);

            if (!vehicleExist)
            {
                _responseHandler.SetErrorCode(result, ErrorCode.InvalidValue);
            }

            if (result.HasErrors())
            {
                return result;
            }

            #endregion

            BusinessLocation businessLocation = new BusinessLocation
            {
                Name = businessLocationPostDto.Name,
                Address = businessLocationPostDto.Address,
                TelephoneNumber = businessLocationPostDto.TelephoneNumber,
                CustomerId = parsedCustomerId,
            };

            _context.BusinessLocations.Add(businessLocation);
            await _context.SaveChangesAsync();

            return businessLocation.BusinessLocationId.GetIdResponse();
        }

        public async Task<ResponseObject<IdDto<long>>> UpdateLocationAsync(string locationId, JsonPatchDocument<LocationPatchDto> locationPatch)
        {
            ResponseObject<IdDto<long>> result = new();


            if (string.IsNullOrEmpty(locationId) || !long.TryParse(locationId, out _))
            {
                _responseHandler.SetErrorCode(result, ErrorCode.InvalidValue);
            }

            long.TryParse(locationId, out long parsedLocationId);
            bool locationExist = _context.BusinessLocations.Any(x => x.BusinessLocationId == parsedLocationId);

            if (!locationExist)
            {
                _responseHandler.SetErrorCode(result, ErrorCode.InvalidValue);
            }

            if (result.HasErrors())
            {
                return result;
            }

            BusinessLocation location = await _context.BusinessLocations
                    .Where(x => x.BusinessLocationId == parsedLocationId)
                    .AsTracking()
                    .FirstOrDefaultAsync();

            LocationPatchDto locationPatchDto = _mapper.Map<LocationPatchDto>(location);
            locationPatch.ApplyTo(locationPatchDto);

            location.Name = locationPatchDto.Name;
            location.Address = locationPatchDto.Address;
            location.TelephoneNumber = locationPatchDto.TelephoneNumber;
            location.CustomerId = locationPatchDto.CustomerId;

            await _context.SaveChangesAsync();
            return location.BusinessLocationId.GetIdResponse();
        }
    }
}
