using SalesWebMvc.Models;
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
         public void Insert(Saller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public Saller FindById(int id)
        {
            return _context.Saller.FirstOrDefault(obj => obj.Id == id);
        }
         public void Remover(int id)
        {
            var obj = _context.Saller.Find(id);
            _context.Saller.Remove(obj);
            _context.SaveChanges();

        }
        public  void Edit(int id)
        {

        }
    }
}
