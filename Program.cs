using System;
using System.Collections.Generic;

namespace MyprojecsApp
{
    class Program
    {
        public static List<Clients> ClientsList = new List<Clients>();
        static void Main(string[] args)
        {
            Console.ReadKey();
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
        public static void UpdateById(int SetId)
        {
            Console.Clear();
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
        public static void DeleteById(int SetId)
        {
            Console.Clear();
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
        public static void SelectById(int SetId)
        {
            Console.Clear();
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
