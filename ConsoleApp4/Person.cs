

using System.Reflection;

namespace ConsoleApp4
{
	public class Person
	{
		public string FirstName { get; set; }
		private string LastName { get; set; }
		protected int Age { get; set; }
		internal double Height { get; set; }
		private bool isMarried;

		public Person(string firstName, string lastName, int age, double height, bool isMarried)
		{
			FirstName = firstName;
			LastName = lastName;
			Age = age;
			Height = height;
			this.isMarried = isMarried;
		}

		public string GetFullName()
		{
			return $"{FirstName} {LastName}";
		}

		public void Salutation()
		{
			Console.WriteLine($"Привіт, мене звати {GetFullName()}!");
		}

		public string CheckMarriedStatus()
		{
			return isMarried ? "Одружений/Заміжня" : "Неодружений/Неодружена";
		}
	}
}
