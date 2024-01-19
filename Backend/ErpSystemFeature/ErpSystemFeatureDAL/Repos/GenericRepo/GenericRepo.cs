using ErpSystemFeatureDAL.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystemFeatureDAL.Repos.GenericRepo
{
    public class GenericRepo<TEntity> :IGenericRepo<TEntity> where TEntity : class
    {
        private readonly AppDbContext dbContext;

        public GenericRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

      

        public List<TEntity> GetAll(int page, int countPerPage)
        {
          return dbContext.Set<TEntity>()
                .Skip((page-1) * countPerPage)
                .Take(countPerPage).ToList();
        }

        public TEntity? GetById(int id) => dbContext.Set<TEntity>().Find(id);
      

        public TEntity Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            return entity;
        }


        public TEntity isUpdated(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
            return entity;
        }

        public TEntity isDeleted(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
            return entity;
        }
    }
}
