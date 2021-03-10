using Api.DTO;
using Api.Enum;
using Api.Repository.Interface;
using Api.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Service.Service
{
    public class SaleService : ISaleService
    {

        private readonly ISaleRepository _repository;

        public SaleService(ISaleRepository repository)
        {
            this._repository = repository;
        }

        public ActionResult<SaleDTO> SearchSaleById(int id)
        {
            return this._repository.SearchSaleById(id);
        }
        public ActionResult<int> SaveVehicleSale(SaleDTO newSale)
        {
            return this._repository.SaveVehicleSale(newSale);
        }

        public ActionResult<SaleDTO> UpdateStatus(int id, ProcessStatusEnum process)
        {
            return this._repository.UpdateStatus(id, process);
        }

        public void CreateMock()
        {
            this._repository.CreateMock();
        }
    }
}
