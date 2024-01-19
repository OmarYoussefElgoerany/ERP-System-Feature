using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystemFeatureDAL.Repos.GenericRepo
{
    public interface IGenericRepo<TEntity> where TEntity : class
    {
        List<TEntity> GetAll(int page, int countPerPage);

        TEntity? GetById(int id);

        TEntity Add(TEntity entity);

        TEntity isUpdated(TEntity entity);

        TEntity isDeleted(TEntity entity);
    }
}
