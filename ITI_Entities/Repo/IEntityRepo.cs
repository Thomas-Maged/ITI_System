using System;
using System.Collections.Generic;
using System.Text;

namespace ITI_Entities.Repo
{
    public interface IEntityRepo<T>
    {
        List<T> GetAll();
        T GetByID(int id);
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);
    }
}
