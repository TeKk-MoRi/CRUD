using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.User
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
