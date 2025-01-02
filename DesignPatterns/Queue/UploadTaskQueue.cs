using System.Threading.Channels;

namespace DesignPatterns
{
    public class UploadTaskQueue : IUploadTaskQueue
    {
        private readonly Channel<Func<CancellationToken, Task>> _queue;

        public UploadTaskQueue()
        {
            _queue = Channel.CreateUnbounded<Func<CancellationToken, Task>>(
                new UnboundedChannelOptions { SingleReader = true, SingleWriter = true }
            );
        }

        public async Task<Func<CancellationToken, Task>> DequeueTaskAsync(CancellationToken cancellationToken)
        {
            var taskItem = await _queue.Reader.ReadAsync(cancellationToken);

            return taskItem;
        }

        public void QueueUploadTaskItem(Func<CancellationToken, Task> taskItem)
        {
            ArgumentNullException.ThrowIfNull(taskItem, nameof(taskItem));

            _queue.Writer.TryWrite(taskItem);
        }
    }
}