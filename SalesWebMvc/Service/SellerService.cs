using SalesWebMvc.Models;
using SelesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Service
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;
         public SellerService (SalesWebMvcContext context)
        {
            _context = context;
        }
        public List<Saller> FindAll()
        { // operação assicrona
            return _context.Saller.ToList();
        }
    }
}
