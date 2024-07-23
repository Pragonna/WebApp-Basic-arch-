using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Dtos.ProductDtos
{
    public class ProductUpdateDto
    {
        public string Name { get; set; }
        public ProductAddDto ProductAddDto { get; set; }
    }
}
