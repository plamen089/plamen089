using System;
using Data.Context;
using Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Implementation;
using AppSevice.DTOc;

    class SellarManagementService
    {
        public List<SellarDTO> Get()
        {
            List<SellarDTO> SellarDto = new List<SellarDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.SellarRepository.Get())
                //foreach (var item in ctx.Students.ToList())
                {

                    SellarDto.Add(new SellarDTO
                    {
                        CarListId = item.CarListId,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        PhoneNumber = item.PhoneNumber,
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

            return SellarDto;
        }

        public SellarDTO GetById(int id)
        {
            SellarDTO SellarDTO = new SellarDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Sellar Sellar = unitOfWork.SellarRepository.GetByID(id);
                if (Sellar != null)
                {
                    SellarDTO = new SellarDTO
                    {
                        FirstName = Sellar.FirstName,
                        LastName = Sellar.LastName,
                        PhoneNumber  = Sellar.PhoneNumber, 
                        
                        CarList = new CarListDTO
                        {
                            Id = Sellar.CarListId,
                            Brand = Sellar.CarList.Brand,
                            Model = Sellar.CarList.Model,
                            Years = Sellar.CarList.Years,
                            Description = Sellar.CarList.Description,
                            Prise = Sellar.CarList.Prise
                        }
                    };
                }

            }

            return SellarDTO;
        }

        public bool Save(SellarDTO SellarDTO)
        {
            // either init nationality beforehand or create a check
            if (SellarDTO.CarList == null || SellarDTO.CarList.Id == 0)
            {
                return false;
            }

            // add additional functionality - if there is no such nationality -> create it
            CarList carList = new CarList
            {
                Id = SellarDTO.Id,
                Brand = SellarDTO.CarList.Brand,
                Model = SellarDTO.CarList.Model,
                Years = SellarDTO.CarList.Years,
                Description = SellarDTO.CarList.Description,
                Prise = SellarDTO.CarList.Prise,
            };

            Sellar Sellar = new Sellar
            {
                FirstName = SellarDTO.FirstName,
                LastName = SellarDTO.LastName,
                PhoneNumber = SellarDTO.PhoneNumber,
                CarList = carList
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.SellarRepository.Insert(Sellar);
                    unitOfWork.Save();
                }

                //Console.WriteLine(student);
                //ctx.Students.Add(student);
                //ctx.SaveChanges();

                return true;
            }
            catch
            {
                Console.WriteLine(Sellar);
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
                    Sellar Sellar = unitOfWork.SellarRepository.GetByID(id);
                    unitOfWork.SellarRepository.Delete(Sellar);
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
