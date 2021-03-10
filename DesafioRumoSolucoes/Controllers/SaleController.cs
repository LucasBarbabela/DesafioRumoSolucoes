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
        public ActionResult Create([FromBody] SaleDTO newSale)
        {
            this._service.SaveVehicleSale(newSale);
            return Ok();
        }

        [HttpPut]
        public ActionResult<SaleDTO> Update(int id, ProcessStatusEnum process)
        {
            return this._service.UpdateStatus(id, process);
        }
    }
}
