
using AutoFixture;
using ProjectStockRepository.Context;
using ProjectStockRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProjectStockLibrary;
using ProjectStockModels;
using ProjectStockModels.JsonReader;
using ProjectStockDTOS;

namespace ProjectStockRepository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        public IMapper _mapper { get; }

        private SqlDbContext SqlContext { get; } = new SqlDbContext();

        private List<T> _listEntity { get; set; } = new List<T>();

   
        public T? Update(T notifentity)
        {



            if (notifentity == null)
            {
                return null;
            }

            SqlContext.Set<T>().Update(notifentity);
            SqlContext.SaveChanges();

            return notifentity;
        }

        public T Add(T entity)
        {
           
            SqlContext.Set<T>().Add(entity);

            _listEntity.Add(entity);
         
            return entity;
        }

        public bool Delete(T entity)
        {
            _listEntity.Remove(entity);
            SqlContext.Set<T>().Remove(entity);
            if (SqlContext.SaveChanges() == 1)
            {
                return SqlContext.SaveChanges() == 1;
            }
            else
            {
                return SqlContext.SaveChanges() == 0;
            }

        }
        public IEnumerable<T>  GetAll()
        {
            return _listEntity;
        }

            
    }
}


