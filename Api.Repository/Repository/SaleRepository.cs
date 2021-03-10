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
using Microsoft.EntityFrameworkCore;

namespace Api.Repository.Repository
{
    public class SaleRepository : ISaleRepository
    {
        ApiResponse _apiResponse = null;
        private Sale _response;
        private readonly CarDealershipContext _context;

        public SaleRepository(CarDealershipContext context)
        {
            this._context = context;
            this._apiResponse = new ApiResponse();
        }

        public ActionResult<SaleDTO> SearchSaleById(int id)
        {
            try
            {
                Functions.IdIsValid(id);    
                var query = from s in _context.Sale.Include(a => a.Cars).Include(b => b.CarSeller) select s;
                _response = query.SingleOrDefault(x => x.Id == id);

                if (_response == null)
                    throw new ApiException(StatusCodeEnum.NoContent, MsgException.SaleNotFound);

                return _apiResponse.ResponseRet<SaleDTO>(StatusCodeEnum.OK, ConvertType.To(_response));
            }
            catch (ApiException e)
            {
                return _apiResponse.ResponseRet<SaleDTO>(e);
            }
            catch (Exception e)
            {
                return _apiResponse.ResponseRetWithoutEnumerable(e);
            }
        }

        public ActionResult<int> SaveVehicleSale(SaleDTO newSaleDTO)
        {
            try
            {
                newSaleDTO.Id = 0;
                newSaleDTO.Status = ProcessStatusEnum.ConfirmingPayment;
                List<int> idList;
                Sale newSale;

                if (Functions.IsAnyNullOrEmpty(newSaleDTO))
                    new ApiException(StatusCodeEnum.BadRequest, MsgException.ObjectAtributeNull);

                idList = new List<int>(Functions.IdExtract(newSaleDTO.Cars));
                newSale = ConvertType.To(newSaleDTO);
                newSale.Cars = GetCarList(idList);
                _context.Sale.Add(newSale);
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
            Sale sale = _context.Sale.SingleOrDefault(x => x.Id == id);

            if(Functions.StatusProgress(sale.Status, process))
            {
                sale.Status = process;
            }
            _context.SaveChanges();
            return _apiResponse.ResponseRet<SaleDTO>(StatusCodeEnum.OK,ConvertType.To(sale));
        }

        public List<Car> GetCarList(List<int> ids)
        {
            List<Car> returnList = new List<Car>();
            foreach (int id in ids)
            {
                Car aux = _context.Car.SingleOrDefault(x => x.Id == id);
                if (aux == null)
                    throw new ApiException(StatusCodeEnum.BadRequest, MsgException.CarIdNotFound);
                else
                returnList.Add(aux);
            }
            return returnList;
        }

        public void CreateMock()
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

            for (int i = 1; i <= 3; i++)
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


                Sale sale = new Sale
                {
                    Date = DateTime.Now,
                    Status = ProcessStatusEnum.ConfirmingPayment,
                    CarSeller = _context.Seller.SingleOrDefault(x => x.Id == 1)
                };
                sale.Cars.Add(_context.Car.SingleOrDefault(x => x.Id == i));
                this._context.Sale.Add(sale);
                this._context.SaveChanges();
            }
        }
    }
}
