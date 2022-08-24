using Contract.Messaging.Base;
using Contract.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Messaging.User
{
    public class AddUserRequest : BaseApiRequest<AddUserViewModel> { }
    public class DeleteUserRequest : BaseApiRequest<UserIdViewModel> { }
    public class GetAllUsersRequest : BaseApiRequest<GetAllUsersViewModel> { }


}
