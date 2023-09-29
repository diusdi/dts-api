﻿using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("tb_m_universities")]
    public class University : BaseEntitiy
    {
        [Column("code", TypeName = "nvarchar(50)")]
        public string Code { get; set; }
        [Column("name", TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        public ICollection<Education>? Educations { get; set; }
    }
}
