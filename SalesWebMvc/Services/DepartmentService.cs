using SalesWebMvc.Models;
using SelesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        // quando é usado readonly para previne que essa dependencia não seja alterada 
        private readonly SalesWebMvcContext _context;

        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }
        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x=> x.Nome).ToListAsync();
        }
    }
}
