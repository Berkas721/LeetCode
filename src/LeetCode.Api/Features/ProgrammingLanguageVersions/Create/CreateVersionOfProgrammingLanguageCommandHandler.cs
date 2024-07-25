using LeetCode.Data.Contexts;
using LeetCode.Data.Entities;
using LeetCode.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.ProgrammingLanguageVersions.Create;

public sealed record CreateVersionOfProgrammingLanguageCommand : IRequest<long>
{
    public required string ProgrammingLanguageName { get; init; }

    public required string VersionName { get; init; }

    public required DateOnly RealizedAt { get; init; }

    public required Dictionary<string, string> AdditionalDetails { get; init; }
}

public sealed record CreateVersionOfProgrammingLanguageCommandHandler : 
    IRequestHandler<CreateVersionOfProgrammingLanguageCommand, long>
{
    private readonly ApplicationDbContext _dbContext;

    public CreateVersionOfProgrammingLanguageCommandHandler(
        ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<long> Handle(
        CreateVersionOfProgrammingLanguageCommand request, 
        CancellationToken cancellationToken)
    {
        var version = new ProgrammingLanguageVersion
        {
            Name = request.VersionName,
            RealizedAt = request.RealizedAt,
            AdditionalDetails = request.AdditionalDetails,
            LanguageName = request.ProgrammingLanguageName
        };

        var isLanguageExist = await _dbContext
            .Languages
            .AnyAsync(
                x => x.Name == version.LanguageName, 
                cancellationToken: cancellationToken);

        if (!isLanguageExist)
            throw new ResourceNotFoundException($"не найден язык программирования с названием: {version.LanguageName}");

        await _dbContext
            .LanguageVersions
            .AddAsync(version, cancellationToken);

        await _dbContext
            .SaveChangesAsync(cancellationToken);

        return version.Id;
    }
}