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
    public class EmployeeService : IEmployeeService
    {
        private readonly WorkPlaceContext _context;
        private readonly ResponseHandler _responseHandler;
        private readonly IMapper _mapper;
        public EmployeeService(WorkPlaceContext context, ResponseHandler responseHandler, IMapper mapper)
        {
            _context = context;
            _responseHandler = responseHandler;
            _mapper = mapper;
        }
        public async Task<ResponseObject<IdDto<long>>> CreateEmployee(CreateEmployeeRequest createEmployeeRequest)
        {
            Employee employeeEntity = new Employee
            {
                FirstName = createEmployeeRequest.FirstName,
                LastName = createEmployeeRequest.LastName,
                Email = createEmployeeRequest.Email,
                PhoneNumber = createEmployeeRequest.PhoneNumber,
            };

            _context.Employees.Add(employeeEntity);
            await _context.SaveChangesAsync();

            return employeeEntity.EmployeeId.GetIdResponse();
        }

        public async Task<ResponseObject<IdDto<long>>> CreateEmployeeLocation(CreateEmployeeLocationRequest createEmployeeLocationRequest)
        {
            ResponseObject<IdDto<long>> result = new();

            if (string.IsNullOrEmpty(createEmployeeLocationRequest.EmployeeId) || !long.TryParse(createEmployeeLocationRequest.EmployeeId, out _))
            {
                _responseHandler.SetErrorCode(result, ErrorCode.InvalidValue);
            }

            long.TryParse(createEmployeeLocationRequest.EmployeeId, out long parsedEmployeeId);
            bool employeeExist = _context.Customers.Any(x => x.CustomerId == parsedEmployeeId);

            if (!employeeExist)
            {
                _responseHandler.SetErrorCode(result, ErrorCode.InvalidValue);
            }

            if (result.HasErrors())
            {
                return result;
            }

            var longIdsLocations = new List<long>(createEmployeeLocationRequest.Locationids.Count);

            foreach (var s in createEmployeeLocationRequest.Locationids)
            {
                if (int.TryParse(s, out int parsedData))
                    longIdsLocations.Add(parsedData);
            }

            var locations = await _context.BusinessLocations.Where(x => longIdsLocations.Contains(x.BusinessLocationId)).ToListAsync();

            var employee = await _context.Employees.Where(x => x.EmployeeId == parsedEmployeeId).FirstOrDefaultAsync();
            

            employee.BusinessLocations = locations;
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();

            return employee.EmployeeId.GetIdResponse();
        }
    }
}
