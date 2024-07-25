using LeetCode.Controllers.Abstraction;
using LeetCode.Dto.ProgrammingLanguage;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LeetCode.Controllers.V1;

[Route("api/v1/programming-language-version")]
public class ProgrammingLanguageVersionController(IMediator mediator, IMapper mapper) : 
    ApplicationController(mediator, mapper)
{
    [HttpGet("{versionId}")]
    [SwaggerOperation("Get info of pointed version")]
    public async Task<IActionResult> GetById(
        [FromRoute] long versionId)
    {
        return Ok();
    }

    [HttpPut]
    [SwaggerOperation("Add version to existing language")]
    public async Task<IActionResult> Create(
        [FromBody] CreateProgrammingLanguageVersionInput input)
    {
        return Ok();
    }
}