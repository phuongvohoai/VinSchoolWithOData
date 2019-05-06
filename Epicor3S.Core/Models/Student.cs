using System;

namespace Epicor3S.Core.Models
{
    public class Student
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public decimal Score { get; set; }

        public string SchoolId { get; set; }

        public virtual School School { get; set; }
    }
}
