
using AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProjectStockLibrary;
using ProjectStockDTOS;
using ApiApplication.Profil.Repository.Interfaces;
using ApiApplication.Model;

namespace ApiApplication.Profil.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T :BaseEntity
    {
        public IMapper _mapper { get; }

        private APIContext SqlContext { get; set; }

        private List<T> _listEntity { get; set; } = new List<T>();


        public GenericRepository(APIContext apiContext)
        {
            SqlContext = apiContext;
        }
   
        public T? Update(T entity)
        {
            if (entity == null)
            {
                return null;
            }

            SqlContext.Set<T>().Update(entity);
            SqlContext.SaveChanges();

            return entity;
        }

        public T Add(T entity)
        {
           
            SqlContext.Set<T>().Add(entity);

            SqlContext.SaveChanges();

            return entity;
        }

        public bool Delete(T entity)
        {
         
            SqlContext.Set<T>().Remove(entity);
            if (SqlContext.SaveChanges() == 1)
            {
                return SqlContext.SaveChanges() == 1;
            }
            return SqlContext.SaveChanges() == 0;
           

        }


        public T GetById(Guid id)
        {
            return SqlContext.Set<T>().Where(element => element.Id == id).FirstOrDefault();
        }


        public List<T> GetAll()
        {
            return SqlContext.Set<T>().ToList();
        }

            
    }
}


