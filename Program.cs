using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Variant2
{
    interface GUID
    {
        string GetGuid();
    }
    interface CRUD
    {
        void Create();
        void Update();
        void Delete();
        void PrintAll();
    }
    interface IEventHandler
    {
        void OnInsert();
        void OnUpdate();
        void OnDelete();
    }
    interface IDataAccessor
    {
        List<string> GetListGuid();
        Persona GetGuid(string guid);
    }
    class PersonException : Exception
    {
        public PersonException(string message)
            : base(message) { }
    }
    class Program
    {
        public delegate void Save(object ob);
        static void OpenJson (object obj)
        {
            SavePeople.Deserializable(); // считали файлы


        }
        public static void DisplayMessage(string message, EventArgs e)
        {
            // если создание
            if (e.statement == eventStatement.create)
            {
                Console.WriteLine(e.Message);
            }
            // если обновление
            if (e.statement == eventStatement.update)
            {
                Console.WriteLine(e.Message);
            }
            // если удаление
            if (e.statement == eventStatement.delete)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Main(string[] args)
        {
            Control control = new Control();

            int num = 0;
            // устанавливаем метод обратного вызова
            TimerCallback tm = new TimerCallback(SavePeople.Deserializable);
            // создаём таймер
            Timer timer = new Timer(tm, num, 0, 60000); // каждую минуту

            int k = 1;
            while (k > 0)
            {
                Console.WriteLine("Выберите что хотите сделать: 0 - выйти, 1 - создать, 2 - изменить, 3 - удалить, 4 - вывести весь список");
                int a1 = int.Parse(Console.ReadLine());
                switch (a1)
                {
                    case 0:
                        {
                            k = 0;
                            Story.office_worker.Clear();
                            Story.personal.Clear();
                            Story.engineer.Clear();
                            Story.worker.Clear();
                            SavePeople.Save_Json();
                            break;
                        }
                    case 1:
                        {
                            control.Create();
                            control.Notify += DisplayMessage;
                            control.EventCreate();
                            control.Notify -= DisplayMessage;
                            break;
                        }
                    case 2:
                        {
                            control.Update();
                            control.Notify += DisplayMessage;
                            control.EventUpdate();
                            control.Notify -= DisplayMessage;
                            break;
                        }
                    case 3:
                        {
                            control.Delete();
                            control.Notify += DisplayMessage;
                            control.EventDelete();
                            control.Notify -= DisplayMessage;
                            break;
                        }
                    case 4:
                        {
                            control.PrintAll();
                            break;
                        }
                    default:
                        Console.WriteLine("Введено неверное значение. Повторите попытку.");
                        break;
                }
            }
        }
    }
}
