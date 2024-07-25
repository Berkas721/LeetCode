using LeetCode.Data.Contexts;
using LeetCode.Dto.ProgrammingLanguage;
using LeetCode.Exceptions;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.ProgrammingLanguages.Query;

public sealed record GetProgrammingLanguageActualVersionQuery(string LanguageName) : 
    IRequest<VersionOfProgrammingLanguage>;

public sealed record GetProgrammingLanguageActualVersionQueryHandler : 
    IRequestHandler<GetProgrammingLanguageActualVersionQuery, VersionOfProgrammingLanguage>
{
    private readonly ApplicationDbContext _dbContext;

    private readonly IMapper _mapper;

    public GetProgrammingLanguageActualVersionQueryHandler(
        ApplicationDbContext dbContext, 
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<VersionOfProgrammingLanguage> Handle(
        GetProgrammingLanguageActualVersionQuery request, 
        CancellationToken cancellationToken)
    {
        var version = await _dbContext
            .LanguageVersions
            .Where(x => x.LanguageName == request.LanguageName)
            .OrderByDescending(x => x.RealizedAt)
            .FirstAsync(cancellationToken);

        ResourceNotFoundException
            .ThrowIfNull(version, $"не найдены версии языка: {request.LanguageName}");

        return _mapper.Map<VersionOfProgrammingLanguage>(version);
    }
}