using Core.Models;
using MediatR;

namespace Application.V1.CreateAccount;

public record AddAccountCommand(Guid userId, string name, double initialBalance) : IRequest<Account>;

public class CreateAccountHandler: IRequestHandler<AddAccountCommand, Account>
{
    
    
    public Task<Account> Handle(AddAccountCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}