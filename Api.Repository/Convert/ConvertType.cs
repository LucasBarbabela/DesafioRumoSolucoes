using Api.DTO;
using Api.Repository.Model;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Api.Repository.Convert
{
    public static class ConvertType
    {
        public static CarDTO To(Car value)
        {
            return new CarDTO
            {
                Id = value.Id,
                Year = value.Year,
                Type = value.Type,
                Brand = value.Brand,
                Fabrication = value.Fabrication
            };
        }

        public static SellerDTO To(Seller value)
        {
            return new SellerDTO {
                Id = value.Id,
                Cpf = value.Cpf,
                Name = value.Name,
                Email = value.Email,
            };
        }

        public static SaleDTO To(Sale value)
        {
            return new SaleDTO
            {
                Id = value.Id,
                Status = value.Status,
                Date = value.Date,
                Cars = To(value.Cars),
                CarSeller = To(value.CarSeller)
            };
        }

        public static List<CarDTO> To(ICollection<Car> value)
        {
            List <Car> valueList = new List<Car>(value);
            List <CarDTO> returnList = new List<CarDTO>();

            foreach(Car car in valueList)
            {
                returnList.Add(new CarDTO
                {
                    Id = car.Id,
                    Brand = car.Brand,
                    Fabrication = car.Fabrication,
                    Type = car.Fabrication,
                    Year = car.Year
                });
            }

            return returnList;
        }

        public static Sale To(SaleDTO value)
        {
            return new Sale
            {
                Id = value.Id,
                Status = value.Status,
                Date = value.Date,
                Cars = To(value.Cars),
                CarSeller = To(value.CarSeller)
            };
        }
        public static List<Car> To(List<CarDTO> value)
        {
            List<Car> listReturn = new List<Car>();
            
            foreach(CarDTO car in value)
            {
                listReturn.Add(new Car
                {
                    Id = car.Id,
                    Brand = car.Brand,
                    Fabrication = car.Fabrication,
                    Type = car.Type,
                    Year = car.Year
                });
            }

            return listReturn;
        }
        public static Seller To(SellerDTO value)
        {
            return new Seller
            {
                Id = value.Id,
                Cpf = value.Cpf,
                Name = value.Name,
                Email = value.Email,
            };
        }
        public static ICollection<Sale> To(ICollection<SaleDTO> value)
        {
            ICollection<Sale> _return = value.OfType<Sale>().ToList();
            return _return;
        }
    }
}
