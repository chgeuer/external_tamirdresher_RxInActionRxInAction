using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncEnumerables
{
    internal class QueueItemsEnumerator : IAsyncEnumerator<QueueItem>
    {
        private readonly QueueClient _client;
        private readonly CancellationToken cancellationToken;

        public QueueItemsEnumerator(QueueClient client, CancellationToken cancellationToken)
        {
            _client = client;
            this.cancellationToken = cancellationToken;
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        public async ValueTask<bool> MoveNextAsync()
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return false;
            }
            await Task.Delay(2000);
            Current = await _client.ReadNextItemAsync();
            return true;
        }

        public ValueTask DisposeAsync()
        {
            throw new System.NotImplementedException();
        }

        public QueueItem Current { get; private set; }
    }
}