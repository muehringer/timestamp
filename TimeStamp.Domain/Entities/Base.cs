using System;

namespace TimeStamp.Domain.Entities
{
    public class Base
    {
        public DateTime RegisterDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool Active { get; set; }
    }
}
