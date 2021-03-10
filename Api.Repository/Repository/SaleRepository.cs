using Api.DTO;
using Api.Enum;
using Api.Repository.Configurations;
using Api.Repository.Interface;
using Api.Repository.Model;
using Api.Utility.Exception;
using Api.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Api.Repository.Convert;
using System.ComponentModel.Design;

namespace Api.Repository.Repository
{
    public class SaleRepository : ISaleRepository
    {
        public static int count = 0;
        ApiResponse _apiResponse = null;
        private Sale _response;
        private readonly CarDealershipContext _context;

        public SaleRepository(CarDealershipContext context)
        {
            this._context = context;
            this._apiResponse = new ApiResponse();


            this.Mock();
        }

        public void Dispose()
        {
            if (_apiResponse != null)
            {
                _apiResponse = null;
            }
            if (_response != null)
            {
                _response = new Sale();
            }
        }

        public ActionResult<SaleDTO> SearchSaleById(int id)
        {
            try {
            Functions.IdIsValid(id);
            _response = this._context.Sale.SingleOrDefault(x => x.Id == 1);

            if (_response == null)
                throw new ApiException(StatusCodeEnum.NoContent, MsgException.SaleNotFound);

                var a = ConvertType.To(_response);
            return _apiResponse.ResponseRet<SaleDTO>(StatusCodeEnum.OK, ConvertType.To(_response));
            } 
            catch (ApiException e)
            {
                return _apiResponse.ResponseRet<SaleDTO>(e);
            }
            catch (Exception e)
            {
                throw new Exception();
                return _apiResponse.ResponseRetWithoutEnumerable(e);
            }
        }

        public ActionResult<int> SaveVehicleSale(SaleDTO newSale)
        {
            try 
            {
                if (Functions.IsAnyNullOrEmpty(newSale))
                    new ApiException(StatusCodeEnum.BadRequest, MsgException.ObjectAtributeNull);

                _context.Sale.Add(ConvertType.To(newSale));
                _context.SaveChanges();

                return _apiResponse.ResponseRet<int>(StatusCodeEnum.OK, newSale.Id);
            }
            catch (ApiException e)
            {
                return _apiResponse.ResponseRet<int>(e);
            }
            catch (Exception e)
            {
                return _apiResponse.ResponseRetWithoutEnumerable(e);
            }
        }

        public ActionResult<SaleDTO> UpdateStatus(int id, ProcessStatusEnum process)
        {
            throw new NotImplementedException();
        }

        public void Mock()
        {
            List<Car> listCar = new List<Car>();

            Seller seller = new Seller
            {
                Cpf = "cpf",
                Email = "Email",
                Name = "nome",
            };
            _context.Seller.Add(seller);
            this._context.SaveChanges();

            for (int i = 1; i <= 10; i++)
            {

                Car car = new Car
                {
                    Brand = "marca" + i.ToString(),
                    Fabrication = "fabricacao" + i.ToString(),
                    Type = "tipo" + i.ToString(),
                    Year = 2000 + i
                };
                this._context.Car.Add(car);
                this._context.SaveChanges();

                var a = this._context.Car.ToList();
                var b = _context.Car.SingleOrDefault(x => x.Id == i);

                listCar.Add(_context.Car.SingleOrDefault(x => x.Id == i));
                Sale sale = new Sale
                {
                    Cars = listCar,
                    Date = DateTime.Now,
                    Status = ProcessStatusEnum.Approved,
                    CarSeller = _context.Seller.SingleOrDefault(x => x.Id == 1)
                };
                this._context.Sale.Add(sale);
                this._context.SaveChanges();

                listCar = new List<Car>();
            }
        }
    }
}
