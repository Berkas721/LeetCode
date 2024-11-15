using LeetCode.Data.Contexts;
using LeetCode.Dto.ImplementedProblem;
using LeetCode.Exceptions;
using LeetCode.Extensions;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeetCode.Features.ImplementedProblem.Query;

public sealed record GetByIdImplementedProblemQuery(Guid Id) : IRequest<ImplementedProblemOutput>;

public class GetByIdImplementedProblemQueryHandler 
    : IRequestHandler<GetByIdImplementedProblemQuery, ImplementedProblemOutput>
{
    private readonly ApplicationDbContext _dbContext;

    private readonly IMapper _mapper;

    public GetByIdImplementedProblemQueryHandler(
        ApplicationDbContext dbContext, 
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<ImplementedProblemOutput> Handle(
        GetByIdImplementedProblemQuery request, 
        CancellationToken cancellationToken)
    {
        var implementedProblem = await _dbContext
            .ImplementedProblems
            .FindByIdAsync(request.Id, cancellationToken);

        return _mapper.Map<ImplementedProblemOutput>(implementedProblem);
    }
}