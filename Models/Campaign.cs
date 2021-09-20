using System;

namespace Assignment.Models
{
    public class Campaign
    {
        public string Code { get; set; }
        public string CategoryId { get; set; }
        public string Location { get; set; }
        public string NgoCode { get; set; }
        public string NgoName { get; set; }
        public string Title { get; set; }
        public bool Featured { get; set; }
        public int Priority { get; set; }
        public int DaysLeft { get; set; }
        public decimal Percentage { get; set; }
        public string ShortDesc { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal ProcuredAmount { get; set; }
        public decimal TotalProcured { get; set; }
        public decimal BackersCount { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Created { get; set; }
    }
}
