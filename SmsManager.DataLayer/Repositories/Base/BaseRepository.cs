using System;
using System.Collections.Generic;
using System.Linq;
using SmsManager.Infrastructure.Entities;
using SmsManager.Infrastructure.Entities.Dto;
using SmsManager.Infrastructure.IRepositories;
namespace SmsManager.DataLayer.Repositories.Base
{
    public abstract class BaseRepository<Entity, Dto> 
        where Entity : class,IDetail,new()
        where Dto : IDto, new()
    {
        protected ISmsDataContext _store;
        public delegate void ChangeHandler(Dto story);
        public event ChangeHandler OnChange;

        protected BaseRepository(ISmsDataContext store)
        {
            _store = store;
        }

        public IEnumerable<Dto> GetAll()
        {
       
            return ConvertColl(_store.GetTable<Entity>().ToList());
        }

        public Dto GetItem(long id)
        {
            Entity item = _store.GetTable<Entity>().FirstOrDefault(x=>x.Id==id);
            return Convert(item);

        }

        public void InsertOrUpdateRange(IEnumerable<Dto> items)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(Dto dto)
        {

            var updatedOrSavedEntity = _store.GetTable<Entity>().FirstOrDefault(x => x.Id.Equals(dto.Id));
            if (updatedOrSavedEntity != null)
            {
                UpdateEntry(dto, updatedOrSavedEntity);
                if (OnChange != null)
                {
                    OnChange(dto);
                }
            }
            else
            {
                updatedOrSavedEntity = CreateEntry(dto);
                _store.GetTable<Entity>().InsertOnSubmit(updatedOrSavedEntity);
            }

            dto.Id = updatedOrSavedEntity.Id;
            _store.SubmitChanges();
        }

        public void Delete(Dto dto)
        {
            var item = _store.GetTable<Entity>().FirstOrDefault(x => x.Id == dto.Id);
            _store.GetTable<Entity>().DeleteOnSubmit(item);
            _store.SubmitChanges();
        }


        public abstract IEnumerable<Dto> Search(string pattern);
        public abstract Entity UpdateEntry(Dto sourceDto, Entity targetEntity);
        public abstract Entity CreateEntry(Dto dto);

        protected IEnumerable<Dto> ConvertColl(IEnumerable<Entity> entities)
        {

            foreach (var entity in entities)
            {
                yield return Convert(entity);
            }
        }

        public abstract Dto Convert(Entity entity);

        public void Insert(Dto dto)
        {
            var insertedEntity = CreateEntry(dto);
            _store.GetTable<Entity>().InsertOnSubmit(insertedEntity);
            _store.SubmitChanges();
        }

    }
}
