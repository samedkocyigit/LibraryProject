using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.BLL.Services.Abstract
{
    public interface IShelfService
    {
        IEnumerable<Shelf>  GetAllShelves();
        Shelf GetShelfById(int id);
        void AddShelf(Shelf shelf);
        void UpdateShelf(Shelf shelf);
        void DeleteShelf(int id);
    }
}
