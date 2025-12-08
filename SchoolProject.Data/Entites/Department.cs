using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SchoolProject.Data.Commons;

namespace SchoolProject.Data.Entites
{
    public partial class Department:GeneralLocalizableEntity
    {
        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmetSubject>();
            instractors= new HashSet<Instractor>();
        }
        [Key]
        public int DID { get; set; }
        public string? DNameAr { get; set; }
        public string? DNameEn { get; set; }
        public int? InsManger {  get; set; }
        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; }

        [InverseProperty("department")]
        public virtual ICollection<Instractor> instractors { get; set; }

        [ForeignKey("InsManger")]
        [InverseProperty("departmentManger")]
        public virtual Instractor? instractor { get; set; }
    }
}
