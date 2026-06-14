namespace BloodBank.Domain.Common
{
    public interface IBloodInventoryItem
    {
        int Id { get; set; }
        int BloodBankId { get; set; }
        int BloodTypeId { get; set; }
        DateTime ExpirationDate { get; set; }
        bool IsDeleted { get; set; }
    }
}
