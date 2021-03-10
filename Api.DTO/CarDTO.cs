using System;
using System.Collections.Generic;
using System.Text;

namespace Api.DTO
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
        public string Fabrication { get; set; }
    }
}
