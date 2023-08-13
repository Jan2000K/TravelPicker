using System.Net;
using TravelPickerApp.DAL;
using TravelPickerApp.DAL.Entities;
using TravelPickerApp.Models;

namespace TravelPickerApp.Services;

public class ApiCallLoggerService
{
    private readonly AppDbContext _dbContext;
    private LoggerService _logger;

    public ApiCallLoggerService(AppDbContext dbContext,LoggerService logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task LogApiCall(Guid requestedBy,string? serviceName = null, string? serviceMethodName = null ,HttpStatusCode? httpStatusCode = null,string? additionalData = null)
    {
        var user = await _dbContext.Users.FindAsync(requestedBy);
        if (user is null)
        {
            await _logger.LogInformationAsync($"User with GUID {requestedBy} not found in database. Cannot write into ApiCall log table",ActionStatusCode.ActionFailed);
            return;
        }
        var LogObject = new GeoDbApiCallLog
        {
            Id = Guid.NewGuid(),
            TimeStamp = DateTimeOffset.UtcNow,
            RequestedBy = user,
            ServiceName = serviceName,
            ServiceMethodName = serviceMethodName,
            StatusCode = httpStatusCode,
            AdditionalData = additionalData
        };
        await _dbContext.GeoDbApiCallLog.AddAsync(LogObject);
        await _dbContext.SaveChangesAsync();
    }
}