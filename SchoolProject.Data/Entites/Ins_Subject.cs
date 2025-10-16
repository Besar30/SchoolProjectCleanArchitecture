using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entites
{
    public class Ins_Subject
    {
        [Key]
        public int InsId { get; set; }
        [Key]
        public int SubId { get; set; }
        [ForeignKey("InsId")]
        [InverseProperty("Ins_Subjects")]
        public Instractor? instractor { get; set; }
        [ForeignKey("SubId")]
        [InverseProperty("InsSubjects")]
        public Subject? subject { get; set; }


    }
}
