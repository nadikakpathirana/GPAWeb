using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPAWeb.DAL.Models
{
    internal class Grade
    {
        public Guid Id { get; set; }
        public Guid TeacherId { get; set; }
        public Guid StudentId { get; set; }
        public Guid SemesterId { get; set; }
        public Guid SubjectId { get; set; }
        public string? Description { get; set; }
        public double Value { get; set; }
    }
}
