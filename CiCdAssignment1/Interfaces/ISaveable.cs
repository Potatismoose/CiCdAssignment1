using System.Collections.Generic;

namespace CiCdAssignment1.Interfaces
{
    public interface ISaveable
    {
        public string Email { get; set; }
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int Salary { get; set; }
        public string CompanyRole();

        public int UserSalary();

        public List<ISaveable> ViewActiveUsersAndPasswords();
    }
}