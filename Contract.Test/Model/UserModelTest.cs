using Contract.Command.User;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Test.Model
{
    public static class UserModelTest
    {
        public class UserModelRequestTest : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {
                    new AddUserCommand(new Messaging.User.AddUserRequest { ViewModel = new ViewModels.User.AddUserViewModel
                    {
                        Name = "Morteza",
                        FamilyName = "Nejat"
                    }})
                };
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
    }
}
