
namespace DesignPatterns
{
    public class TaskExecutionService : ITaskExecutionService
    {
        private readonly IUploadTaskQueue taskQueue;

        public TaskExecutionService(IUploadTaskQueue uploadTaskQueue)
        {
            this.taskQueue = uploadTaskQueue;
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var task = await this.taskQueue.DequeueTaskAsync(cancellationToken);

                try{
                    await task(cancellationToken);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}