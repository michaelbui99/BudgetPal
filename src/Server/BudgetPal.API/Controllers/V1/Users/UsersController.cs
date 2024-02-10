using System.Net;
using System.Text.Json;
using API.Controllers.V1.Dtos;
using API.Controllers.V1.Users.Accounts.Dtos;
using API.Dtos;
using API.Filters;
using Application.V1.CreateUser;
using Core.Exceptions;
using Core.Models;
using Core.Models.Common;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1;

[ApiController]
[BudgetPalExceptionFilter]
[Route("api/v1/users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<ReadCreatedUserDto>>> CreateUser([FromBody] CreateUserRequestDto dto)
    {
        try
        {
            var result = await _mediator.Send(new CreateUserCommand(dto.Email, dto.Password));
            if (result.HasViolations)
            {
                return BadRequest(new ApiResponse<ReadCreatedUserDto>()
                {
                    Data = null,
                    Errors = result.Results,
                    Status = 400,
                    Title = "Invalid user"
                });
            }

            // TODO: (mibui 2024-02-10) Add automapper
            return Ok(new ApiResponse<ReadCreatedUserDto>
            {
                Data = result.HasViolations
                    ? null
                    : new ReadCreatedUserDto
                    {
                        Email = result.Entity.Email,
                        Id = result.Entity.Id,
                        Created = result.Entity.Created,
                        CreatedBy = result.Entity.CreatedBy,
                        LastModified = result.Entity.LastModified,
                        LastModifiedBy = result.Entity.LastModifiedBy
                    },
                Errors = result.HasViolations ? result.Results : null,
                Status = (int) HttpStatusCode.OK,
                Title = "Create User"
            });
        }
        catch (Exception e)
        {
            var errors = new Dictionary<string, IReadOnlyCollection<string>>();
            errors.Add("UnexpectedError", new List<string> {e.Message, e.StackTrace});
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