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
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public ProcessStatusEnum Status { get; set; }
        [Required]
        public Seller CarSeller { get; set; }
        [Required]
        public ICollection<Car> Cars { get; set; }
    }
}
