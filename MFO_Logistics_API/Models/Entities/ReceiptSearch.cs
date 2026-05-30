namespace MFO_Logistics_API.Models.Entities
{
    public class ReceiptSearch
    {
        public int ReceiptId { get; set; }
        public string ReceiptCode { get; set; }
        public string LogisticName { get; set; }
        public string DepositorName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ReceiptStatusName { get; set; }
        public string CreateUser { get; set; }
    }
}
