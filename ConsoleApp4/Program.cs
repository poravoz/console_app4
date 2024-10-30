using ConsoleApp4;
using System.Reflection;

public class Program
{
	public static void Main()
	{
		// Type
		Console.WriteLine("Type");
		var assembly = Assembly.GetExecutingAssembly();
		var types = assembly.GetTypes();
		foreach (var type in types)
		{
			var typeInfo = type.GetTypeInfo();
			Console.WriteLine("Type " + type.FullName + " has " + typeInfo.DeclaredProperties.Count().ToString() + " properties");
		}
		Console.WriteLine();

		// TypeInfo
		Console.WriteLine("TypeInfo");
		TypeInfo personInfo = typeof(Person).GetTypeInfo();
		IEnumerable<PropertyInfo> declaredProperties = personInfo.DeclaredProperties;
		Console.WriteLine("Властивостi класу:");
		foreach (PropertyInfo property in declaredProperties)
		{
			Console.WriteLine($"{property.Name} (тип: {property.PropertyType})");
		}

		IEnumerable<MethodInfo> declaredMethods = personInfo.DeclaredMethods;
		Console.WriteLine("\nМетоди класу:");
		foreach (MethodInfo method in declaredMethods)
		{
			Console.WriteLine($"{method.Name}");
		}
		Console.WriteLine();

		// Member Info
		Console.WriteLine("MemberInfo");
		Console.WriteLine("Single Type is {0}\n", personInfo);
		MemberInfo[] mbrInfoArray = personInfo.GetMembers();
		foreach (MemberInfo mbrInfo in mbrInfoArray)
		{
			Console.WriteLine("{0}			{1}", mbrInfo.MemberType, mbrInfo.Name);
		}
		Console.WriteLine();

		// FieldInfo
		Console.WriteLine("FieldInfo");
		FieldInfo[] fields = personInfo.DeclaredFields.ToArray();
		foreach (FieldInfo field in fields)
		{
			Console.WriteLine($"{field.Name} (тип: {field.FieldType}) - Доступ: {field.Attributes}");
		}
		Console.WriteLine();

		//Reflection
		Console.WriteLine("Reflection");
		Person person = new Person("Микола", "Рудь", 19, 175, false);
		MethodInfo checkMarriedStatusMethod = personInfo.GetMethod("CheckMarriedStatus");
		string marriedStatus = (string)checkMarriedStatusMethod.Invoke(person, null);
		Console.WriteLine($"Статус: {marriedStatus}");
	}
}