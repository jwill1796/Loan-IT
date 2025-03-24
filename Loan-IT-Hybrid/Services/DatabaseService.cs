using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Loan_IT_Hybrid.Models;

namespace Loan_IT_Hybrid.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _db;

        public DatabaseService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Users>().Wait();
        }

        public Task<int> RegisterUserAsync(Users user)
        {
            return _db.InsertAsync(user);
        }

        public Task<Users> GetUserByEmailAsync(string email)
        {
            return _db.Table<Users>().Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public Task<List<Users>> GetAllUsersAsync()
        {
            return _db.Table<Users>().ToListAsync();
        }

        public Task<Users> LoginUserAsync(string email)
        {
            return _db.Table<Users>().Where(u => u.Email == email).FirstOrDefaultAsync();
        }
    }
}
