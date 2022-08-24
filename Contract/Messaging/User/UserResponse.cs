using Contract.Messaging.Base;
using Contract.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Messaging.User
{
    public class AddUserResponse : BaseApiResponse<bool> { }
    public class DeleteUserResponse : BaseApiResponse<bool> { }
    public class GetAllUsersResponse : BaseApiResponse<List<UserViewModel>> 
    {
        public int PageCount { get; set; }
    }
}
