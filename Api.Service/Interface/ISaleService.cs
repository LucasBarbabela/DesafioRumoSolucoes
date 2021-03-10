using Api.DTO;
using Api.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Service.Interface
{
    public interface ISaleService
    {
        public ActionResult<SaleDTO> SearchSaleById(int id);
        public ActionResult<int> SaveVehicleSale(SaleDTO newSale);
        public ActionResult<SaleDTO> UpdateStatus(int id, ProcessStatusEnum process);
    }
}
