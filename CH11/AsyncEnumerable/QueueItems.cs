using System.Collections.Generic;
using System.Threading;

namespace AsyncEnumerables
{
    class QueueItems : IAsyncEnumerable<QueueItem>
    {
        public IAsyncEnumerator<QueueItem> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new QueueItemsEnumerator(new QueueClient(), cancellationToken);
        }
    }
}