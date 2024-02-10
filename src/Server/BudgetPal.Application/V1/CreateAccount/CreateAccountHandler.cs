using Application.V1.CreateAccount.Repositories;
using Core;
using Core.Exceptions;
using Core.Models;
using Core.Validation;
using MediatR;

namespace Application.V1.CreateAccount;

public record CreateAccountCommand
    (Guid UserId, string Name, double InitialBalance, CurrencyCode CurrencyCode) : IRequest<ValidatorResult<Account>>;

public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, ValidatorResult<Account>>
{
    private readonly IUserRepository _userRepository;
    private readonly IAccountsRepository _accountsRepository;

    public CreateAccountHandler(IUserRepository userRepository, IAccountsRepository accountsRepository)
    {
        _userRepository = userRepository;
        _accountsRepository = accountsRepository;
    }

    public async Task<ValidatorResult<Account>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        User? existingUser = await _userRepository.GetById(request.UserId);
        if (existingUser is null)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        Account accountToCreate = new()
        {
            Balance = new MoneyAmount(request.InitialBalance, request.CurrencyCode),
            Id = Guid.NewGuid(),
            Name = request.Name,
            Created = DateTimeOffset.UtcNow,
            CreatedBy = existingUser.Id.ToString(),
            LastModified = DateTimeOffset.UtcNow,
            LastModifiedBy = existingUser.Id.ToString()
        };
        await _accountsRepository.AddAccount(existingUser.Id, accountToCreate);
        
        return ValidatorResult<Account>.Success(accountToCreate);
    }
}