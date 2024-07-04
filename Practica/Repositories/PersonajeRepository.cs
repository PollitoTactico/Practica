using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Practica.Models;

namespace Practica.Repositories
{
    internal class PersonajeRepository
    {
        private string _dbPath;
        private SQLiteConnection conn;

        public string StatusMessage { get; set; }

        private void Init()
        {
            if (conn == null)
            {
                conn = new SQLiteConnection(_dbPath);
                conn.CreateTable<Personaje>();
            }
        }

        public PersonajeRepository(string dbPath)
        {
            _dbPath = dbPath;
            Init();
        }

        public void AddNewPersonaje(Personaje personaje)
        {
            try
            {
                int result = conn.Insert(personaje);
                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, personaje.Name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", personaje.Name, ex.Message);
            }
        }

        public void UpdatePersonaje(Personaje personaje)
        {
            try
            {
                int result = conn.Update(personaje);
                StatusMessage = string.Format("{0} record(s) updated [Name: {1})", result, personaje.Name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to update {0}. Error: {1}", personaje.Name, ex.Message);
            }
        }

        public List<Personaje> GetAllPersonajes()
        {
            try
            {
                return conn.Table<Personaje>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                return new List<Personaje>();
            }
        }

        public void DeletePersonaje(int id)
        {
            try
            {
                int result = conn.Delete<Personaje>(id);
                StatusMessage = string.Format("{0} record(s) deleted [Id: {1})", result, id);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete {0}. Error: {1}", id, ex.Message);
            }
        }
    }
}

