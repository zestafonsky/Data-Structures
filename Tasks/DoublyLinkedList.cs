using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>, IEnumerator<T>
    {
        private DoubleLinkedListNode<T> _head;
        private DoubleLinkedListNode<T> _currentIterationNode;

        public int Length { get; private set; }

        public void Add(T e)
        {
            var newNode = new DoubleLinkedListNode<T>(e);

            if (_head is null)
            {
                _head = newNode;
                Length++;
                return;
            }

            _head.Next = newNode;
            newNode.Previous = _head;
            _head = newNode;
            Length++;
        }

        public void AddAt(int index, T e)
        {
            if (index == Length)
            {
                Add(e);
                return;
            }

            var nodeAtIndex = GetNodeAtIndex(index);

            var newNode = new DoubleLinkedListNode<T>(e)
            {
                Previous = nodeAtIndex.Previous,
                Next = nodeAtIndex
            };

            nodeAtIndex.Previous = newNode;
            Length++;
        }

        public T ElementAt(int index)
        {
            return GetNodeAtIndex(index).Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        public void Remove(T item)
        {
            var node = GetNodeAtIndex(0); ;
            while (node != null)
            {
                if (node.Value.Equals(item))
                {
                    RemoveNode(node);
                    return;
                }

                node = node.Next;
            }
        }

        public T RemoveAt(int index)
        {
            var node = GetNodeAtIndex(index);
            RemoveNode(node);

            return node.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {

            if (_currentIterationNode is null)
            {
                _currentIterationNode = GetNodeAtIndex(0);
                return true;
            }
            else
            {
                _currentIterationNode = _currentIterationNode.Next;
                return _currentIterationNode != null;
            }
        }

        public void Reset()
        {
            _currentIterationNode = null;
        }

        public T Current => _currentIterationNode.Value;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            Reset();
        }

        private DoubleLinkedListNode<T> GetNodeAtIndex(int index)
        {
            ValidateIndex(index);

            var node = _head;
            var distanceFromHead = (Length - 1) - index;

            while (distanceFromHead != 0)
            {
                node = node.Previous;
                distanceFromHead--;
            }

            return node;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void RemoveNode(DoubleLinkedListNode<T> node)
        {
            var previous = node.Previous;
            var next = node.Next;

            if (previous != null)
            {
                previous.Next = node.Next;
            }

            if (next != null)
            {
                next.Previous = node.Previous;
            }

            if (node.Equals(_head))
            {
                _head = previous;
            }


            Length--;
        }
    }
}