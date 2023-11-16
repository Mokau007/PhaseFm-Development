using System;
using System.Collections.Generic;

namespace PhaseFmApi;

public partial class Employee
{
    public int Id { get; set; }

    public int EmployeeTypeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual Employeetype EmployeeType { get; set; } = null!;
}
