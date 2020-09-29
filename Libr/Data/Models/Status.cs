using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Libr.Data.Models
{
    public enum Status
    {
        [Description("забронирован")]booked,
        //Забронирован,
        [Description( "Ожидает в библиотеке")] InLibraly,
        //[Description("Ожидает в библиотеке")] InLibraly,
        [Description("Выдан")] Issued,

    }
}
