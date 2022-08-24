using AutoMapper;
using Contract.ViewModels.User;
using Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Mapping.User
{
    public class UserMapprofile : Profile
    {
        public UserMapprofile()
        {
            CreateMap<Domain.Models.User.User, UserViewModel>().ReverseMap();
            CreateMap<Domain.Models.User.User, AddUserViewModel>().ReverseMap();
        }
    }
}
