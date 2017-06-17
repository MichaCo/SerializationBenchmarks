using System;
using System.Threading;

namespace Benchmarks
{
    public interface IObjectPoolPolicy<T>
    {
        T CreateNew();

        bool Return(T value);
    }

    public class ObjectPool<T> where T : class
    {
        private readonly T[] _items;
        private readonly IObjectPoolPolicy<T> _policy;

        public ObjectPool(IObjectPoolPolicy<T> policy, int? maxItems = null)
        {
            if (maxItems == null || maxItems <= 0)
            {
                maxItems = Environment.ProcessorCount * 2;
            }

            _policy = policy ?? throw new ArgumentNullException(nameof(policy));
            _items = new T[maxItems.Value];
        }

        public T Lease()
        {
            for (var i = 0; i < _items.Length; i++)
            {
                var item = _items[i];
                if (item != null && Interlocked.CompareExchange(ref _items[i], null, item) == item)
                {
                    return item;
                }
            }

            return _policy.CreateNew();
        }

        public void Return(T value)
        {
            if (!_policy.Return(value))
            {
                return;
            }

            for (var i = 0; i < _items.Length; i++)
            {
                if (_items[i] == null)
                {
                    _items[i] = value;
                    return;
                }
            }
        }
    }
}