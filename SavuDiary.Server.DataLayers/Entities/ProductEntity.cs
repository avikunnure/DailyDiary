using SavuDiary.Shared;

namespace SavuDiary.Server.DataLayers
{
    public class ProductEntity:BaseEntity
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Code { get; set; } = "";
        public string Unit { get; set; } = "";

        public static implicit operator ProductEntity(Product products)
        {
            return new ProductEntity()
            {
                Code = products.Code,
                Unit = products.Unit,
                Name = products.Name,
                Description = products.Description,
                Id = products.Id,
            };
        }
        public static implicit operator Product(ProductEntity product)
        {
            return new Product()
            {
                Name = product.Name,
                Unit = product.Unit,
                Description = product.Description,
                Code = product.Code,
                Id = product.Id,
            };
        }
    }
}
