using SavuDiary.Shared;

namespace SavuDiary.Server.DataLayers
{
    public class SupplierEntity : BaseEntity
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string MobileNo { get; set; } = "";
        public string EmailId { get; set; } = "";

        public static implicit operator SupplierEntity(Supplier customer)
        {
            return new SupplierEntity()
            {
                EmailId = customer.EmailId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                MobileNo = customer.MobileNo,
                Id = customer.Id,
                IsActive = customer.IsActive,
            };
        }

        public static implicit operator Supplier(SupplierEntity customer)
        {
            return new Supplier()
            {
                EmailId = customer.EmailId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                MobileNo = customer.MobileNo,
                Id = customer.Id,
                IsActive = customer.IsActive,
            };
        }
    }
}
