using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Photo : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Jpeg { get; set; }

    }
}
