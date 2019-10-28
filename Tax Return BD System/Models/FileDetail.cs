﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tax_Return_BD_System.Models
{
    public class FileDetail
    {
        [Key]
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public Guid DocumentId { get; set; }

    }
}