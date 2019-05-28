using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBookStore.Models;

namespace TheBookStore.Contracts
{
    public interface IBookRepository
    {
        IQueryable<Book> All { get; }
        IQueryable<Book> Search(string criteria);
        Book GetOne(int id);
    }
}
