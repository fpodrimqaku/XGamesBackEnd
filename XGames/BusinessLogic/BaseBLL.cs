﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XGames.BusinessLogic.BusinessLogicInterfaces;
using XGames.Data;
using XGames.Models;
using XGames.Repositories;
using XGames.Repositories.RepositoryInterfaces;

namespace XGames.BusinessLogic
{
    public class BaseBLL<T> : IBaseBLL<T> where T: BaseModel
    {
        
        private readonly IBaseRepository<T> BaseRepository;

        public BaseBLL([FromServices]IBaseRepository<T> _baseRepository) {
            this.BaseRepository = _baseRepository;
        }

        public List<T> GetAll()
        {
            return BaseRepository.GetAllAsSet().ToList();
        }


       public async Task<T> GetById(int id)
       {

            T entity;

           if (id < 1)
           {
               throw new KeyNotFoundException();
           }
                entity = await BaseRepository.GetById(id);
           return entity;
       }



        public async Task<T> Create(T entity)
        {
            if (entity == null) {
                throw new ArgumentNullException();
            }

            var entityReturned = await BaseRepository.Create(entity);
            return entityReturned;
        }



        public async Task<T> Update(int id, T entity)
        {
            T EntityToReturn;
            if (id < 1)
            {
                throw new ArgumentException("Id of object to be updated ranged below 1. Values Allowed are =>1");
            }
            else if (entity == null) {
                throw new ArgumentNullException("Entity passed to be updated cannot be null");
            }
                try
                {
                    EntityToReturn = await BaseRepository.Update(id, entity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                catch (KeyNotFoundException knfe) {
                    throw;
                }
                return EntityToReturn;

        }



       public async Task<bool> Delete(int id)
       {
            if (id < 1) {
                throw new ArgumentException("Id of object to be deleted ranged below 1. Values Allowed are =>1");
            }
            return await BaseRepository.Delete(id);
           
       }

       public bool EntityExists(int id)
       {
            return BaseRepository.EntityExists(id);
       }

        public bool EntityChanged(T entity) {
            if (entity == null)
                return false;

            return BaseRepository.EntityChanged(entity);
        }

    }
}
