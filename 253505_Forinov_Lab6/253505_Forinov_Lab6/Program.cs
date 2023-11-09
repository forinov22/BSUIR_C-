using System.Reflection;
using _253505_Forinov_Lab6.Entities;

List<Employee> employees = new List<Employee>
{
    new Employee("Сотрудник 1", 30, false),
    new Employee("Сотрудник 2", 25, false),
    new Employee("Сотрудник 3", 35, true),
    new Employee("Сотрудник 4", 28, false),
    new Employee("Сотрудник 5", 40, true),
    new Employee("Сотрудник 6", 22, false),
};

var assembly = Assembly.LoadFrom(@"net7.0/FileService.dll") ?? throw new NullReferenceException("No such assembly");

var genericType = assembly.GetType("FileService.FileService`1") ?? throw new NullReferenceException("No such type");

Type[] typeArguments = { typeof(Employee) };

var specifiedType = genericType.MakeGenericType(typeArguments);

var instance = Activator.CreateInstance(specifiedType) ?? throw new NullReferenceException("No such instance");

var methodInfo1 = specifiedType.GetMethod("SaveData") ?? throw new NullReferenceException("No such method");
var methodInfo2 = specifiedType.GetMethod("ReadFile") ?? throw new NullReferenceException("No such method");

methodInfo1.Invoke(instance, new object[] { employees, "collection.json" });
var result2 = methodInfo2.Invoke(instance, new object[] { "collection.json" }) as IEnumerable<Employee>
    ?? throw new NullReferenceException();

foreach (var e in result2) {
    System.Console.WriteLine($"Name: {e.Name}, age: {e.Age}, manager: {e.IsManager}");
}
