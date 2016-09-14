using epicodus_dotnet_rpg.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace epicodus_dotnet_rpg.ViewModels
{
    
    public class ManageUserRolesViewModel
    {

        [Required]
        [Display(Name = "UserId")]
        public string UserId { get; set; }

        [Required]
        [Display(Name = "RoleName")]
        public string RoleName { get; set; }

    }
}
