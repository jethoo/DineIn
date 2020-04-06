﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dineIN.Models.ViewModels
{
    public class DeleteRoleViewModel
    {
        public DeleteRoleViewModel()
        {
            Users = new List<string>();
        }
        public string Id { get; set; }
        [Required(ErrorMessage = "Role Name is required")]
        public string RoleName { get; set; }
        public List<string> Users { get; }
    }
}
