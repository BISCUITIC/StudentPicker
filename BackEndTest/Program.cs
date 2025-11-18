using Application.Interfaces;
using Domain.Entities;
using Infrastructure;
using Infrastructure.ConnectionConfig;
using Infrastructure.Repositories;

namespace BackEndTest;

internal class Program
{
    private static void Main(string[] args)
    {
        IConnectionStringProvider connection = new ConnectionStringProvider();

        using (ApplicationContext context = new ApplicationContext(connection))
        {
            IGroupRepository groupProvider = new GroupRepository(context);
            IStudentRepository studentProvider = new StudentRepository(context);

            Group group = groupProvider.Get(11, 'A');
            List<Student> students = studentProvider.GetByGroup(group);

            foreach (Student student in students)
            {
                Console.WriteLine(student.FullName);
            }
        }
    }
}
