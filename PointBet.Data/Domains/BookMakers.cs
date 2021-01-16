using Common.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointBet.Data.Domains
{
    public class BookMakers : EntityBase
    {   
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
