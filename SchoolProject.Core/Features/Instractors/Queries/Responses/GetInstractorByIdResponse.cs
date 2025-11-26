using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Instractors.Queries.Responses
{
    public class GetInstractorByIdResponse
    {
        public int InsId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int? Salary { get; set; }
        public string? ImageFile { get; set; }
        public string? InstractorWorkForDepartmentName { get; set; }
        public string? InstractorManageForDepartmentName { get; set; }
        public string Position { get; set; }
        public string Supervied { get; set; }
        public List<SubjectResponse>? Subjects {  get; set; }
    }
    public class SubjectResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }

    }
}

//public string? ENameAr { get; set; } = string.Empty;
//public string? ENameEn { get; set; } = string.Empty;
//public string? Address { get; set; } = string.Empty;
//public string? Position { get; set; } = string.Empty;
//public int? SupervisorId { get; set; }
//public decimal? Salary { get; set; }
//public int? DID { get; set; }
//public string? Image { get; set; }

//[ForeignKey(nameof(DID))]
//[InverseProperty("instractors")]
//public Department department { get; set; }

//[InverseProperty("instractor")]
//public Department departmentManger { get; set; }

//[ForeignKey("SupervisorId")]
//[InverseProperty("Instractors")]
//public Instractor Supervisor { get; set; }

//[InverseProperty("Supervisor")]
//public virtual ICollection<Instractor> Instractors { get; set; }

//[InverseProperty("instractor")]
//public ICollection<Ins_Subject> Ins_Subjects { get; set; }