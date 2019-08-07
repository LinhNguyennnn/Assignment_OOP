using System;
using System.Collections;
namespace Assignment
{
    class Book
    {
        private string bookId;
        private string bookName;
        private string author;
        private int count;
        private string category;
        private int countNumberBook = 0;
        public Book() { }

        public Book(string bookId, string bookName, string author, int count, string category)
        {
            this.BookId = bookId;
            this.BookName = bookName;
            this.Author = author;
            this.Count = count;
            this.Category = category;
        }

        public string BookId { get => bookId; set => bookId = value; }
        public string BookName { get => bookName; set => bookName = value; }
        public string Author { get => author; set => author = value; }
        public int Count { get => count; set => count = value; }
        public string Category { get => category; set => category = value; }
    }
}