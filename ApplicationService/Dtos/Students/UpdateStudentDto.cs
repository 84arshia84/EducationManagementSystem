using AppCore.Enums.StudentLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Dtos.Students
{
    public class UpdateStudentDto
    {
        public string? Skills { get; set; }
        public string? Languages { get; set; }
        public StudentLevel Level { get; set; }
        public double Progress { get; set; }
    }

}
