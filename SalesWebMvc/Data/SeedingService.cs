using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SelesWebMvc.Models;
using SalesWebMvc.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _contect;
        private int _iD;

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get => _iD; set => _iD = value; }

        public SeedingService(SalesWebMvcContext contect)
        {
            _contect = contect;
        }
        public void Seed()
        { // (verificar se existem os elementos o banco de daddos)
            if (_contect.Department.Any() ||
               _contect.Saller.Any() ||
               _contect.SalesRecords.Any()
               )


            {
                return; // DB ja foi populado
            }

            Department d1 = new Department("Computers");
            Department d2 = new Department("Eletronics");
            Department d3 = new Department( "Fashion");
            Department d4 = new Department( "Books");
            Department d5 = new Department( "Acessorios");

            Saller s1 = new Saller( "Dhosef Rafael", "dhose.raf@gmail.com", new DateTime(2009, 2, 26), 1600.0, d4);
            Saller s2 = new Saller("Davi Rafael", "david.raf@gmail.com", new DateTime(2007, 10, 4), 1600, d1);
            Saller s3 = new Saller("Eliane Silva", "eliane.silva@gmail.com", new DateTime(1959, 11, 3), 1200.0, d3);
            Saller s4 = new Saller( "Manoel Filho", "Manoelfilho@gmail.com", new DateTime(1953, 3, 7), 1800.0, d2);
            Saller s5 = new Saller("Eduardo Silva", "eduardo.silva@gmail.com", new DateTime(1976, 2, 18), 2200.0, d2);
            Saller s6 = new Saller ("Alex Pink", "alexpink@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2);

            SalesRecord r1 = new SalesRecord( new DateTime(2021, 09, 25), 11000.0, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord( new DateTime(2021, 09, 25), 11000.0, SaleStatus.Billed, s1);
            SalesRecord r3 = new SalesRecord( new DateTime(2021, 09, 25), 11000.0, SaleStatus.Billed, s1);
            SalesRecord r4 = new SalesRecord( new DateTime(2021, 09, 25), 11000.0, SaleStatus.Billed, s1);
            SalesRecord r5 = new SalesRecord( new DateTime(2021, 09, 25), 11000.0, SaleStatus.Billed, s1);
            SalesRecord r6 = new SalesRecord( new DateTime(2018, 09, 15), 2000.0, SaleStatus.Billed, s1);
            SalesRecord r7 = new SalesRecord( new DateTime(2018, 09, 28), 13000.0, SaleStatus.Billed, s2);
            SalesRecord r8 = new SalesRecord( new DateTime(2018, 09, 11), 4000.0, SaleStatus.Billed, s4);
            SalesRecord r9 = new SalesRecord( new DateTime(2018, 09, 14), 11000.0, SaleStatus.Billed, s6);
            SalesRecord r10 = new SalesRecord(new DateTime(2018, 09, 7), 9000.0, SaleStatus.Billed, s6);
            SalesRecord r11 = new SalesRecord(new DateTime(2018, 09, 13), 6000.0, SaleStatus.Billed, s2);
            SalesRecord r12 = new SalesRecord(new DateTime(2018, 09, 25), 7000.0, SaleStatus.Billed, s3);
            SalesRecord r13 = new SalesRecord(new DateTime(2018, 09, 29), 10000.0, SaleStatus.Billed, s4);
            SalesRecord r14 = new SalesRecord(new DateTime(2018, 09, 4), 3000.0, SaleStatus.Billed, s5);
            SalesRecord r15 = new SalesRecord(new DateTime(2018, 09, 12), 4000.0, SaleStatus.Billed, s1);
            SalesRecord r16 = new SalesRecord(new DateTime(2018, 10, 5), 2000.0, SaleStatus.Billed, s4);
            SalesRecord r17 = new SalesRecord(new DateTime(2018, 10, 1), 12000.0, SaleStatus.Billed, s1);
            SalesRecord r18 = new SalesRecord(new DateTime(2018, 10, 24), 6000.0, SaleStatus.Billed, s3);
            SalesRecord r19 = new SalesRecord(new DateTime(2018, 10, 22), 8000.0, SaleStatus.Billed, s5);
            SalesRecord r20 = new SalesRecord(new DateTime(2018, 10, 15), 8000.0, SaleStatus.Billed, s6);
            SalesRecord r21 = new SalesRecord(new DateTime(2018, 10, 17), 9000.0, SaleStatus.Billed, s2);
            SalesRecord r22 = new SalesRecord(new DateTime(2018, 10, 24), 4000.0, SaleStatus.Billed, s2);
            SalesRecord r23 = new SalesRecord(new DateTime(2018, 10, 12), 8000.0, SaleStatus.Billed, s5);
            SalesRecord r24 = new SalesRecord(new DateTime(2018, 10, 31), 7000.0, SaleStatus.Billed, s3);
            SalesRecord r25 = new SalesRecord(new DateTime(2018, 10, 18), 10000.0, SaleStatus.Billed, s1);


            _contect.Department.AddRangeAsync(d1, d2, d3, d4,d5);
            _contect.Saller.AddRange(s1, s2, s3, s4, s5, s6);

            _contect.SalesRecords.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13,
              r14, r15, r16, r17, r18, r19, r20, r21, r22, r23, r24, r25

                );

            _contect.SaveChanges();
        }

    }
}
