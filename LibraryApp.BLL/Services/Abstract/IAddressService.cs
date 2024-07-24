using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.BLL.Services.Abstract
{
    public interface IAddressService
    {
        IEnumerable<Address> GetAllAddresses();
        Address GetAddressById(int id);
        void AddAddress(Address address);
        void UpdateAddress(Address address);
        void DeleteAddress(int id);
    }
}
