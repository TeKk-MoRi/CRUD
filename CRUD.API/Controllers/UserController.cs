using Contract.Command.User;
using Contract.Messaging.User;
using Contract.Query;
using Contract.ViewModels.User;
using CRUD.API.Extension;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> GetAllUsers(GetAllUsersViewModel model)
        {
            var res = await _mediator.Send(new GetAllUsersQuery(new GetAllUsersRequest { ViewModel = model }));

            return Response(res);
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel model)
        {
            var res = await _mediator.Send(new AddUserCommand(new AddUserRequest { ViewModel = model }));

            return Response(res);
        }

        [HttpPost]

        public async Task<IActionResult> DeleteUser(UserIdViewModel model)
        {
            var res = await _mediator.Send(new DeleteUserCommand(new DeleteUserRequest { ViewModel = model }));

            return Response(res);
        }

    }
}
