using LeetCode.Data.Contexts;
using LeetCode.Data.Entities;
using MapsterMapper;
using MediatR;

namespace LeetCode.Features.ProgrammingLanguages.Create;

public sealed record CreateProgrammingLanguageCommand : IRequest<long>
{
    public required string ProgrammingLanguageName { get; init; }

    public required string VersionName { get; init; }

    public required DateOnly RealizedAt { get; init; }

    public required Dictionary<string, string> AdditionalDetails { get; init; }
}

public sealed record CreateProgrammingLanguageCommandHandler :
    IRequestHandler<CreateProgrammingLanguageCommand, long>
{
    private readonly ApplicationDbContext _dbContext;
    
    private readonly IMapper _mapper;

    public CreateProgrammingLanguageCommandHandler(
        ApplicationDbContext dbContext, 
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<long> Handle(
        CreateProgrammingLanguageCommand request, 
        CancellationToken cancellationToken)
    {
        var language = new ProgrammingLanguage
        {
            Name = request.ProgrammingLanguageName
        };

        var version = new ProgrammingLanguageVersion
        {
            Name = request.VersionName,
            RealizedAt = request.RealizedAt,
            AdditionalDetails = request.AdditionalDetails,
            LanguageName = request.ProgrammingLanguageName
        };

        await _dbContext
            .Languages
            .AddAsync(language, cancellationToken);

        await _dbContext
            .LanguageVersions
            .AddAsync(version, cancellationToken);

        await _dbContext
            .SaveChangesAsync(cancellationToken);

        return version.Id;
    }
}