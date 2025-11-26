using SchoolProject.Data.Commons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entites
{
    public class Instractor:GeneralLocalizableEntity
    {
        public Instractor() { 

          Instractors=new HashSet<Instractor>();
            Ins_Subjects=new HashSet<Ins_Subject>();
        }
        [Key]
        public int InsId { get; set; }
        public string? ENameAr { get; set; }=string.Empty;
        public string? ENameEn { get; set; }=string.Empty;
        public string? Address { get; set;}=string.Empty;
        public string? Position { get; set; } =string.Empty;
        public int? SupervisorId { get; set; }
        public decimal? Salary { get; set; }
        public int? DID { get; set; }
        public string? Image {  get; set; }
        public bool IsDisabled { get; set; }


        [ForeignKey(nameof(DID))]
        [InverseProperty("instractors")]
        public Department department { get; set; }

        [InverseProperty("instractor")]
        public Department departmentManger { get; set; }

        [ForeignKey("SupervisorId")]
        [InverseProperty("Instractors")]
        public Instractor Supervisor { get; set; }

        [InverseProperty("Supervisor")]
        public virtual  ICollection<Instractor> Instractors { get; set; } 

        [InverseProperty("instractor")]
        public ICollection<Ins_Subject> Ins_Subjects { get; set; }

    }
}
