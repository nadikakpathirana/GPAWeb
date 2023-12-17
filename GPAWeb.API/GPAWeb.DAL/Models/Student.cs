using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPAWeb.DAL.Models
{
    public class Student : User
    {
        public Guid TeacherId { get; set; }
    }
}
