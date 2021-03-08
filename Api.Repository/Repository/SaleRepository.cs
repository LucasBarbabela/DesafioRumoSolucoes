using Api.DTO;
using Api.Enum;
using Api.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Repository.Repository
{
    public class SaleRepository : ISaleRepository
    {
        public ActionResult<SaleDTO> SaveVehicleSale(SaleDTO newSale)
        {
            throw new NotImplementedException();
        }

        public ActionResult<SaleDTO> SearchSaleById(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult<SaleDTO> UpdateStatus(int id, ProcessStatusEnum process)
        {
            throw new NotImplementedException();
        }
    }
}
