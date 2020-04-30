using System;
using System.Collections.Generic;
using System.Threading;


namespace MyprojecsApp
{
    class Program
    {
        public static int newID=0;
        public static List<Clients> ClientsList = new List<Clients>();
        public static List<Clients> CheckClientList = new List<Clients>();
        static void Main(string[] args)
        {
            TimerCallback TimerCallback = new TimerCallback(FindUpdateBalance);
            Timer tm = new Timer(TimerCallback, ClientsList, 0, 1000);

            while (true)
            {
                Console.WriteLine("1.Добавить клиент\n2.Обновить или изменить данние клиента по ID\n3.Удалить все\n4.Удалить данние клиента по ID\n5.Посмотреть список клиент\n6.Посмотреть данние клиента по ID");
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
                            Thread UpdateByIdThread = new Thread(new ThreadStart(UpdateById));
                            UpdateByIdThread.Start();
                            UpdateByIdThread.Join();
                        }
                        break;
                    case "3":
                        {
                            Thread DeleteThread = new Thread(new ThreadStart(Delete));
                            DeleteThread.Start();
                            DeleteThread.Join();
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

        public static void FindUpdateBalance(object obj)
        {
            List<Clients> list = obj as List<Clients>;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Balance > CheckClientList[i].Balance)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"ID:{list[i].ID}\nБаланс до изменения:{CheckClientList[i].Balance}\nБаланс после изменения:{list[i].Balance}\nРазница: +{list[i].Balance - CheckClientList[i].Balance}");
                    Console.ForegroundColor = ConsoleColor.White;
                    CheckClientList[i].Balance = list[i].Balance;
                }
                else if (list[i].Balance < CheckClientList[i].Balance)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ID:{list[i].ID}\nБаланс до изменения:{CheckClientList[i].Balance}\nБаланс после изменения:{list[i].Balance}\nРазница: {list[i].Balance - CheckClientList[i].Balance}");
                    Console.ForegroundColor = ConsoleColor.White;
                    CheckClientList[i].Balance = list[i].Balance;
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
            newID++;
            Console.Write("Balance: "); decimal Balance = Decimal.Parse(Console.ReadLine());
            Clients ClientInsert = new Clients(LastName, FirstName, MiddleName, newID, Balance);
            ClientsList.Add(ClientInsert);
            CheckClientList.Add(ClientInsert);
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
            Clients ClientUpdate = new Clients(LastName, FirstName, MiddleName, SetId, Balance);
            foreach (var i in ClientsList)
            {
                if (SetId == i.ID)
                {
                    int index = ClientsList.IndexOf(i);
                    ClientsList[index] = ClientUpdate;
                    break;
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
                    CheckClientList.Remove(i);
                    ClientsList.Remove(i);
                    Console.WriteLine("Элемент удален из списка");
                    break;
                }
            }
        }
        public static void Delete()
        {
            Console.Clear();
                    CheckClientList.Clear();
                    ClientsList.Clear();
                    Console.WriteLine("Все элементы удалено!!!");
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
