using System.Collections.Generic;
using System;
using System.Linq;

namespace Task
{
    class Actions
    {
        private List<Job> _jobs;

        public Actions(List<Job> Jobs)
        {
            _jobs = Jobs;
        }

        public void Add()
        {
            Console.Clear();
            var id = Guid.NewGuid();
            Console.WriteLine("Название задачи");
            var Name = Console.ReadLine();
            Console.WriteLine("Описание задачи");
            var Description = Console.ReadLine();
            Console.WriteLine("Введите тэги через пробел");
            var Tags = Console.ReadLine();
            var CreationDate = DateTime.Now.Date;
            System.Console.WriteLine("Введите дату завершения");
            DateTime? Date = DateTime.Parse(Console.ReadLine());
            _jobs.Add(new Job()
            {
                id = id,
                Name = Name,
                Description = Description,
                Tag = Tags,
                CreationDate = CreationDate,
                Date = Date
            });
        }

        public void History(List<Job> query)
        {
            Console.WriteLine();
            var count = 0;
            foreach (var Job in query)
            {
                if (query.Count > 1)
                {
                    Console.WriteLine($"Задача №{count++}");
                }
                Console.Write("ID:");
                Console.WriteLine(Job.id);
                Console.Write("Название задачи:");
                Console.WriteLine(Job.Name);
                Console.WriteLine("Описание задачи:");
                Console.WriteLine(Job.Description);
                Console.WriteLine("Тэги:");
                Console.WriteLine(Job.Tag);
                Console.Write("Дата создания:");
                Console.WriteLine(Job.CreationDate);
                if (Job.Date != null)
                {
                    Console.Write("Дата завершения:");
                    Console.WriteLine(Job.Date);
                }
            }
            Console.WriteLine();
        }
        public void Search()
        {
            Console.Clear();
            Console.WriteLine("Вести поиск по\n1. Названию\n2. Тэгу");
            int.TryParse(Console.ReadLine(), out var answer);
            switch (answer)
            {
                case 1:
                    {
                        Console.WriteLine("Введите название Задачи");
                        var name = Console.ReadLine();
                        var query = _jobs.Where(x => x.Name == name).ToList();
                        if (query.Count() != 0) History(query);
                        else Console.WriteLine("Задачи не найдены");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Введите Тэг(и)");
                        var tags = Console.ReadLine();
                        var query = _jobs.Where(x => x.Tag.Contains(tags)).ToList();
                        if (query.Count() != 0) History(query);
                        else Console.WriteLine("Задачи не найдены");
                        break;
                    }
                default: break;
            }
        }
        public void TaskInfo()
        {
            Console.Clear();
            if (_jobs.Count() != 0)
            {
                Console.WriteLine($"Введите номер задачи от 0 до {_jobs.Count() - 1}");
                int.TryParse(Console.ReadLine(), out var tasknum);
                var query = _jobs.Where((x, idx) => idx == tasknum).ToList();
                History(query);
            }
            else Console.WriteLine("Задач на данный момент нет");
        }
        public void setTag()
        {
            Console.Clear();
            if (_jobs.Count != 0)
            {
                History(_jobs);
                Console.WriteLine($"Введите индекс задачи от 0 до {_jobs.Count() - 1}");
                var numb = int.TryParse(Console.ReadLine(), out var num);
                if (numb)
                {
                    Console.WriteLine("Введите новые тэги через пробел");
                    _jobs[num].Tag = Console.ReadLine();
                }
                else { Console.Clear(); System.Console.WriteLine("Попробуйте снова\nвозможно вы оставили ввод пустым или ввели буквы\n"); }
            }
            else System.Console.WriteLine("Задач нет\n");
        }
        public void DeleteTask()
        {
            Console.Clear();
            var query = _jobs.Select((x, i) => new { Index = i, x.Name, x.Description }).ToList();
            if (query.Count != 0)
            {
                foreach (var job in query)
                {
                    System.Console.WriteLine($"Номер задачи:{job.Index}");
                    System.Console.WriteLine($"Название задачи:{job.Name}");
                    System.Console.WriteLine($"Описание:{job.Description}\n");
                }
                System.Console.WriteLine($"Выберите индекс для удаления от 0 до {query.Count() - 1}\nдля отмены введите enter");
                var ind = "";
                do
                {
                    ind = Console.ReadLine();
                    if (ind != "")
                    {
                        var isNumb = int.TryParse(ind, out var n);
                        if (isNumb)
                        {
                            _jobs.RemoveAt(int.Parse(ind));
                            System.Console.WriteLine("Успешно удалено\n");
                            break;
                        }
                        else System.Console.WriteLine("Вы ввели не индекс");
                    }
                    else { System.Console.WriteLine("Отмена\n"); }
                } while (ind != "");
            }
            else { System.Console.WriteLine("Пусто\n"); }
        }
    }
}