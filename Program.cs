using Seção17_Exercicio1.Entities;
using System.Globalization;

namespace /*Insira aqui o seu nameSpace*/
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            Console.WriteLine("Enter full file path: ");
            string arquivo = Console.ReadLine();

            Console.WriteLine("Enter salary: ");
            double salario = double.Parse(Console.ReadLine());

            string[] lines = File.ReadAllLines(arquivo);

            try
            {
                using (StreamReader sr = File.OpenText(arquivo))
                {
                    foreach (string line in lines)
                    {
                        string[] matriz = line.Split(',');
                        string name = matriz[0];
                        string email = matriz[1];
                        double salary = double.Parse(matriz[2], CultureInfo.InvariantCulture);

                        employees.Add(new Employee(name, email, salary));
                    }
                }

                var r1 = employees.Where(p => p.Salary > salario).OrderBy(p => p.Email).Select(p => p.Email);
                Console.WriteLine("Email of people whose salary is more than " + salario.ToString("F2", CultureInfo.InvariantCulture) + ":");

                foreach (var emp in r1)
                {
                    Console.WriteLine(emp);
                }

                var r2 = employees.Where(p => p.Name[0] == 'M').Sum(p => p.Salary);
                Console.WriteLine("Sum of salary of people whose name starts with 'M': " + r2.ToString("F2", CultureInfo.InvariantCulture));
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error ocurred");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
