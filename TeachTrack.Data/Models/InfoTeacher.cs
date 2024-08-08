using System;
using System.Collections.Generic;

namespace TeachTrack.Data.Models;

public partial class InfoTeacher
{
    public int Teacherid { get; set; }

    public string Schoolemail { get; set; } = null!;

    public string Personalemail { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public string Cedula { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public DateOnly Dob { get; set; }

    public virtual Teacher Teacher { get; set; } = null!;
}
