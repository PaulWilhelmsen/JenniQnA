using System;
using System.Collections.Generic;
using System.IO;

namespace Persistence.Utility
{
    public class FileHandler
    {
        public void WriteToJson()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "questions.json");

            using (var file = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite)) { }
            var jsonData = File.ReadAllText(path);
            var list = JsonConvert.DeserializeObject<List<QuestionObject>>(jsonData)
                       ?? new List<QuestionObject>();
            list.Add(newObject);
            jsonData = JsonConvert.SerializeObject(list);
            File.WriteAllText(path, jsonData);
        }
    }
}