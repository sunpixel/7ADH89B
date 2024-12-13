namespace ContractService
{
    public class Contract
    {
        public int ContractID { get; set; }
        public int UserID { get; set; }
        public string ContractDetails { get; set; }
        public int ProfileUserId { get; set; }
    }
}