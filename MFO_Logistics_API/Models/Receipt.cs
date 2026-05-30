namespace MFO_Logistics_API.Models
{
    public class Receipt
    {
        public int ReceiptId { get; set; }
        public string ReceiptCode { get; set; }
        public string LogisticID { get; set; }
        public string DepositorID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ReceiptStatusID { get; set; }
        public string CreateUserID { get; set; }
        public int Status { get; set; }
    }
}
