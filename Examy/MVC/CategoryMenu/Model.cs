using Microsoft.Win32;
using Newtonsoft.Json;
using SimulacroOposiciones.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace SimulacroOposiciones.MVC.CategoryMenu
{
    public class Model
    {
        public List<Question> SelectJsonAndLoadList()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Selecciona un archivo JSON",
                Filter = "Archivos JSON (*.json)|*.json",
                Multiselect = false
            };

            bool? result = openFileDialog.ShowDialog();

            if (result != true)
                return null;

            try
            {
                string jsonPath = openFileDialog.FileName;
                string jsonContent = File.ReadAllText(jsonPath);

                List<Question>? items = JsonConvert.DeserializeObject<List<Question>>(jsonContent);

                if (items == null)
                {
                    MessageBox.Show("El archivo JSON está vacío o no tiene el formato esperado.",
                                    "Error",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Warning);
                    return null;
                }
                if (items.Count == 0)
                {
                    MessageBox.Show("El archivo JSON está vacío o no tiene el formato esperado.",
                                    "Error",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Warning);
                    return null;
                }

                return items;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el archivo JSON:\n{ex.Message}",
                                "Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                return null;
            }
        }
    }
}
