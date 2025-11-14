using Data;
using Data.ConnectionConfig;
using Services.Providers.Students;

namespace BackEndTest;

internal class Program
{
    private static void Main(string[] args)
    {
        ConnectionStringProvider connection = new ConnectionStringProvider();
        ApplicationContext context = new ApplicationContext(connection);

        StudentProvider studentProvider = new StudentProvider(context);

        foreach (var s in studentProvider.GetStudents(11, 'd'))
        {
            Console.WriteLine(s.FullName);
        }

        context.Dispose();
    }
}
