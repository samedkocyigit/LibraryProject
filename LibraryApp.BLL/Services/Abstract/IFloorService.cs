using LibraryApp.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.BLL.Services.Abstract
{
    public interface IFloorService
    {
        IEnumerable<Floor> GetAllFloors();
        Floor GetFloorById(int id);
        void AddFloor(Floor floor);
        void UpdateFloor(Floor floor);
        void DeleteFloor(int id);
    }
}
