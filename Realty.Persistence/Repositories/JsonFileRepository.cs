
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace RealtyManagementSystem.Persistence.Repositories
{
    
    public class JsonFileRepository<T> where T : class
    {
        private readonly string _filePath;

        public JsonFileRepository(string fileName)
        {
            
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        }

        public List<T> Load()
        {
            if (!File.Exists(_filePath))
            {
                return new List<T>();
            }
            try
            {
                string jsonString = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<T>>(jsonString) ?? new List<T>();
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error loading data from {_filePath}: {ex.Message}");
                return new List<T>();
            }
        }

        public void Save(List<T> data)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(data, options);
            File.WriteAllText(_filePath, jsonString);
        }
    }
}