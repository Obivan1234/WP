
namespace WP.Common.Models
{
    public class CustomerDetailsDto
    {
        public string Name { get; set; }
        public List<EmployeeDto> Employees { get; set; }
    }
    public class EmployeeDto
    {
        public long EmployeeId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
