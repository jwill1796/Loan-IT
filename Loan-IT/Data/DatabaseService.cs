using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loan_IT.Models;


namespace Loan_IT.Data
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
        }

        public async Task InitializeAsync()
        {
            await _database.CreateTableAsync<Users>();
            await _database.CreateTableAsync<MortgageDetails>();
            await _database.CreateTableAsync<UserInfo>();
            await _database.CreateTableAsync<UserInfo>();
        }

        public Task<int> RegisterUser(Users user)
        {
            return _database.InsertAsync(user);
        }

        public Task<Users> GetUserByUsername(string username)
        {
            return _database.Table<Users>().Where(u => u.Username == username).FirstOrDefaultAsync();
        }

        public Task<int> SaveUserInfo(UserInfo userinfo)
        {
            return _database.InsertAsync(userinfo);
        }
        
        public Task<UserInfo> GetUserInfo(int userId)
        {
            return _database.Table<UserInfo>().Where(u => u.UserId == userId).FirstOrDefaultAsync();
        }

        public Task<int> SaveMortgageDetails(MortgageDetails mortgage)
        {
            return _database.InsertAsync(mortgage);
        }

        public Task<List<MortgageDetails>> GetMortgageDetails(int userId)
        {
            return _database.Table<MortgageDetails>().Where(m => m.UserId == userId).ToListAsync();
        }

        public async Task<MortgageDetails> GetLatestMortgage(int userId)
        {
            return await _database.Table<MortgageDetails>()
                .Where(m => m.UserId == userId)
                .OrderByDescending(m => m.Id)
                .FirstOrDefaultAsync();
        }
        public async Task<Users> GetLoggedInUser()
        {
            return await _database.Table<Users>().FirstOrDefaultAsync();
        }

        public async Task LogoutUser()
        {
            await _database.DeleteAllAsync<Users>();
        }

    }
}
