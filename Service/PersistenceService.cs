using System.IO;
using System.Text.Json;
using ToDoList.Entity;

namespace ToDoList.Service
{
    public static class PersistenceService
    {
        private static readonly string FilePath = "data.json";
        /// <summary>
        /// Saves the data to a JSON file.
        /// </summary>
        public static void Save(Data data)
        {
            try
            {
                var options = new JsonSerializerOptions {WriteIndented = true};
                string jsonString = JsonSerializer.Serialize(data.Notes, options);

                File.WriteAllText(FilePath, jsonString);
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteColored($"\n ⚠️ Veriler kaydedilirken hata oluştu: {ex.Message}", ConsoleColor.Red);
            }
        }

        public static void Load(Data data)
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string jsonString = File.ReadAllText(FilePath);
                    var notes = JsonSerializer.Deserialize<List<Note>>(jsonString);
                    if(notes != null)
                    {
                        data.Notes = notes;
                    }
                }
            }
            catch(Exception ex)
            {
                ConsoleHelper.WriteColored($"\n ⚠️ Veriler yüklenirken hata oluştu: {ex.Message}", ConsoleColor.Red);
            }
        }
    }

}