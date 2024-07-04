using Practica.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica
{
    public class DatabaseRM
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseRM(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Personaje>().Wait();
        }

        public Task<List<Personaje>> GetCharactersAsync()
        {
            return _database.Table<Personaje>().ToListAsync();
        }

        public Task<int> SaveCharacterAsync(Personaje personaje)
        {
            return _database.InsertAsync(personaje);
        }

        public Task<int> DeleteCharacterAsync(Personaje personaje)
        {
            return _database.DeleteAsync(personaje);
        }

        public Task<int> UpdateCharacterAsync(Personaje personaje)
        {
            return _database.UpdateAsync(personaje);
        }
    }
}
