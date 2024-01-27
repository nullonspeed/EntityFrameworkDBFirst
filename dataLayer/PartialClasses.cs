using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataLayer
{
    public partial class Supplier
    {
        public override string ToString()
        {
            return CompanyName;
        }
    }
    public partial class Product
    {
        public override string ToString()
        {
            return ProductName;
        }
    }
    public partial class Customer
    {
        public override string ToString()
        {
            return ContactName;
        }
    }
}
