using Domain.Inputs.User;
using MediatR;

namespace Application.Commands.SystemUser.NewUser
{
    public class NewUserCommand : IRequest
    {
        public NewUserCommand(NewUserRequest newUser)
        {
            NewUser = newUser;
        }

        public NewUserRequest NewUser { get; }
    }
}