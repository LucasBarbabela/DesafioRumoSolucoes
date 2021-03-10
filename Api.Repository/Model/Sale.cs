using Api.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repository.Model
{
    public class Sale
    {
        public Sale()
        {
            this.Cars = new List<Car>();
            this.CarSeller = new Seller();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public ProcessStatusEnum Status { get; set; }
        [Required]
        public Seller CarSeller { get; set; }
        public virtual List<Car> Cars { get; set; }

    }
}
