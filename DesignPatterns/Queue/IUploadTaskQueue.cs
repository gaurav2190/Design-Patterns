namespace DesignPatterns
{
    public interface IUploadTaskQueue
    {
        void QueueUploadTaskItem(Func<CancellationToken, Task> taskItem);

        Task<Func<CancellationToken, Task>> DequeueTaskAsync(CancellationToken cancellationToken);
    }
}