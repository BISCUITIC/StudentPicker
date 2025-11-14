using Data;
using Data.ConnectionConfig;
using Services.Providers.Srudent;

namespace BackEndTest;

internal class Program
{
    private static void Main(string[] args)
    {
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
