using TravelPickerApp.DAL;
using TravelPickerApp.DAL.Entities;
using TravelPickerApp.Models;

namespace TravelPickerApp.Services;

public class LoggerService
{
    private readonly AppDbContext _dbContext;

    public LoggerService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task LogExceptionAsync(Exception ex)
    {
        await _dbContext.ApplicationLog.AddAsync(new ApplicationLog
        {
            Id = Guid.NewGuid(),
            TimeStamp = DateTimeOffset.UtcNow,
            ActionStatusCode = ActionStatusCode.ExceptionThrown,
            LogContent = ex.ToString()
        });
        await _dbContext.SaveChangesAsync();
    }

    public async Task LogInformationAsync(String content,ActionStatusCode? statusCode)
    {
        await _dbContext.ApplicationLog.AddAsync(new ApplicationLog
        {
            Id = Guid.NewGuid(),
            TimeStamp = DateTimeOffset.UtcNow,
            ActionStatusCode = statusCode,
            LogContent = content
        });
        await _dbContext.SaveChangesAsync();
    }
}