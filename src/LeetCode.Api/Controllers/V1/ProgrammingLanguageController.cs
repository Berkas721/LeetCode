using LeetCode.Controllers.Abstraction;
using LeetCode.Dto.ProgrammingLanguage;
using LeetCode.Features.ProgrammingLanguages.Create;
using LeetCode.Features.ProgrammingLanguages.Query;
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
        var query = new GetProgrammingLanguageNamesQuery();
        var names = await Mediator.Send(query);
        return Ok(names);
    }

    [HttpGet("{languageName}/versions")]
    [SwaggerOperation("Get list of pointed language versions")]
    public async Task<IActionResult> GetVersions(
        [FromRoute] string languageName)
    {
        var query = new GetProgrammingLanguageVersionsQuery(languageName);
        var versions = await Mediator.Send(query);
        return Ok(versions);
    }

    [HttpGet("{languageName}/versions/last")]
    [SwaggerOperation("Get actual/last version of pointed language")]
    public async Task<IActionResult> GetActualVersion(
        [FromRoute] string languageName)
    {
        var query = new GetProgrammingLanguageActualVersionQuery(languageName);
        var version = await Mediator.Send(query);
        return Ok(version);
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