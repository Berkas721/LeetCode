using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LeetCode.Controllers.Abstraction;

[ApiController]
public abstract class ApplicationController(IMediator mediator, IMapper mapper) : ControllerBase
{
    protected readonly IMediator Mediator = mediator;

    protected readonly IMapper Mapper = mapper;
}