using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : IRentalDal
    {
        public void Add(Rental entity)
        {
            using (RentaCarContext context=new RentaCarContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Rental entity)
        {
            using (RentaCarContext context=new RentaCarContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }


        public void Update(Rental entity)
        {
            using (RentaCarContext context=new RentaCarContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public Rental Get(Expression<Func<Rental, bool>> filter)
        {
            using (RentaCarContext context=new RentaCarContext())
            {
                return context.Set<Rental>().FirstOrDefault(filter);
            }
        }

        public List<Rental> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentaCarContext context=new RentaCarContext())
            {
                return filter == null ? context.Set<Rental>().ToList() : context.Set<Rental>().Where(filter).ToList();
            }
        }
    }
}