using LeetCode.Data.Contexts;
using LeetCode.Dto.ProgrammingLanguage;
using LeetCode.Exceptions;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.ProgrammingLanguages.Query;

public sealed record GetProgrammingLanguageVersionsQuery(string LanguageName) :
    IRequest<IReadOnlyList<VersionOfProgrammingLanguage>>;

public sealed record GetProgrammingLanguageVersionsQueryHandler : 
    IRequestHandler<GetProgrammingLanguageVersionsQuery, IReadOnlyList<VersionOfProgrammingLanguage>>
{
    private readonly ApplicationDbContext _dbContext;
    
    private readonly IMapper _mapper;

    public GetProgrammingLanguageVersionsQueryHandler(
        ApplicationDbContext dbContext, 
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<VersionOfProgrammingLanguage>> Handle(
        GetProgrammingLanguageVersionsQuery request, 
        CancellationToken cancellationToken)
    {
        var versions = await _dbContext
            .LanguageVersions
            .Where(x => x.LanguageName == request.LanguageName)
            .ToListAsync(cancellationToken);

        ResourceNotFoundException
            .ThrowIfNull(versions, $"не найдены версии языка: {request.LanguageName}");

        return _mapper.Map<List<VersionOfProgrammingLanguage>>(versions);
    }
}