using AutoMapper;
using Contract.Command.User;
using Contract.Messaging.User;
using Contract.Query;
using Contract.ViewModels.User;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Service.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Handle.User
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, GetAllUsersResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public GetAllUsersHandler(IUserService userService, IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;
        }
        public async Task<GetAllUsersResponse> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            GetAllUsersResponse response = new();

            try
            {
                int take = request.Request.ViewModel.Take;
                int skip = (request.Request.ViewModel.pageId - 1) * take;
                var users = _userService.GetAll();
                int userCount = users.Count();
                int pageCount = userCount / take;
                if (userCount % take != 0)
                {
                    pageCount++;
                }
                var result = await users.OrderByDescending(x => x.Id).Skip(skip).Take(take).ToListAsync();
                var res = _mapper.Map<List<UserViewModel>>(result);
                response.PageCount = pageCount;
                response.Result = res;
                response.Succeed();
            }
            catch (Exception e)
            {
                response.Failed();
                response.FailedMessage();
                response.FailedMessage(e.Message);
            }

            return response;
        }
    }
}
