using System;
using System.Collections.Generic;

namespace SixthTokenApi.Models
{
    public partial class Harshit20
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public int EmployeeAge { get; set; }
        public string? EmployeePhoneNo { get; set; }
        public string? EmployeeEmail { get; set; }
        public string? EmployeeAddress { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
