using Core.DataAccess;
using Entity.Concrete;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        // Custom Operations
    }   
}
