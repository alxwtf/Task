using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Task
{
    class Files
    {
        private List<Job> _jobs;
        public List<Job> GetJobList()
        {
            System.Console.WriteLine("Поиск файла с задачами:");
            if (File.Exists("Test.json"))
            {
                _jobs = JsonConvert.DeserializeObject<List<Job>>(File.ReadAllText("Test.json"));
                System.Console.WriteLine("Файл с задачами был успешно загружен\n");
                return _jobs;
            }
            else System.Console.WriteLine("Файл не найден\nно будет создан при создании задачи\n");
            return _jobs;
        }
        public void WriteToFile(List<Job> _jobs)
        {
            File.WriteAllText("Test.json", JsonConvert.SerializeObject(_jobs));
        }
    }
}
