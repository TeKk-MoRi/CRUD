using Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = Domain;

namespace Service.Core.User
{
    public interface IUserService : IBaseService<Entity.Models.User.User>
    {
       IQueryable<Entity.Models.User.User> GetAll();
    }
}
