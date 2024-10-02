using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Repository.Entities.Base
{
    public class EntityBase
    {
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public bool IsDeleted { get; set; }

        public byte[] Version { get; set; } = null!;
    }
}
