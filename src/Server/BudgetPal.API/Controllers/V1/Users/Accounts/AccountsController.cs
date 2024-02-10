using System.Net;
using API.Controllers.V1.Users.Accounts.Dtos;
using API.Dtos;
using API.Filters;
using Application.V1.CreateAccount;
using Core.Exceptions;
using Core.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1.Users.Accounts;

[ApiController]
[Route("api/v1/accounts")]
[BudgetPalExceptionFilter]
public class AccountsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<ReadCreatedAccountDto>>> CreateAccount([FromBody] CreateAccountDto dto)
    {
        try
        {
            var result = await _mediator.Send(
                new CreateAccountCommand(
                    dto.UserId,
                    dto.Name,
                    dto.InitialBalance,
                    dto.CurrencyCode.ToCurrencyCode())
            );

            return Ok(new ApiResponse<ReadCreatedAccountDto>
            {
                Data = null,
                Errors = result.HasViolations ? result.Results : null,
                Status = (int) HttpStatusCode.OK,
                Title = $"Create Account (User {dto.UserId})"
            });
        }
        catch (Exception e) when (e is NotFoundException)
        {
            var errors = new Dictionary<string, IReadOnlyCollection<string>>();
            errors.Add("UserNotFound", new List<string>() {e.Message});
            return NotFound(new ApiResponse<ReadCreatedAccountDto>
            {
                Data = null,
                Errors = errors,
                Status = (int) HttpStatusCode.NotFound,
                Title = $"User {dto.UserId} not found"
            });
        }
        catch (Exception e)
        {
            var errors = new Dictionary<string, IReadOnlyCollection<string>>();
            errors.Add("UnexpectedError", new List<string> {e.Message});
            return StatusCode((int) HttpStatusCode.InternalServerError, new ApiResponse<ReadCreatedAccountDto>
            {
                Data = null,
                Errors = errors,
                Status = (int) HttpStatusCode.InternalServerError,
                Title = $"Unexpected Error"
            });
        }
    }
}