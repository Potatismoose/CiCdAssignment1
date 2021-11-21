﻿using CiCdAssignment1.Interfaces;
using System;

namespace CiCdAssignment1.Models.Users
{
    [Serializable]
    public class User : Account, ISaveable
    {
        public User(int id, string name, string password, string email, int salary, string role) : base(id, name, password, email, salary, role)
        {
        }
    }
}