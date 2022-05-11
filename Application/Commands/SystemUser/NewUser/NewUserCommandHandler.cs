using Application.Interfaces;
using MediatR;
using Domain.Entities;
using Application.Validations.SystemUser;
using Application.Exceptions;

namespace Application.Commands.SystemUser.NewUser
{
    public class NewUserCommandHandler : IRequestHandler<NewUserCommand>
    {
        private readonly IContext _context;
        private readonly NewUserValidator _validator = new();

        public NewUserCommandHandler(IContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(NewUserCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = _validator.Validate(request.NewUser);

            if (!validatorResult.IsValid)
                throw new InvalidRequestException(string.Join(" ", validatorResult.Errors));

            var userExists = _context.Users.Any(s => s.Email == request.NewUser.Email);

            if (userExists)
                throw new Exception("Usuário já cadastrado.");

            var user = new User
            {
                Name = request.NewUser.Name,
                Password = request.NewUser.Password,
                State = request.NewUser.State,
                Email = request.NewUser.Email
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}