using AutoMapper;
using Contract.Command.User;
using Contract.Messaging.User;
using Contract.ViewModels.User;
using Domain.Models.User;
using MediatR;
using Service.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Handle.User
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, AddUserResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public AddUserHandler(IUserService userService, IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;
        }
        public async Task<AddUserResponse> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            AddUserResponse response = new();
            try
            {

                //Create ASP User
                var user = _mapper.Map<Domain.Models.User.User>(request.Request.ViewModel);
                var res = await _userService.AddAndSaveAsync(user);

                if (res is null)
                {
                    response.Failed();
                    response.FailedMessage("Application user Registration failed!");
                    return response;
                }
                //if everything goes well then...
                response.Result = true;
                response.Succeed();
                response.SuccessMessage();
                return response;

            }
            catch (System.Exception ex)
            {
                response.Failed();
                response.FailedMessage();
                response.FailedMessage(ex.Message);
                return response;
            }
        }
    }
}
