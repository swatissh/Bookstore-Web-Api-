using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace Bookstore.Core
{
    public interface IDBClient
    {
        IMongoCollection<Book> GetBooksCollection();
    }
}
