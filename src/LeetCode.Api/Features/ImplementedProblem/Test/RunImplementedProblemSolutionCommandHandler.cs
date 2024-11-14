using LeetCode.Abstractions;
using LeetCode.Data.Contexts;
using LeetCode.Exceptions;
using LeetCode.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.ImplementedProblem.Test;

public sealed record RunImplementedProblemSolutionCommand(Guid Id, string JsonInput) 
    : IRequest<string>;

public class RunImplementedProblemSolutionCommandHandler
    : IRequestHandler<RunImplementedProblemSolutionCommand, string>
{
    private readonly ApplicationDbContext _dbContext;

    private readonly ISolutionRunnerFactory _solutionRunnerFactory;

    public RunImplementedProblemSolutionCommandHandler(
        ApplicationDbContext dbContext, 
        ISolutionRunnerFactory solutionRunnerFactory)
    {
        _dbContext = dbContext;
        _solutionRunnerFactory = solutionRunnerFactory;
    }

    public async Task<string> Handle(
        RunImplementedProblemSolutionCommand request, 
        CancellationToken cancellationToken)
    {
        var implementedProblem = await _dbContext
            .ImplementedProblems
            .FirstAsync(request.Id, cancellationToken);

        var solutionRunner = _solutionRunnerFactory.CreateRunner(
            implementedProblem.ProblemCode,
            implementedProblem.WorkingSolutionCode,
            implementedProblem.LanguageId);

        return await solutionRunner.RunAsync(request.JsonInput);
    }
}