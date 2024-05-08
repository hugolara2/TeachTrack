namespace TeachTrack.Service.DTOs;

public class StudentDto {
   public int Studentid { get; set; }

   public string Name { get; set; } = null!;

   public string Lastname { get; set; } = null!;

   public decimal Score { get; set; }

   public int? Degreeid { get; set; }

   public int? Careerid { get; set; }

   public int? Semesterid { get; set; }

   public string? Status { get; set; }

   public int Career { get; set; }

   public int Degree { get; set; }

   public int Semester { get; set; }
}