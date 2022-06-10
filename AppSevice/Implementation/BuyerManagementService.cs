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
    class BuyerManagementService
    {
        public List<BuyerDTO> Get()
        {
            List<BuyerDTO> BuyerDto = new List<BuyerDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.BuyerRepository.Get())
                //foreach (var item in ctx.Students.ToList())
                {

                    BuyerDto.Add(new BuyerDTO
                    {
                        CarListId = item.CarListId,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Mony = item.Mony,
                        CarList = new CarListDTO
                        {
                            Id = item.Id,
                            Brand = item.CarList.Brand,
                            Model = item.CarList.Model,
                            Years = item.CarList.Years,
                            Description = item.CarList.Description,
                            Prise = item.CarList.Prise,

                        }
                    });

                }
            }

            return BuyerDto;
        }

        public BuyerDTO GetById(int id)
        {
            BuyerDTO BuyerDTO = new BuyerDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Buyer Buyer = unitOfWork.BuyerRepository.GetByID(id);
                if (Buyer != null)
                {
                    BuyerDTO = new BuyerDTO
                    {
                        FirstName = Buyer.FirstName,
                        LastName = Buyer.LastName,
                        Mony = Buyer.Mony,

                        CarList = new CarListDTO
                        {
                            Id = Buyer.CarListId,
                            Brand = Buyer.CarList.Brand,
                            Model = Buyer.CarList.Model,
                            Years = Buyer.CarList.Years,
                            Description = Buyer.CarList.Description,
                            Prise = Buyer.CarList.Prise
                        }
                    };
                }

            }

            return BuyerDTO;
        }

        public bool Save(BuyerDTO BuyerDTO)
        {
            // either init nationality beforehand or create a check
            if (BuyerDTO.CarList == null || BuyerDTO.CarList.Id == 0)
            {
                return false;
            }

            // add additional functionality - if there is no such nationality -> create it
            CarList carList = new CarList
            {
                Id = BuyerDTO.Id,
                Brand = BuyerDTO.CarList.Brand,
                Model = BuyerDTO.CarList.Model,
                Years = BuyerDTO.CarList.Years,
                Description = BuyerDTO.CarList.Description,
                Prise = BuyerDTO.CarList.Prise,
            };

            Buyer Buyer = new Buyer
            {
                FirstName = BuyerDTO.FirstName,
                LastName = BuyerDTO.LastName,
                Mony = BuyerDTO.Mony,
                CarList = carList
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.BuyerRepository.Insert(Buyer);
                    unitOfWork.Save();
                }

                //Console.WriteLine(student);
                //ctx.Students.Add(student);
                //ctx.SaveChanges();

                return true;
            }
            catch
            {
                Console.WriteLine(Buyer);
                return false;
            }
        }

        public bool Delete(int id)
        {
            // here the DTO is just an int
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Buyer Buyer = unitOfWork.BuyerRepository.GetByID(id);
                    unitOfWork.BuyerRepository.Delete(Buyer);
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
