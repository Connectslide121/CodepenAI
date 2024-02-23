using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Core
{
    public class User : IdentityUser
    {
        public DateTime RegistrationDate { get; set; }
        public List<Project> Projects { get; set; }
    }
}
