using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XGames.Data;
using XGames.DTModels;
using XGames.Models;
using XGames.Repositories.RepositoryInterfaces;

namespace XGames.Repositories
{
    public class BaseRepository<T>: IBaseRepository<T> where T:BaseModel
    {

       private readonly XGamesContext _context;

            public BaseRepository(XGamesContext context) {
            _context = context;
        }


        protected XGamesContext getDatabaseContext() { return _context; }


        public DbSet<T> GetAllAsSet() {
            return _context.Set<T>();
        }

        
        public async Task<T> GetById(int id)
        {

            var entity = await _context.FindAsync<T>(  id );

            if (entity == null)
            {
                throw new KeyNotFoundException();
            }

            return entity;
        }


    
        public async Task<T> Create( T entity)
        {
                var entityReturned = _context.Add<T>(entity);
                 _context.SaveChanges();
                return entityReturned.Entity;
            }
          
        
       
        public async Task<T> Update(int id,T entity) 
        {
            T entityToReturn;
            if (id != entity.ID)
            {
                throw new KeyNotFoundException();
            }

            if (entity != null)
            {
                try
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return null;
                    
                    if (!EntityExists(entity.ID))
                    {
                        throw new KeyNotFoundException();
                    }
                    else
                    {
                        throw;
                    }
                }
                return entity;
            }
            else {
                throw new NullReferenceException();
            }
        }

     
      
        public async Task<bool> Delete(int id)
        {
            
            try
            {
                var entity = await _context.FindAsync<T>(id);
                _context.Remove<T>(entity);
                _context.SaveChanges();
                return true;
            }
            //--exception suppressed and value returned as false
            catch (Exception exe) { return false; }
          
        }

        public bool EntityExists(int id)
        {
            return _context.Find<T>( id ) !=null;
        }


        public bool EntityChanged(T entity)
        {

            return getDatabaseContext().Entry(entity).State == EntityState.Modified;
        }


        public async Task<PaginatedList<T>> GetAllPaged(int ?pageSize,int? pageIndex) {

            PaginatedList<T> paginatedList;
            if (pageSize == null || pageIndex == null)
                paginatedList =await PaginatedList<T>.CreateAsync(getDatabaseContext().Set<T>().AsNoTracking<T>());
            else
                paginatedList = await PaginatedList<T>.CreateAsync(
                getDatabaseContext().Set<T>().AsNoTracking<T>(),
               pageSize ?? PaginatedList<T>.DEFAULT_PAGE_SIZE,
                pageIndex ?? PaginatedList<T>.DEFAULT_PAGE_INDEX);

            return paginatedList;
        }

    }
}
