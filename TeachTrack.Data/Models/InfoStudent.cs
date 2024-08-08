using System;
using System.Collections.Generic;

namespace TeachTrack.Data.Models;

public partial class InfoStudent
{
    public int Studentid { get; set; }

    public string Schoolemail { get; set; } = null!;

    public string Personalemail { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public DateOnly Dob { get; set; }

    public virtual Student Student { get; set; } = null!;
}
