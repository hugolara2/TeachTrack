namespace TeachTrack.Service.DTOs;

public class CareerDto {
   public int Careerid { get; set; }

   public string Name { get; set; } = null!;

   public string Shortname { get; set; } = null!;

   public string Description { get; set; } = null!;

   public string? Status { get; set; }
}