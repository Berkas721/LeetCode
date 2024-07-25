using LeetCode.Controllers.Abstraction;
using LeetCode.Dto.ProgrammingLanguage;
using LeetCode.Features.ProgrammingLanguageVersions.Create;
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
        var command = Mapper.Map<CreateVersionOfProgrammingLanguageCommand>(input);
        var versionId = await Mediator.Send(command);
        return Ok(versionId);
    }
}