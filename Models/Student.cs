namespace CrudEstudiantes.Models
{
    public class Student
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public int? Age { get; set; }  
		public bool? IsStudent { get; set; }  // El campo IsStudent es nullable, así que lo representamos como bool?
		public string Address { get; set; }
		public string Hobbies { get; set; }
	}
}
