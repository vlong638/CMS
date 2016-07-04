using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication2.Entity
{
    public class EntityBase<T> where T : class
    {
        public string Header { get; set; }
        public int Category { get; set; }
        public List<T> Content { get; set; }
    }
}
