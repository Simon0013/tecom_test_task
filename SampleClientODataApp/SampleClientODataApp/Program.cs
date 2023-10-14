using TecomWebApp.Models;

await ListEmployees();

static async Task ListEmployees()
{
    var serviceRoot = "http://localhost:5103/odata";
    var context = new Default.Container(new Uri(serviceRoot));

    IEnumerable<Employee> employees = await context.Employees.ExecuteAsync();
    foreach (var employee in employees)
    {
        var bossString = "";
        if (employee.BossId is not null)
            bossString = string.Format(" and his boss has Id = {0}", employee.BossId);
        Console.WriteLine("{0} {1} {2} is a {3}{4}", employee.Name, employee.Surname, employee.Patronymic, employee.JobName, bossString);
    }
}
