using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Saller> Saller{ get; set; }= new List<Saller>();

        public Department()
        {
        }

        public Department(string nome)
        {
            Nome = nome;
        }

        public Department(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
        public void AddSaller(Saller saller)
        {
            Saller.Add(saller);
        }
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Saller.Sum(saller => saller.TotalSales(initial, final));
        }
    }
}
