using SalesWebMvc.Models.Enums;
using System;

namespace SalesWebMvc.Models
{
    public class SalesRecord 
    {
        public int Id { get; set; }
        public DateTime Data  { get; set; }
        public double Amount { get; set; }
        public SaleStatus Status { get; set;}
        public Saller Saller{ get; set; }

        public SalesRecord()
        {
        }

        public SalesRecord(DateTime data, double amount, SaleStatus status, Saller saller)
        {
            Data = data;
            Amount = amount;
            Status = status;
            Saller = saller;
        }

        public SalesRecord(int id, DateTime data, double amount, SaleStatus status, Saller saller)
        {
            Id = id;
            Data = data;
            Amount = amount;
            Status = status;
            Saller = saller;
        }
    }
}
