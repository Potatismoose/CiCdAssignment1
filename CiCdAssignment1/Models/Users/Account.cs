using CiCdAssignment1.Interfaces;
using CiCdAssignment1.Utilities;
using System;
using System.Collections.Generic;

namespace CiCdAssignment1.Models.Users
{
    [Serializable]
    public abstract class Account : ISaveable
    {
        //Main parent.

        public Account(int id, string name, string password, string email, int salary, string role, bool isAdmin = false)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            IsAdmin = isAdmin;
            Salary = salary;
            Role = role;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public int Salary { get; set; }
        public string Role { get; set; }

        public override string ToString()
        {
            return ($"{Name}, Har adminbehörighet: {IsAdmin}");
        }

        public int UserSalary()
        {
            return Salary;
        }

        public string CompanyRole()
        {
            return Role;
        }

        public List<ISaveable> ViewActiveUsersAndPasswords()
        {
            return ReadWrite.GetListOfUsers();
        }
    }
}
