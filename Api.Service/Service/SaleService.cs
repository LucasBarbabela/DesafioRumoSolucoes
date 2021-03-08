using Api.DTO;
using Api.Enum;
using Api.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Service.Service
{
    public class SaleService : ISaleService
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
