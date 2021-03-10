using Api.DTO;
using Api.Enum;
using Api.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioRumoSolucoes.Controllers
{
    [ApiController]
    [Route("API/v1/[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _service;

        public SaleController(ISaleService service)
        {
            this._service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<SaleDTO> Get([FromRoute] int id)
        {
            return this._service.SearchSaleById(id);
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult<int> Create([FromBody] SaleDTO newSale)
        {
            return this._service.SaveVehicleSale(newSale);
        }

        [HttpGet]
        [Route("CreateMock")]
        public void CreateMock()
        {
            this._service.CreateMock();
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult<SaleDTO> Update([FromBody] UpdateStatusDTO newStatus)
        {
            //return this._service.UpdateStatus(newStatus.Id, newStatus.Process);
            newStatus.Id += 1;
            return null;
        }
    }
}
