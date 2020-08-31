using Csharp.OOD.Handlers;
using Csharp.OOD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csharp.OOD.Services
{
    public class LRUCache : ICache
    {
        private readonly int CAP = int.MaxValue; 
        private readonly int Capacity;
        private int count;

        private DoubleLinkedNode head, tail;
        private Dictionary<int, DoubleLinkedNode> cache = new Dictionary<int, DoubleLinkedNode>();
        private DoubleLinkedNodeHandler handler;

        public LRUCache()
        {
            this.count = 0;
            this.Capacity = CAP;

            head = new DoubleLinkedNode();
            head.pre = null;

            tail = new DoubleLinkedNode();
            tail.post = null;

            head.post = tail;
            tail.pre = head;
            this.handler = new DoubleLinkedNodeHandler(head, tail);
        }

        public LRUCache(int capacity)
        {
            this.count = 0;
            this.Capacity = capacity;

            head = new DoubleLinkedNode();
            head.pre = null;

            tail = new DoubleLinkedNode();
            tail.post = null;

            head.post = tail;
            tail.pre = head;
            this.handler = new DoubleLinkedNodeHandler(head, tail);
        }

        public string Get(int key)
        {
            //raise exception here
            if (!cache.ContainsKey(key))
            {
                return "-1";
            }

            var node = cache[key];
            //move the accessed node to the head;
            handler.MoveToHead(node);

            return node.value;
        }

        //put the value into the cache
        public void Put(int key, string value)
        {
            if (!cache.TryGetValue(key, out DoubleLinkedNode node))
            {
                node = default;
            }

            if (node == null)
            {
                DoubleLinkedNode
                    newNode = new DoubleLinkedNode();
                newNode.key = key;
                newNode.value = value;

                this.cache.Add(key, newNode);
                handler.AddNode(newNode);

                ++count;

                if (count > Capacity)
                {
                    DoubleLinkedNode tail = handler.PopTail();
                    this.cache.Remove(tail.key);
                    --count;
                }
            }
            else
            {
                // update the value
                node.value = value;
                handler.MoveToHead(node);
            }

        }
    }
}
