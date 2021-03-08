using System;
using System.Collections.Generic;
using System.Text;

namespace Api.DTO
{
    public class CarDTO
    {
        public int Id { get; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Fabricacao { get; set; }
    }
}
