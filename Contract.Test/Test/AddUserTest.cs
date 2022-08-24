using AutoMapper;
using Contract.Command.User;
using Contract.ViewModels.User;
using Moq;
using Service.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Contract.Test.Model.UserModelTest;

namespace Contract.Test.Test
{
    public class AddUserTest
    {
        private Mock<IUserService> _service;
        private IMapper _mapper;
        public AddUserTest()
        {
            _service = new Mock<IUserService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.CreateMap<Domain.Models.User.User, AddUserViewModel>().ReverseMap();
            });

            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;

        }

        [Theory]
        [ClassData(typeof(UserModelRequestTest))]
        //naming convention MethodName_expectedBehavior_StateUnderTest
        public async Task AddUserHandler_AddUserToDB_ShouldReturnSyccessValue(AddUserCommand req)
        {

            _service.Setup(x => x.AddAndSaveAsync(It.IsAny<Domain.Models.User.User>()))
                .ReturnsAsync(GetSampleData);

            var handler = new Contract.Handle.User.AddUserHandler(_service.Object, _mapper);
            var res = await handler.Handle(req, CancellationToken.None);

            Assert.NotNull(res);
            Assert.True(res.IsSucceed);

        }

        private Domain.Models.User.User GetSampleData()
        {
            return new Domain.Models.User.User
            {
                Id = 1,
                Name = "Morteza",
                FamilyName = "Nejat"
            };
        }
    }
}
