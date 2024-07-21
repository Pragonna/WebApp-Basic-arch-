using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities.Commons
{
    public class BaseEntity
    {
        public int Id{ get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; } = null;
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
        }
        public BaseEntity(int id):this()
        {
            Id=id;
        }

    }
}
