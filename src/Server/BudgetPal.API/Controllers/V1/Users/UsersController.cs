using System.Net;
using System.Text.Json;
using API.Controllers.V1.Dtos;
using API.Dtos;
using API.Filters;
using Application.V1.CreateUser;
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
            Status = (int)HttpStatusCode.OK,
            Title = "Create User"
        });
    }
}