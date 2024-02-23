namespace TeachTrack.Service.Domain.Model.Person;

public class Person {
   protected string Name { get; set; }
   protected string LastName { get; set; }

   protected Person(string name, string lastName) {
      Name = name;
      LastName = lastName;
   }
}