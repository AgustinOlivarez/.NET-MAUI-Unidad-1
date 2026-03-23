using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MauiApp1.Models;

namespace MauiApp1.ViewModels
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        private Student _student;
        private string _statusMessage;

        // Propiedades enlazadas a la vista
        public string Name
        {
            get => _student.Name;
            set { if (_student.Name != value) { _student.Name = value; OnPropertyChanged(); } }
        }

        public int Age
        {
            get => _student.Age;
            set { if (_student.Age != value) { _student.Age = value; OnPropertyChanged(); } }
        }

        public string Description
        {
            get => _student.Description;
            set { if (_student.Description != value) { _student.Description = value; OnPropertyChanged(); } }
        }

        public string ProfileImageUrl
        {
            get => _student.ProfileImageUrl;
            set { if (_student.ProfileImageUrl != value) { _student.ProfileImageUrl = value; OnPropertyChanged(); } }
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set { if (_statusMessage != value) { _statusMessage = value; OnPropertyChanged(); } }
        }

        // El comando para el botón
        public ICommand SaveCommand { get; }

        public ProfileViewModel()
        {
            // Inicializamos el modelo con datos por defecto
            _student = new Student
            {
                Name = "Agustin Olivarez",
                Age = 26,
                Description = "Estudiante de Programción en sistemas.",
                ProfileImageUrl = "agus.png"
            };

            SaveCommand = new Command(SaveProfile);
        }

        private void SaveProfile()
        {
            // Validación básica
            if (string.IsNullOrWhiteSpace(Name))
            {
                StatusMessage = "El nombre no puede estar vacío.";
                return;
            }

            // Aquí simularíamos guardar en una base de datos
            StatusMessage = $"¡Perfil de {Name} guardado con éxito!";
        }

        // Implementación de INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
