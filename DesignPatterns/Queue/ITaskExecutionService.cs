namespace DesignPatterns
{
    public interface ITaskExecutionService
    {
        Task ExecuteAsync(CancellationToken cancellationToken);    
    }
}