using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]        
        public int Id { get; set; }
        public DateTime CreateAt { get; private set; } = DateTime.Now;
        public DateTime? UpdateAt { get; private set; }
        public DateTime? DeleteAt { get; private set; }
    }
}
