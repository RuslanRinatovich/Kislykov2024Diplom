using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrospektivaApp.Entities
{
    public partial class OrderProduct
    {
        public int Total
        {
            get
            {

                return Product.Price * Count;
            }
        }
    }
}