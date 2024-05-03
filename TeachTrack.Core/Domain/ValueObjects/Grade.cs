namespace TeachTrack.Service.Domain.ValueObjects;

public class Grade {
   public float Value { get; set; }

   public Grade(float value) {
      if (value < 0 || value > 100)
         throw new ArgumentOutOfRangeException("Grade must be between 0 and 100 ");
      Value = value;
   }
}