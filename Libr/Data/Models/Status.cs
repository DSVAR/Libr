﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Libr.Data.Models
{
    public enum Status
    {
        Забронирован,
        [Display(Name ="Ожидает в библиотеке")] Libraly,
        выдан

    }
}