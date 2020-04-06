using System;
using System.ComponentModel.DataAnnotations;

namespace dineIN.Models.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
