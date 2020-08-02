using System;
using System.Linq;
using System.Collections.Generic;

namespace SalesWebMvc.Models
{
   public class Department
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

      public Department()        // Esse construtor vazio só éÉ obrigatório porque também 
      {                          // existirá um construtor com argumentos
      }

      public Department(int id, string name)
      {
         Id = id;                // Não devem ser incluídos no construtor as coleções. Dessa forma,
         Name = name;            // a coleção Sellers não fará parte desse construtor
      }

      public void AddSeller(Seller seller)
      {
         Sellers.Add(seller);
      }

      public double TotalSales(DateTime initial, DateTime final)
      {
         return Sellers.Sum(seller => seller.TotalSales(initial, final));
      }
   }
}
