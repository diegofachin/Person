﻿using Application.Handlers.AuthenticatePerson;
using Application.Handlers.RegisterPerson;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Person.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IMediator _mediator;

    public PersonController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("register")]
    [ProducesResponseType((201))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<RegisterPersonResponseDto>> Register([FromBody] RegisterPersonRequestDto registerUserRequestDto)
    {
        var result = await _mediator.Send(registerUserRequestDto);

        return result is not null
            ? Ok(result)
            : BadRequest();
    }

    [HttpGet("authenticate")]
    [ProducesResponseType((201))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<AuthenticatePersonResponseDto>> Authenticate([FromQuery] string cpf, [FromQuery] string password)
    {
        var authenticateRequestDto = new AuthenticatePersonRequestDto()
        {
            Cpf = cpf,
            Password = password
        };

        var result = await _mediator.Send(authenticateRequestDto);

        return result is not null
            ? Ok(result)
            : BadRequest();
    }
}