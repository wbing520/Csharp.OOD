using Csharp.OOD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csharp.OOD.Handlers
{
    public class DoubleLinkedNodeHandler
    {

        private DoubleLinkedNode head, tail;

        public DoubleLinkedNodeHandler(DoubleLinkedNode head, DoubleLinkedNode tail)
        {
            this.head = head;
            this.tail = tail;
        }

        /// <summary>
        /// Add the new node right after head
        /// </summary>
        /// <param name="node"></param>
        public void AddNode(DoubleLinkedNode node)
        {
            node.pre = this.head;
            node.post = this.head.post;

            this.head.post.pre = node;
            this.head.post = node;
        }

        /// <summary>
        /// Remove an existing node from the linked list.
        /// </summary>
        /// <param name="node"></param>    
        public void RemoveNode(DoubleLinkedNode node)
        {
            DoubleLinkedNode pre = node.pre;
            DoubleLinkedNode post = node.post;

            pre.post = post;
            post.pre = pre;
        }

        /// <summary>
        /// Move certain node in between to the head
        /// </summary>
        /// <param name="node"></param>
        public void MoveToHead(DoubleLinkedNode node)
        {
            this.RemoveNode(node);
            this.AddNode(node);
        }

        /// <summary>
        /// pop the current tail node
        /// </summary>
        /// <returns></returns>
        public DoubleLinkedNode PopTail()
        {
            DoubleLinkedNode res = tail.pre;
            this.RemoveNode(res);
            return res;
        }
    }

}
