using System;
using Data.Context;
using Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Implementation;
using AppSevice.DTOc;

namespace AppSevice.Implementation
{
    public class CarListManagementService
    {
      

        public List<CarListDTO> Get()
        {
            List<CarListDTO> CarListDto = new List<CarListDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
       
                foreach (var item in unitOfWork.CarListRepository.Get())
                {

                    CarListDto.Add(new CarListDTO
                    {
                        Id = item.Id,
                        Brand = item.Brand,
                        Model = item.Model,
                        Years = item.Years,
                        Description = item.Description,
                        Prise = item.Prise,

                    });

                }
            }
            

            return CarListDto;
        }

        public CarListDTO GetById(int id)
        {
            CarListDTO CarListDTO = new CarListDTO();

            
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                CarList CarList = unitOfWork.CarListRepository.GetByID(id);
                if (CarList != null)
                {
                    CarListDTO = new CarListDTO
                    {
                        Id = CarList.Id,
                        Brand = CarList.Brand,
                        Model = CarList.Model,
                        Years = CarList.Years,                       
                        Description = CarList.Description,
                        Prise = CarList.Prise
                    };
                }
            }
            

            return CarListDTO;
        }

        public bool Save(CarListDTO CarListDTO)
        {
            CarList CarList = new CarList
            {
                Brand = CarListDTO.Brand,
                Model = CarListDTO.Model,
                Years = CarListDTO.Years,
                Description = CarListDTO.Description,
                Prise = CarListDTO.Prise
            };

            try
            {
                /*
                ctx.Nationalities.Add(Nationality);
                ctx.SaveChanges();
                */
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.CarListRepository.Insert(CarList);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
       ;

                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    CarList CarList = unitOfWork.CarListRepository.GetByID(id);
                    unitOfWork.CarListRepository.Delete(CarList);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
