using LeetCode.Controllers.Abstraction;
using LeetCode.Dto.ProgrammingLanguage;
using LeetCode.Features.ProgrammingLanguages.Create;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LeetCode.Controllers.V1;

[Route("api/v1/programming-language")]
public class ProgrammingLanguageController(IMediator mediator, IMapper mapper) : 
    ApplicationController(mediator, mapper)
{
    [HttpGet]
    [SwaggerOperation("Get list of language names")]
    public async Task<IActionResult> Query()
    {
        return Ok();
    }

    [HttpGet("{languageName}/versions")]
    [SwaggerOperation("Get list of pointed language versions")]
    public async Task<IActionResult> GetVersions(
        [FromRoute] string languageName)
    {
        return Ok();
    }

    [HttpGet("{languageName}/versions/last")]
    [SwaggerOperation("Get actual/last version of pointed language")]
    public async Task<IActionResult> GetActualVersion(
        [FromRoute] string languageName)
    {
        return Ok();
    }

    [HttpPut]
    [SwaggerOperation("Create language with it's first version")]
    public async Task<IActionResult> Create(
        [FromBody] CreateProgrammingLanguageVersionInput input)
    {
        var command = Mapper.Map<CreateProgrammingLanguageCommand>(input);
        var versionId = await Mediator.Send(command);
        return Ok(versionId);
    }
}