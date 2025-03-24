using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Loan_IT_Hybrid.Models
{
    public class Users
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100), Unique]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Username { get; set; }

        public string PasswordHash { get; set; }

    }
}
