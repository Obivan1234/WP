using Microsoft.EntityFrameworkCore;
using WP.BLL.Interfaces;
using WP.Common.Enums;
using WP.Common;
using WP.Common.Models;
using WP.DAL.Context;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using WP.Common.Managers;
using WP.DAL.Entities;

namespace WP.BLL.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly WorkPlaceContext _context;
        private readonly ResponseHandler _responseHandler;
        private readonly IMapper _mapper;
        public CustomerService(WorkPlaceContext context, ResponseHandler responseHandler, IMapper mapper)
        {
            _context = context;
            _responseHandler = responseHandler;
            _mapper = mapper;
        }

        public async Task<ResponseObject<IdDto<long>>> CreateCustomer(string customerName, List<string> eployeesIds)
        {
            ResponseObject<IdDto<long>> result = new();

            if (string.IsNullOrEmpty(customerName))
            {
                _responseHandler.SetErrorCode(result, ErrorCode.InvalidValue);
            }

            if (result.HasErrors())
            {
                return result;
            }

            var longIdsEmployee = new List<long>(eployeesIds.Count);

            foreach (var s in eployeesIds)
            {
                if (int.TryParse(s, out int parsedData))
                    longIdsEmployee.Add(parsedData);
            }

            var employees = await _context.Employees.Where(x => longIdsEmployee.Contains(x.EmployeeId)).ToListAsync();

            Customer customerEntity = new Customer
            {
                Name = customerName,
                Employees = employees
            };

            _context.Customers.Add(customerEntity);
            await _context.SaveChangesAsync();

            return customerEntity.CustomerId.GetIdResponse();
        }

        public async Task<ResponseObject<CustomerDetailsDto>> GetCustomerByIdAsync(string customerId)
        {
            ResponseObject<CustomerDetailsDto> result = new();

            #region Validation

            if (string.IsNullOrEmpty(customerId) || !long.TryParse(customerId, out _))
            {
                _responseHandler.SetErrorCode(result, ErrorCode.InvalidValue);
            }

            long.TryParse(customerId, out long parsedCustomerId);
            bool customerExist = _context.Customers.Any(x => x.CustomerId == parsedCustomerId);


            //try
            //{
            //    var tet1 = _context.Customers.Include(s => s.BusinessLocations).ToList();
            //    var tet2 = _context.Employees.Include(s => s.Customers).ToList();
            //    var tet3 = _context.BusinessLocations.ToList();
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}
           

            if (!customerExist)
            {
                _responseHandler.SetErrorCode(result, ErrorCode.InvalidValue);
            }

            if (result.HasErrors())
            {
                return result;
            }

            #endregion

            CustomerDetailsDto customerDetailsDto = await _context.Customers
            .Include(x => x.Employees)
            .Where(x => x.CustomerId == parsedCustomerId)
            .ProjectTo<CustomerDetailsDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

            return customerDetailsDto.GetResponseObject();
        }
    }
}
