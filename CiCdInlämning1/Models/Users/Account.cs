using CiCdInlämning1.Interfaces;
using System;

namespace CiCdInlämning1.Models.Users
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
    }
}
