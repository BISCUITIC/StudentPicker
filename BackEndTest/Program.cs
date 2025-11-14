using Data;
using Data.ConnectionConfig;
using Data.Model;
using Microsoft.EntityFrameworkCore;

using Services;

namespace BackEndTest;

internal class Program
{
    static void Main(string[] args)
    {
        //Group group1 = new Group(11, 'A');
        //Group group2 = new Group(11, 'Б');
        //Group group3 = new Group(11, 'В');
        //Group group4 = new Group(11, 'A');




        //using (ApplicationContext context = new ApplicationContext())
        //{
        //    var group = context.Groups.FirstOrDefault(group => group.Id == 1);
        //    Student student1 = new Student("Тимлфей", "Сосновский", group);
        //    Student student2 = new Student("Артемий", "Шелюто", group);
        //    Student student3 = new Student("Тима", "Потапенко", group);

        //    context.AddRange(student1, student2, student3);
        //    context.SaveChanges();
        //}
        ConnectionStringProvider connection = new ConnectionStringProvider();
        ApplicationContext context = new ApplicationContext(connection);

        StudentProvider studentProvider = new StudentProvider(context);
        
        foreach (var s in studentProvider.GetStudents(11, 'A'))
        {
            Console.WriteLine(s.FullName);
        }


        context.Dispose();
    }
}
