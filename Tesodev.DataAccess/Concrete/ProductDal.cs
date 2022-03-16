using Tesodev.Core.DataAccess.EntityFramework;
using Tesodev.DataAccess.Abstract;
using Tesodev.Entites.Concrete;

namespace Tesodev.DataAccess.Concrete
{
    public class ProductDal : EfEntityRepositoryBase<Product, TesodevContext>, IProductDal
    {
    }
}
