using System.ComponentModel;
using System.Collections.Concurrent;

namespace FormExDi.Presentation.Model
{
    internal class SyncListDelegate : ISynchronizeInvoke
    {
        private Guid _id { get; } = Guid.NewGuid();

        private ConcurrentQueue<Delegate> _queue = new();

        public bool InvokeRequired => throw new NotImplementedException();


        public Delegate? GetNext()
        {
            if(_queue.TryDequeue(out Delegate? @delegate) &&
                @delegate is not null)
            {
                return @delegate;
            }
            return null;
        }

        public IAsyncResult BeginInvoke(Delegate method, object?[]? args)
        {
            _queue.Enqueue(method);
            return null!;
        }

        public object? EndInvoke(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public object? Invoke(Delegate method, object?[]? args)
        {
            throw new NotImplementedException();
        }
    }
}
