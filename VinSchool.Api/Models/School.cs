using System.Collections.Generic;

namespace VinSchool.Api.Models
{
    public class School
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
