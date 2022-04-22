using SalesWebMvc.Models;
using SelesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;

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

        public  async Task< List<Saller>> FindAllAsync()
        { 
            // operação sincrona para busca to os vendedore
            return await _context.Saller.ToListAsync();
        }

         public async Task InsertAsync(Saller obj)
        {
            _context.Add(obj);
           await _context.SaveChangesAsync();
        }

        public  async Task <Saller> FindByIdAsync(int id)
        {
            return  await _context.Saller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
                
        }

         public async Task RemoveAsync(int id)
        {
            var obj = _context.Saller.Find(id);
            _context.Saller.Remove(obj);
            await _context.SaveChangesAsync();

        }

        public async Task   UpdateAsync(Saller obj)
        {
            bool temAlgum = await _context.Saller.AnyAsync(x => x.Id == obj.Id);
            if (!temAlgum)
            {
                throw new NotFoundException("Id not foud");
            }
            try
            {
              _context.Update(obj);
               await  _context.SaveChangesAsync();

            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

    }
}
