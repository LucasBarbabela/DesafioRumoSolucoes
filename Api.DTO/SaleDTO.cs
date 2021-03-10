using Api.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.DTO
{
    public class SaleDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public ProcessStatusEnum Status { get; set; }
        public SellerDTO CarSeller { get; set; }
        public List<CarDTO> Cars { get; set; }
    }
}
    