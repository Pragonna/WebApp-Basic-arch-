using Core.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Entities
{
    public class OperationClaim : BaseEntity
    {
        // OperationClaim is users role 
        public string Name { get; set; }
        public OperationClaim(int id,string name):base(id)
        {
            Name = name;
        }

    }
}
