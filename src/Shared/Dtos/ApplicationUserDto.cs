﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public class ApplicationUserDto
    {
        public int AppUserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
    }
}
