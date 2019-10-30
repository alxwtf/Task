using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var Jobs = new List<Job>();
            if (File.Exists("Test.json"))
            {
                Jobs = JsonConvert.DeserializeObject<List<Job>>(File.ReadAllText("Test.json"));
            }
            var Actions = new Actions(Jobs);
            var answer = 0;
            do
            {
                System.Console.WriteLine("1. Добавить задачу\n2. Посмотреть список задач");
                System.Console.WriteLine("3. Найти задачу по названию,тегу\n4. Посмотреть конкретную задачу");
                System.Console.WriteLine("5. Установить тег на задачу\n6. Удалить задачу");
                System.Console.WriteLine("7. Выход");
                int.TryParse(Console.ReadLine(), out answer);
                switch (answer)
                {
                    case 1:
                        {
                            Actions.Add();
                            using (StreamWriter file = File.CreateText("Test.json"))
                            {
                                JsonSerializer serializer = new JsonSerializer();
                                serializer.Serialize(file, Jobs);
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            if (Jobs.Count != 0)
                                Actions.History(Jobs);
                            else Console.WriteLine("Задачи не найдены");
                            break;
                        }
                    case 3: { Actions.Search(); break; }
                    case 4: { Actions.TaskInfo(); break; }
                    case 5: { Actions.setTag(); break; }
                    case 6: { Actions.DeleteTask(); break; }
                    default: break;
                }
            } while (answer != 7);
        }
    }
}
