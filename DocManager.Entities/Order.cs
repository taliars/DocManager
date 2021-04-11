using System;

namespace DocManager.Entities
{
    public class Order
    {
        public string Name { get; set; }

        public ObjectData ObjectData { get; set; }

        public Customer Customer { get; set; }
   }
}
