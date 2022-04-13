using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private readonly DoublyLinkedList<T> _linkedList;

        public HybridFlowProcessor()
        {
            _linkedList = new DoublyLinkedList<T>();
        }

        public T Dequeue()
        {
            ThrowIfListIsEmpty();

            return _linkedList.RemoveAt(0);
        }

        public void Enqueue(T item)
        {
            _linkedList.Add(item);
        }

        public T Pop()
        {
            ThrowIfListIsEmpty();

            return _linkedList.RemoveAt(_linkedList.Length - 1);
        }

        public void Push(T item)
        {
            _linkedList.Add(item);
        }

        private void ThrowIfListIsEmpty()
        {
            if (_linkedList.Length == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}