using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmTutorial.Models;
using SQLite;

namespace MvvmTutorial.Data
{
    public class PictureDb
    {
        SQLiteAsyncConnection _database;

        public PictureDb(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<PictureModel>().Wait();
        }

        public Task<List<PictureModel>> GetPicturesAsync()
        {
            return _database.Table<PictureModel>().ToListAsync();
        }

        public Task<PictureModel> GetPictureAsync(int id)
        {
            return _database.Table<PictureModel>()
                .Where(x => x.ID == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SavePicturesAsync(PictureModel picture)
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

        public Task<int> DeleteNoteAsync(PictureModel picture)
        {
            return _database.DeleteAsync(picture);
        }
    }
}