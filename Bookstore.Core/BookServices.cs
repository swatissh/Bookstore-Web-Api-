using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace Bookstore.Core
{
    public class BookServices : IBookServices
    {
        private readonly IMongoCollection<Book> _books;

        public BookServices(IDBClient dbClient)
        {
            _books = dbClient.GetBooksCollection();
        }

        public Book AddBook(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void DeleteBook(string id)
        {
            _books.DeleteOne(book => book.Id == id);
        }

        public Book GetBook(string id) => _books.Find(book => book.Id == id).First();

        public List<Book> GetBooks() => _books.Find(book => true).ToList();

        public Book UpdateBook(Book book)
        {
            GetBook(book.Id);
            _books.ReplaceOne(b => b.Id == book.Id, book);
            return book;
        }

    }
}
