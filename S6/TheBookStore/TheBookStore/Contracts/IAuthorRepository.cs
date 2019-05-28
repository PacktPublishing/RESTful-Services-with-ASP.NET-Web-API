using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBookStore.Models;

namespace TheBookStore.Contracts
{
    public interface IAuthorRepository
    {
        IQueryable<Author> All { get; }
    }
}
