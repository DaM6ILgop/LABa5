using System;
using System.Collections.Generic;
//using System.Collections;
using System.IO;


namespace Table
{

    public enum type
    {
        K,
        A,
        M
    }
    public enum action
    {

        add,
        del,
        upld
    }

    public struct Item
    {
        public String NameFilm;
        public String Director;
        public int YearOfRelease;
        public String FilmType;
        

        public Item(string NameFilm, String Director, int YearOfRelease, string FilmType)
        {
            this.NameFilm = NameFilm;
            this.Director = Director;
            this.YearOfRelease = YearOfRelease;
            this.FilmType = FilmType;
        }

        public void Print()
        {
            Console.WriteLine($"|{this.NameFilm,-24}|{this.Director,-12}|{this.YearOfRelease,-20}|{this.FilmType,-15}|");
        }
    }
    public struct Action
    {
        public action Act;
        public string NameFilm;
        public DateTime Time;

        public Action(action act, string name, DateTime time)
        {
            this.Act = act;
            this.NameFilm = name;
            this.Time = time;
        }
        public void Print()
        {
            if (Act == action.add)
            {
                Console.WriteLine($"{this.Time} - Добавлена запись '{this.NameFilm}' ");
            }
            else if (Act == action.del)
            {
                Console.WriteLine($"{this.Time} - Удалена запись '{this.NameFilm}' ");
            }
            else if (Act == action.upld)
            {
                Console.WriteLine($"{this.Time} - Обновлена запись '{this.NameFilm}' ");
            }

        }
    }
    class Program
    {

        private static void Main()
        {
            List<Item> list = new List<Item>();

            List<Action> listTwo = new List<Action>();
            string filename = Directory.GetCurrentDirectory() + "\\lab1.txt";

            using (StreamReader streamreader = new StreamReader(File.Open(filename, FileMode.OpenOrCreate)))
            {              
                    while (streamreader.Peek() > -1)
                    {

                        string[] array = streamreader.ReadLine().Split();
                        string NameFilm = array[0];
                        string Director = array[1];
                        int YearOfRelease = int.Parse(array[2]);
                        string FilmType = array[3];
                        list.Add(new Item(NameFilm, Director, YearOfRelease, FilmType));
                        
                    }

            }


            bool flag = true;
            //var FileName = @"C:\Users\Lenovo\Desktop\8888\LISTREADER\1.txt";
            //var lines = File.ReadAllLines(FileName).ToList();
            //list.Add(lines);
                

            while (flag)
            {


                Console.WriteLine("1 – Просмотр таблицы\n2 – Добавить запись\n3 – Удалить запись\n4 – Обновить запись\n5 – Поиск записей\n6 – Просмотреть лог\n7 - Выход");
                switch (Console.ReadLine())
                {

                    case "1":
                        Console.WriteLine(new String('-', 76));
                        Console.WriteLine($"{"|Кинопродукция",-75}|");
                        Console.WriteLine(new String('-', 76));
                        Console.WriteLine($"{"|Фильм",-25}|{"Режиссер ",-12}|{"Год выпуска ",-20}|{"Тип",-15}|");
                        Console.WriteLine(new String('-', 76));
                        
                        foreach (Item item in list)
                        {
                            item.Print();
                            Console.WriteLine(new String('-', 76));
                        }

                        break;
                    case "2":
                        Console.WriteLine("Ввод:");
                        Console.WriteLine("");
                        Console.WriteLine("Фильм:");
                        string NameFilm = Console.ReadLine();

                        Console.WriteLine("Режиссер");
                        string Director = Console.ReadLine();

                        Console.WriteLine("Год выпуска:");
                        int YearOfRelease = int.Parse(Console.ReadLine());

                        Console.WriteLine("Тип:");
                        string FilmType = Console.ReadLine();
                        Item str = new(NameFilm, Director, YearOfRelease, FilmType);
                        list.Add(str);
                        DateTime time = DateTime.Now;
                        Console.WriteLine($"Дата и время {time.Date}, {time.Hour}:{time.Minute}");
                        string name = NameFilm;
                        action act = action.add;
                        Action value = new(act, name, time);
                        listTwo.Add(value);
                        Console.WriteLine("");
                        break;

                    case "3":

                        Console.WriteLine("Введите номер записи которую требуется удалить");

                        int recordNumber = int.Parse(Console.ReadLine());

                        while (recordNumber > list.Count)
                        {
                            Console.WriteLine("Нет такоего элемента списка.\nВведите новое значение");
                            recordNumber = int.Parse(Console.ReadLine());
                        }
                        time = DateTime.Now;
                        name = list[recordNumber - 1].NameFilm;
                        act = action.del;
                        value = new(act, name, time);
                        listTwo.Add(value);

                        list.RemoveAt(recordNumber - 1);

                        break;

                    case "5":
                        string emptyCase1 = string.Empty;
                        Console.WriteLine("Введите тип поиска");
                        Console.WriteLine("1 - поиск по названию фильма, \n2 - поиск режиссера \n3 - по жанру");
                        List<Item> listCase = new List<Item>();
                        switch (Console.ReadLine().Trim())
                        {
                            case "1":
                                Console.WriteLine("введите название");
                                emptyCase1 = Console.ReadLine();
                                foreach (Item item in list)
                                {
                                    if (item.NameFilm.Equals(emptyCase1))
                                        listCase.Add(item);
                                }
                                Console.WriteLine(new String('-', 76));
                                Console.WriteLine($"{"|Кинопродукция",-75}|");
                                Console.WriteLine(new String('-', 76));
                                Console.WriteLine($"{"|Фильм",-25}|{"Режиссер ",-12}|{"Год выпуска ",-20}|{"Тип",-15}|");
                                Console.WriteLine(new String('-', 76));
                                foreach (Item item in listCase)
                                {
                                    item.Print();
                                    Console.WriteLine(new String('-', 76));
                                }
                                break;
                            case "2":
                                Console.WriteLine("Введите режиссера");
                                string emptyCase2 = Console.ReadLine();
                                foreach (Item item in list)
                                {
                                    if (item.Director.Equals(emptyCase2))
                                        listCase.Add(item);
                                }
                                Console.WriteLine(new String('-', 76));
                                Console.WriteLine($"{"|Кинопродукция",-75}|");
                                Console.WriteLine(new String('-', 76));
                                Console.WriteLine($"{"|Фильм",-25}|{"Режиссер ",-12}|{"Год выпуска ",-20}|{"Тип",-15}|");
                                Console.WriteLine(new String('-', 76));
                                foreach (Item item in listCase)
                                {
                                    item.Print();
                                    Console.WriteLine(new String('-', 76));
                                }
                                break;
                                
                        }
                        break;

                    case "6":
                        foreach (Item logs in list)
                        {
                            logs.Print();
                        }

                        if (list.Count == 0)
                        {
                            Console.WriteLine("Лог пуст");
                            Console.WriteLine(" ");
                        }
                        break;

                    case "7":
                        string empty = null;
                        File.WriteAllText(filename, empty);
                        for (int i = 0; i < list.Count; i++) {
                            using (StreamWriter streamwriter = new StreamWriter(File.Open(filename, FileMode.Append)))
                            {
                                streamwriter.WriteLine($"{list[i].NameFilm} {list[i].Director} {list[i].YearOfRelease} {list[i].FilmType}");
                            }

                        }
                        flag = false;
                        break;

                }

                //Console.WriteLine("Введите данные:");

                //Console.WriteLine("Фильм:");
                //string NameFilm = Console.ReadLine();

                //Console.WriteLine("Режиссер");
                //string Director = Console.ReadLine();

                //Console.WriteLine("Год выпуска");
                //int YearOfRelease = Int32.Parse(Console.ReadLine());

                //Console.WriteLine("Тип");
                //string FilmType = (Console.ReadLine());
                //Item value = new(NameFilm, Director, YearOfRelease, FilmType);
                //list.Add(value);
                //while (true)
                //{
                //    Console.WriteLine("Добавить строку?\nда - продолжить\nнет - вывод таблицы");
                //    string input = Console.ReadLine();
                //    if (input == "да" || input == "нет")
                //    {
                //        if (input == "нет")
                //        {
                //            flag = false;
                //            break;
                //        }
                //        break;
                //    }
                //    else Console.WriteLine("Ошибка ввода. Попробуйте еще раз.");
                //}

            }
            //Console.WriteLine(new String('-', 76));
            //Console.WriteLine($"{"|Кинопродукция",-75}|");
            //Console.WriteLine(new String('-', 76));
            //Console.WriteLine($"{"|Фильм",-25}|{"Режиссер ",-12}|{"Год выпуска ",-20}|{"Тип",-15}|");
            //Console.WriteLine(new String('-', 76));
            //foreach (Item item in list)
            //{
            //    item.Print();
            //    Console.WriteLine(new String('-', 76));
            //}
            //Console.WriteLine($"{"|Перечисляемый тип: K – комедия, A - Мультфильм, M - Мелодрама",-75}|");
            //Console.WriteLine(new String('-', 76));
        }

    }



}
