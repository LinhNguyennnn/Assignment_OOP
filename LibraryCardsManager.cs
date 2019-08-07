using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Assignment
{
    class LibraryCardsManager
    {
        static List<LibraryCards> ListCards = new List<LibraryCards>();
        public void DisplayLibraryCards()
        {
            while (true)
            {
                Menu Menu = new Menu();
                Console.Clear();
                Console.WriteLine("=======================================\n");
                Console.WriteLine("Quan ly the thu vien\n");
                Console.WriteLine("1. Xem danh sach the thu vien");
                Console.WriteLine("2. Cap nhat thong tin the");
                Console.WriteLine("3. Them moi mot the");
                Console.WriteLine("0. Tro ve MENU chinh\n");
                Console.Write("#Chon : ");
                int number;
                while (true)
                {
                    bool isINT = Int32.TryParse(Console.ReadLine(), out number);
                    if (!isINT)
                    {
                        Console.WriteLine("Nhap sai !");
                        Console.Write("#Chon : ");
                    }
                    else if (number < 0 || number > 3)
                    {
                        Console.WriteLine("Nhap sai !");
                        Console.Write("#Chon : ");
                    }
                    else
                    {
                        break;
                    }
                }
                switch (number)
                {
                    case 1:
                        DisplayListCards();
                        break;
                    case 2:
                        UpdateCards();
                        break;
                    case 3:
                        AddCard();
                        break;
                    case 0:
                        Menu.MENU();
                        break;
                }
            }
        }
        public void AddCard()
        {
            Console.Clear();
            LibraryCards cards = new LibraryCards();
            Console.Write("- Nhap ma the: ");
            while (true)
            {
                string id = Console.ReadLine();
                Regex regex = new Regex(@"^[a-zA-Z0-9]+$");
                if (ListCards.FindIndex(x => x.IdCards == id) == -1)
                {
                    if (regex.IsMatch(id))
                    {
                        cards.IdCards = id;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Nhap sai!");
                        Console.Write("Nhap lai: ");
                    }
                }
                else
                {
                    Console.Write("Ma the da ton tai, nhap lai :");
                }
            }
            Console.Write("- Nhap ten chu the: ");
            while (true)
            {
                string cName = Console.ReadLine();
                Regex regex = new Regex(@"^[a-zA-Z]+$");
                if (regex.IsMatch(cName))
                {
                    cards.CardsName = cName;
                    break;
                }
                else
                {
                    Console.WriteLine("Nhap sai! ");
                    Console.Write("Nhap lai: ");
                }

            }
            Console.Write("- Nhap so CMND: ");
            while (true)
            {
                string a = Console.ReadLine();
                Regex regex = new Regex(@"^[0-9]+$");
                if (ListCards.FindIndex(x => x.PeopleId == a) == -1)
                {
                    if (regex.IsMatch(a))
                    {
                        if (a.Length == 12 || a.Length == 9)
                        {
                            if (regex.IsMatch(a))
                            {
                                cards.PeopleId = a;
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("So CMND bao gom 9 hoac 12 so !");
                            Console.Write("Nhap lai: ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("So CMND bao gom 9 hoac 12 so !");
                        Console.Write("Nhap lai: ");
                    }
                }
                else
                {
                    Console.Write("So CMND da ton tai, nhap lai :");
                }

            }
            Console.WriteLine(" ");
            Console.Write("Ban muon them the?(Y/N): ");
            string Question;
            while (true)
            {
                Question = Console.ReadLine();
                if (Question == "Y" || Question == "N" || Question == "y" || Question == "n")
                {
                    break;
                }
                else
                {
                    Console.Write("Ban muon them the?(Y/N): ");
                }
            }
            switch (Question)
            {
                case "Y":
                    Console.Write("Da them the thu vien !\n");
                    cards.Ngaytao1 = DateTime.Today;
                    ListCards.Add(cards);
                    Console.ReadKey();
                    break;
                case "y":
                    Console.Write("Da them the thu vien !\n");
                    cards.Ngaytao1 = DateTime.Today;
                    ListCards.Add(cards);
                    Console.ReadKey();
                    break;
                case "N":
                    break;
                case "n":
                    break;
            }
        }
        public void DisplayListCards()
        {
            Console.Clear();
            Console.WriteLine("=======================================\n");
            Console.WriteLine("Danh sach the thu vien\n");
            Console.WriteLine("=======================================\n");
            var table = new ConsoleTable("Ma the", "Ten chu the", "So CMND", "Ngay tao");
            foreach (var item in ListCards)
            {
                table.AddRow(item.IdCards, item.CardsName, item.PeopleId, item.Ngaytao1.ToString("dd/MM/yyyy"));
            }
            table.Write(Format.Alternative);
            Console.Write("Nhan phim bat ki de quay lai !");
            Console.ReadKey();
        }
        public void UpdateCards()
        {
            Console.Clear();
            LibraryCards cards = new LibraryCards();
            if (ListCards.Count == 0)
            {
                Console.WriteLine("Danh sach the thu vien trong !");
                Console.Write("Ban co muon them moi mot the ? (Y/N): ");
                string Question;
                while (true)
                {
                    Question = Console.ReadLine();
                    if (Question == "Y" || Question == "N" || Question == "y" || Question == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Ban co muon them moi mot the ? (Y/N): ");
                    }
                }
                switch (Question)
                {
                    case "Y":
                        AddCard();
                        break;
                    case "y":
                        AddCard();
                        break;
                    case "N":
                        break;
                    case "n":
                        break;
                }
            }
            else
            {
                Console.Clear();
                int item;
                Console.Write("- Nhap ma the : ");
                while (true)
                {
                    cards.IdCards = Console.ReadLine();
                    item = ListCards.FindIndex(x => x.IdCards == cards.IdCards);
                    if (item == -1)
                    {
                        Console.WriteLine("Ma the khong ton tai !");
                        Console.Write("- Nhap ma the : ");
                    }
                    else
                    {
                        break;
                    }
                }
                Console.Write("- Sua ten chu the: ");
                while (true)
                {
                    string cName = Console.ReadLine();
                    Regex regex = new Regex(@"^[a-zA-Z]+$");
                    if (regex.IsMatch(cName))
                    {
                        cards.CardsName = cName;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Nhap sai! ");
                        Console.Write("Nhap lai: ");
                    }
                }
                Console.Write("- Nhap so CMND: ");
                while (true)
                {
                    string a = Console.ReadLine();
                    Regex regex = new Regex(@"^[0-9]+$");
                    if (ListCards.FindIndex(x => x.PeopleId == a) == -1)
                    {
                        if (regex.IsMatch(a))
                        {
                            if (a.Length == 12 || a.Length == 9)
                            {
                                if (regex.IsMatch(a))
                                {
                                    cards.PeopleId = a;
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("So CMND bao gom 9 hoac 12 so !");
                                Console.Write("Nhap lai: ");
                            }
                        }
                        else
                        {
                            Console.WriteLine("So CMND bao gom 9 hoac 12 so !");
                            Console.Write("Nhap lai: ");
                        }
                    }
                    else
                    {
                        Console.Write("So CMND da ton tai, nhap lai :");
                    }
                }
                Console.Write("Ban co muon sua thong tin the ? (Y/N): ");
                string Question;
                while (true)
                {
                    Question = Console.ReadLine();
                    if (Question == "Y" || Question == "N" || Question == "y" || Question == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Ban co muon sua thong tin the ? (Y/N): ");
                    }
                }
                switch (Question)
                {
                    case "Y":
                        Console.WriteLine("Da sua thong tin the! ");
                        ListCards[item].CardsName = String.Copy(cards.CardsName);
                        ListCards[item].PeopleId = String.Copy(cards.PeopleId);
                        break;
                    case "y":
                        Console.WriteLine("Da sua thong tin the! ");
                        ListCards[item].CardsName = String.Copy(cards.CardsName);
                        ListCards[item].PeopleId = String.Copy(cards.PeopleId);
                        break;
                    case "n":
                        break;
                    case "N":
                        break;
                }
            }
        }
        public List<LibraryCards> getListCard()
        {
            return ListCards;
        }

        static public void _addCard(LibraryCards cards)
        {
            ListCards.Add(cards);
        }
    }
}