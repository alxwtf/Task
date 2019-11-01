using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Task
{
    class Files
    {
        private List<Job> _Jobs;
        public List<Job> FileCheck()
        {
            System.Console.WriteLine("Поиск файла с задачами:");
            if (File.Exists("Test.json"))
            {
                _Jobs = JsonConvert.DeserializeObject<List<Job>>(File.ReadAllText("Test.json"));
                System.Console.WriteLine("Файл с задачами был успешно загружен\n");
                return _Jobs;
            }
            else System.Console.WriteLine("Файл не найден\nно будет создан при создании задачи\n");
            return _Jobs;
        }
        public void WriteToFile(List<Job> _Jobs)
        {
            File.WriteAllText("Test.json", JsonConvert.SerializeObject(_Jobs));
        }
    }
}
