using Application.V1.CreateUser.Repositories;
using Core;
using Core.Authentication;
using Core.Models;
using Core.Repositories;
using Core.Validation;
using Core.Validation.Validators;
using MediatR;

namespace Application.V1.CreateUser;

public record CreateUserCommand(string email, string password) : IRequest<ValidatorResult<User>>;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, ValidatorResult<User>>
{
    private readonly IHashingService _hashingService;
    private readonly ISaltService _saltService;
    private readonly ICreateUserRepository _createUserRepository;

    public CreateUserHandler(IHashingService hashingService, ISaltService saltService,
        ICreateUserRepository createUserRepository)
    {
        _hashingService = hashingService;
        _saltService = saltService;
        _createUserRepository = createUserRepository;
    }


    public async Task<ValidatorResult<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        User userToCreate = new User
        {
            Id = Guid.NewGuid(),
            Email = request.email,
            Password = request.password,
            Salt = _saltService.GetSalt(64),
            Created = DateTimeOffset.UtcNow,
            CreatedBy = Defaults.SystemUser,
            LastModified = DateTimeOffset.UtcNow,
            LastModifiedBy = Defaults.SystemUser
        };
        UserValidator validator = new();

        var validationResult = validator.Validate(userToCreate);
        if (validationResult.HasViolations)
        {
            return validationResult;
        }

        var createdUser = await _createUserRepository.CreateUser(userToCreate);
        validationResult.Entity = createdUser;
        return validationResult;
    }
}