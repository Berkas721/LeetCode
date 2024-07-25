using LeetCode.Data.Contexts;
using LeetCode.Dto.ProgrammingLanguage;
using LeetCode.Exceptions;
using MapsterMapper;
using MediatR;

namespace LeetCode.Features.ProgrammingLanguageVersions.Query;

public sealed record GetProgrammingLanguageVersionQuery(long VersionId) : 
    IRequest<VersionOfProgrammingLanguage>;

public sealed record GetProgrammingLanguageVersionQueryHandler : 
    IRequestHandler<GetProgrammingLanguageVersionQuery, VersionOfProgrammingLanguage>
{
    private readonly ApplicationDbContext _dbContext;

    private readonly IMapper _mapper;

    public GetProgrammingLanguageVersionQueryHandler(
        ApplicationDbContext dbContext, 
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<VersionOfProgrammingLanguage> Handle(
        GetProgrammingLanguageVersionQuery request, 
        CancellationToken cancellationToken)
    {
        var version = await _dbContext
            .LanguageVersions
            .FindAsync(request.VersionId);
        
        ResourceNotFoundException
            .ThrowIfNull(version, $"не найдена версия языка программирования с id: {request.VersionId}");

        return _mapper.Map<VersionOfProgrammingLanguage>(version);
    }
}