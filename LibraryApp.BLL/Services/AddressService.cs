using LibraryApp.DAL.Repositories.Abstract;
using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.BLL.Services
{
    public class AddressService
    {
        private readonly IGenericRepository<Address> _addressRepository;

        public AddressService(IGenericRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
            
        }

        public IEnumerable<Address> GetAllAddresses() 
        { 
            return _addressRepository.GetAll();
        }

        public Address GetAddressById(int id)
        {
            return _addressRepository.GetById(id);
        }

        public void AddAddress(Address address)
        {
            _addressRepository.Insert(address);
        }
        public void UpdateAddress(Address address)
        {
            _addressRepository.Update(address);
        }

        public void DeleteAddress(int id)
        {
            var address = _addressRepository.GetById(id);
            if (address != null)
            {
                _addressRepository.Delete(address);
            }
        }
    }
}
