using LibraryApp.BLL.Services.Abstract;
using LibraryApp.DAL.Repositories.Abstract;
using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.BLL.Services
{
    public class FloorService : IFloorService
    {
        private readonly IFloorRepository _floorRepository;

        public FloorService(IFloorRepository floorRepository)
        {
            _floorRepository = floorRepository;
        }

        public IEnumerable<Floor> GetAllFloors()
        {
            return _floorRepository.GetAll();
        }

        public Floor GetFloorById(int id)
        {
            return _floorRepository.GetById(id);
        }

        public void AddFloor(Floor floor)
        {
            _floorRepository.Insert(floor);
        }

        public void UpdateFloor(Floor floor)
        {
            _floorRepository.Update(floor);
        }

        public void DeleteFloor(int id)
        {
            var floor = _floorRepository.GetById(id);
            if (floor != null)
            {
                _floorRepository.Delete(floor);
            }
        }
    }
}
    