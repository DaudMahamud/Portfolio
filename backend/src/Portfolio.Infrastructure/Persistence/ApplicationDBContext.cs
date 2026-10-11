using Portfolio.Application.Interfaces.Common;
using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Entities;

namespace Portfolio.Infrastructure.Persistence
{
    public class ApplicationDBContext(DbContextOptions<ApplicationDBContext>
    options)
        : DbContext(options), IApplicationDBContext
    {
    }
}
