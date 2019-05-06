using System.Collections.Generic;

namespace Epicor3S.Core.Models
{
    public class School
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Website { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
