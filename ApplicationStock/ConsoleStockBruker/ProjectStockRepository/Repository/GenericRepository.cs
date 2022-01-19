
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

        private SqlDbContext SqlContext { get; }

        private List<T> _listEntity { get; set; }

        private readonly Fixture _fixture = new Fixture();


        public GenericRepository()
        {
            SqlContext = new SqlDbContext();
            _listEntity = new List<T>();
            // var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(WPF_Application.App)));
            //_mapper = new Mapper(configuration);
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
            //T _entity = SqlContext.Add(entity).Entity;


            SqlContext.Set<T>().Add(entity);

            _listEntity.Add(entity);
            //SqlContext.SaveChanges();
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


