using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    internal class DoubleLinkedListNode<T>
    {
        public DoubleLinkedListNode(T data)
        {
            Value = data;
        }

        public DoubleLinkedListNode<T> Previous { get; set; }

        public DoubleLinkedListNode<T> Next { get; set; }

        public T Value { get; set; }
    }
}