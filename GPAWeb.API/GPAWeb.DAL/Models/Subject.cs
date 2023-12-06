using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPAWeb.DAL.Models
{
    internal class Subject
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Semester Semester { get; set; }
        public string? Name { get; set; }
        public int CreditCount { get; set; }
    }
}
