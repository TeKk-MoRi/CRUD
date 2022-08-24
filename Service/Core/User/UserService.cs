using Datalayer.Context;
using Microsoft.EntityFrameworkCore;
using Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = Domain;

namespace Service.Core.User
{
    public class UserService : BaseService<Entity.Models.User.User>, IUserService
    {
        public UserService(CRUDContext context) : base(context)
        {
        }

        public IQueryable<Entity.Models.User.User> GetAll()
        {
            return Entities;
        }
    }
}
