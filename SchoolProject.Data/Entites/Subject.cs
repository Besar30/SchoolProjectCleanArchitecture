using SchoolProject.Data.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entites
{
    public class Subject : GeneralLocalizableEntity
    {
        public Subject()
        {
            StudentsSubjects = new HashSet<StudentSubject>();
            DepartmetsSubjects = new HashSet<DepartmetSubject>();
            InsSubjects = new HashSet<Ins_Subject>();
        }
        [Key]
        public int SubID { get; set; }

        public string? SubjectNameAr { get; set; }
        public string? SubjectNameEn { get; set; }

        public int? Period { get; set; }
        [InverseProperty("Subject")]
        public virtual ICollection<StudentSubject> StudentsSubjects { get; set; }
        [InverseProperty("Subjects")]
        public virtual ICollection<DepartmetSubject> DepartmetsSubjects { get; set; }
        [InverseProperty("subject")]
        public virtual ICollection<Ins_Subject> InsSubjects { get; set; }
    }
}