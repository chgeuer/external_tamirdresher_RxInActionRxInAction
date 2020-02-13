using System.Collections.Generic;
using System.Threading;

namespace AsyncEnumerables
{
    internal class QueueItems : IAsyncEnumerable<QueueItem>
    {
        public IAsyncEnumerator<QueueItem> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new QueueItemsEnumerator(new QueueClient(), cancellationToken);
        }
    }
}