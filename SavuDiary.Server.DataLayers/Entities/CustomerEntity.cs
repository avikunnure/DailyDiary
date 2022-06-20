using SavuDiary.Shared;

namespace SavuDiary.Server.DataLayers
{
    public class CustomerEntity : BaseEntity
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string MobileNo { get; set; } = "";
        public string EmailId { get; set; } = "";
        public long SequenceNo { get; set; }

        public static implicit operator CustomerEntity(Customer customer)
        {
            return new CustomerEntity()
            {
                EmailId = customer.EmailId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                MobileNo = customer.MobileNo,
                Id = customer.Id,
                SequenceNo = customer.SequenceNo,
                IsActive = customer.IsActive,
            };
        }

        public static implicit operator Customer(CustomerEntity customer)
        {
            return new Customer()
            {
                EmailId = customer.EmailId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                MobileNo = customer.MobileNo,
                Id = customer.Id,
                SequenceNo = customer.SequenceNo,
                IsActive = customer.IsActive,
            };
        }
    }
}
