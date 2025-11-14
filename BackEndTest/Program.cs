using Data;
using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace BackEndTest;

internal class Program
{
    static void Main(string[] args)
    {
        Group group1 = new Group(11, 'A');
        Group group2 = new Group(11, 'Б');
        Group group3 = new Group(11, 'В');
        //Group group4 = new Group(11, 'Г');

        Student student1 = new Student("Тимлфей", "Сосновский", group1);
        Student student2 = new Student("Артемий", "Шелюто", group1);
        Student student3 = new Student("Тима", "Потапенко", group3);
        

        using (ApplicationContext context = new ApplicationContext())
        {
            var group = context.Groups.FirstOrDefault(group => group.Letter == 'А') ?? 
                        throw new NullReferenceException();

            Student student = new Student("Тимлфей", "Сосновский", group);

            context.Students.Add(student);
            context.SaveChanges();
        }

    }
}
