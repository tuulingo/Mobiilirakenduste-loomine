using PicturesApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PicturesApp.Data
{
    public class UserDb
    {
        SQLiteAsyncConnection _database;

        public UserDb(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<UserModel>().Wait();
        }
        public async Task<List<UserModel>> GetUsersAsync()
        {
            return await _database.Table<UserModel>().ToListAsync();
        }
        public async Task<UserModel> GetSpecificUserAsync(int id)
        {
            return await _database.Table<UserModel>().FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<int> DeleteUserAsync(int id)
        {
           return await _database.DeleteAsync<UserModel>(id);
        }
        public async Task<string> AddUserAsync(UserModel user)
        {
            var data = _database.Table<UserModel>();
            var d1 = await data.Where(x => x.Name == user.Name && x.Email == user.Email).FirstOrDefaultAsync();
            if (d1 == null)
            {
                await _database.InsertAsync(user);
                return "Sucessfully Added";
            }
            else
                return "Mail already exists";
        }
        public bool LoginValidate(string userName1, string pwd1)
        {
            var data = _database.Table<UserModel>();
            var d1 = data.Where(x => x.Name == userName1 && x.Password == pwd1).FirstOrDefaultAsync();
            if (d1 != null)
            {
                return true;
            }
            else
                return false;
        }

        public Task<int> SaveUserAsync(UserModel user)
        {
            if (user.Id != 0)
            {
                return _database.UpdateAsync(user);
            }
            else
                return _database.InsertAsync(user);
        }
    }
}
