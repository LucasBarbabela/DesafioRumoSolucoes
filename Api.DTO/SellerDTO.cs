using System;
using System.Collections.Generic;
using System.Text;

namespace Api.DTO
{
    public class SellerDTO
    {
        public int Id { get; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public ICollection<SaleDTO> Sales { get; set; }
    }
}
