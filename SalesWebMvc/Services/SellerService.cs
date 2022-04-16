﻿using SalesWebMvc.Models;
using SelesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SellerService
    { 
      // quando é usado readonly para previne que essa dependencia não seja alterada 
        private readonly SalesWebMvcContext _context;

         public SellerService (SalesWebMvcContext context)
        {
            _context = context;
        }
        public List<Saller> FindAll()
        { 
            // operação sincrona para busca to os vendedore
            return _context.Saller.ToList();
        }
    }
}