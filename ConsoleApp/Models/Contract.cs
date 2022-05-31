namespace ConsoleApp.Models
{
    public class Contract
    {       
        public int ContractId { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
       
        public string Fax { get; set; }
       
        public string Address { get; set; }
       
        public string Website { get; set; }
       
        public string Remarks { get; set; }
        
        public string EconomicCode { get; set; }
       
        public string NationalCode { get; set; }
      
        public string RegisterNumber { get; set; }
     
        public string PostCode { get; set; }
        public Company company { get; set; }

    }
}
