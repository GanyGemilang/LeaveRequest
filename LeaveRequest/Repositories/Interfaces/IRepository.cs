using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequest.Repositories.Interfaces
{
    public interface IRepository<Entity> where Entity : class
    {
        IEnumerable<Entity> Get();
        Entity Get(int id);
        int Create(Entity entity);
        int Update(int id, Entity entity);
        int Delete(int id);
    }
}
