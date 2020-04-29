using System;
using System.Collections.Generic;
using System.Threading;

namespace MyprojecsApp
{
    class Program
    {
        public static List<Clients> ClientsList = new List<Clients>();
        static void Main(string[] args)
        {
            // Задача 1
            while (true)
            {
                Console.WriteLine("1.Добавить клиент\n2.Обновить или изменить все данние клиента\n3.Обновить или изменить данние клиента по ID\n4.Удалить данние клиента по ID\n5.Посмотреть список клиент\n6.Посмотреть данние клиента по ID");
                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            Thread InsertThread = new Thread(new ThreadStart(Insert));
                            InsertThread.Start();
                            InsertThread.Join();
                        }
                        break;
                    case "2":
                        {
                            Thread UpdateThread = new Thread(new ThreadStart(Update));
                            UpdateThread.Start();
                            UpdateThread.Join();
                        }
                        break;
                    case "3":
                        {
                            Thread SelectByIdThread = new Thread(new ThreadStart(SelectById));
                            SelectByIdThread.Start();
                            SelectByIdThread.Join();
                        }
                        break;
                    case "4":
                        {
                            Thread DeleteByIdThread = new Thread(new ThreadStart(DeleteById));
                            DeleteByIdThread.Start();
                            DeleteByIdThread.Join();
                        }
                        break;
                    case "5":
                        {
                            Thread SelectThread = new Thread(new ThreadStart(Select));
                            SelectThread.Start();
                            SelectThread.Join();
                        }
                        break;
                    case "6":
                        {
                            Thread SelectByIdThread = new Thread(new ThreadStart(SelectById));
                            SelectByIdThread.Start();
                            SelectByIdThread.Join();
                        }
                        break;

                }
            }
        }


        //Добавить новый клиент в лист
        public static void Insert()
        {
            Console.Clear();
            Console.Write("LastName: "); string LastName = Console.ReadLine();
            Console.Write("FirstName: "); string FirstName = Console.ReadLine();
            Console.Write("MiddleName: "); string MiddleName = Console.ReadLine();
            Console.Write("ID: "); int ID = int.Parse(Console.ReadLine());
            Console.Write("Balance: "); decimal Balance = Decimal.Parse(Console.ReadLine());
            Clients ClientInsert = new Clients(LastName, FirstName, MiddleName, ID, Balance);
            ClientsList.Add(ClientInsert);
        }
        //Обновить все
        public static void Update()
        {
            Console.Clear();
            Console.Write("LastName: "); string LastName = Console.ReadLine();
            Console.Write("FirstName: "); string FirstName = Console.ReadLine();
            Console.Write("MiddleName: "); string MiddleName = Console.ReadLine();
            Console.Write("Balance: "); decimal Balance = Decimal.Parse(Console.ReadLine());
            foreach (var i in ClientsList)
            {
                i.LastName = LastName;
                i.FirstName = FirstName;
                i.MiddleName = MiddleName;
                i.Balance = Balance;
            }
        }
        //Обновить по Id
        public static void UpdateById()
        {
            Console.Clear();
            Console.Write("ID: "); int SetId = int.Parse(Console.ReadLine());
            Console.Write("LastName: "); string LastName = Console.ReadLine();
            Console.Write("FirstName: "); string FirstName = Console.ReadLine();
            Console.Write("MiddleName: "); string MiddleName = Console.ReadLine();
            Console.Write("Balance: "); decimal Balance = Decimal.Parse(Console.ReadLine());
            foreach (var i in ClientsList)
            {
                if (SetId == i.ID)
                {
                    i.LastName = LastName;
                    i.FirstName = FirstName;
                    i.MiddleName = MiddleName;
                    i.Balance = Balance;
                }
            }

        }
        //Удалить по Id
        public static void DeleteById()
        {
            Console.Clear();
            Console.Write("ID: "); int SetId = int.Parse(Console.ReadLine());
            foreach (var i in ClientsList)
            {
                if (SetId == i.ID)
                {
                    ClientsList.Remove(i);
                    Console.WriteLine("Элемент удален из списка");
                    break;
                }
            }
        }
        //Посмотрет все
        public static void Select()
        {
            Console.Clear();
            foreach (var i in ClientsList)
            {
                Console.WriteLine($"Фамилия: {i.LastName}\nИмя: {i.FirstName}\nОчество: {i.MiddleName}\nID: {i.ID}\nБаланс: {i.Balance}");
                Console.WriteLine("________________________________________________________________________________");
            }
        }
        //Посмотреть по Id
        public static void SelectById()
        {
            Console.Clear();
            Console.Write("ID: "); int SetId = int.Parse(Console.ReadLine());
            foreach (var i in ClientsList)
            {
                if (SetId == i.ID)
                    Console.WriteLine($"Фамилия: {i.LastName}\nИмя: {i.FirstName}\nОчество: {i.MiddleName}\nID: {i.ID}\nБаланс: {i.Balance}");
            }
        }
    }
    class Clients
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public int ID { get; set; }
        public decimal Balance { get; set; }
        public Clients(string LastName, string FirstName, string MiddleName, int ID, decimal Balance)
        {
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.ID = ID;
            this.Balance = Balance;
        }
        public Clients()
        {

        }

    }
}
