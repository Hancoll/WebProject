using WebProject.Application.Common.Interfaces.Services;

namespace WebProject.Infrastructure.Services;

internal class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
