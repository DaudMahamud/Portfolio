using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Interfaces.Common
{
    public interface IApplicationDBContext
    {
        Task<int> SaveChangesAsync(CancellationToken
                                   cancellationToken = default);
    }
}
