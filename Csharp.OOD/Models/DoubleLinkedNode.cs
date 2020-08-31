using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csharp.OOD.Models
{
    /// <summary>
    /// Model class for the double linked list
    /// </summary>
    public class DoubleLinkedNode
    {
        public int key { get; set; }
        public string value { get; set; }

        public DateTime Start { get; set; }
        public DoubleLinkedNode pre { get; set; }
        public DoubleLinkedNode post { get; set; }


    }

}
