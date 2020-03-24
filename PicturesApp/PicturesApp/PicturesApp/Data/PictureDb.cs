using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PicturesApp.Data;
using PicturesApp.Models;
using SQLite;

namespace MvvmTutorial.Data
{
    public class PictureDb
    {
        SQLiteAsyncConnection _database;

        public PictureDb(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ImageData>().Wait();
        }

        public Task<List<ImageData>> GetPicturesAsync()
        {
            return _database.Table<ImageData>().ToListAsync();
        }

        public Task<ImageData> GetPictureAsync(int id)
        {
            return _database.Table<ImageData>()
                .Where(x => x.ID == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SavePicturesAsync(ImageData picture)
        {
            if (picture.ID != 0)
            {
                return _database.UpdateAsync(picture);
            }
            else
            {
                return _database.InsertAsync(picture);
            }
        }

        public Task<int> DeletePictureAsync(ImageData picture)
        {
            return _database.DeleteAsync(picture);
        }
    }
}