using CoreFrameWork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TestModularityAndEFCore.Events;

namespace TestModularityAndEFCore.Entities
{
    [Table("Student")]
    public class Student: IEntity //AddStudentEvent// 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
