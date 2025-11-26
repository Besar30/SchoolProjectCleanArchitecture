using SchoolProject.Data.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entites
{
    public class Student:GeneralLocalizableEntity
    {
        public Student() {
            StudentSubjects=new HashSet<StudentSubject>();
        }
        public int StudentID { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public string? Address { get; set; }= string.Empty;
        public string? phone { get; set; } = string.Empty;
        public int? DID { get; set; }
        public bool IsDisabled { get; set; }

        [ForeignKey("DID")]
        public virtual Department Department { get; set; }
        [InverseProperty("Student")]
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
