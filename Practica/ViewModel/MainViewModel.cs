using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Practica.Models;
using Practica.Repositories;

namespace Practica.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private PersonajeRepository _repository;
        public ObservableCollection<Personaje> Personajes { get; set; }
        private Personaje _selectedPersonaje;

        public Personaje SelectedPersonaje
        {
            get { return _selectedPersonaje; }
            set { _selectedPersonaje = value; OnPropertyChanged(); }
        }

        public ICommand SavePersonajeCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public MainViewModel()
        {
            string dbPath = GetDatabasePath();
            _repository = new PersonajeRepository("dbPath");
            Personajes = new ObservableCollection<Personaje>(_repository.GetAllPersonajes());

            SavePersonajeCommand = new Command(SavePersonaje);
            EditCommand = new Command(EditPersonaje, CanEditPersonaje);
        }

        private string GetDatabasePath()
        {
            string dbName = "rickandmorty.db3";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(folderPath, dbName);
        }

        private void SavePersonaje(object obj)
        {
            var personaje = obj as Personaje;
            if (personaje != null)
            {
                if (personaje.Id == 0)
                {
                    _repository.AddNewPersonaje(personaje);
                    Personajes.Add(personaje);
                }
                else
                {
                    _repository.UpdatePersonaje(personaje);
                }
            }
        }

        private void EditPersonaje(object obj)
        {
            
        }

        private bool CanEditPersonaje(object arg)
        {
            return SelectedPersonaje != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

