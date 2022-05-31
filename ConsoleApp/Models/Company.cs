using System;
using System.Collections.Generic;

namespace ConsoleApp.Models
{
    public class Company
    {
       
        public int CompanyId { get; set; }
      
        public string Number { get; set; }
      
        public string Subject { get; set; }
      
        public string Type { get; set; }

        public DateTime Date { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        
        public string Summary { get; set; }
        public IList<Contract> Contracts { get; set; }

    }
}
