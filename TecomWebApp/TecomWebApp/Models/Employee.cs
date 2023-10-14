using System;
using System.Collections.Generic;

namespace TecomWebApp.Models;

public partial class Employee
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string JobName { get; set; } = null!;

    public long? BossId { get; set; }

    public virtual Employee? Boss { get; set; }

    public virtual ICollection<Employee> InverseBoss { get; set; } = new List<Employee>();
}
