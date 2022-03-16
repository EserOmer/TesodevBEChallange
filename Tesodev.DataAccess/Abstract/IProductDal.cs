using System;
using System.Collections.Generic;
using System.Text;
using Tesodev.Core.DataAccess;
using Tesodev.Entites.Concrete;

namespace Tesodev.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
    }
}
