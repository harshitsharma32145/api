namespace SixthTokenApi.ViewModel
{
    public class ResponseModel
    {
        public class Response
        {
            public string? responsemessage { get; set; }
            public int? responsecode { get; set; }

            public string? Token { get; set; }
        }
         

        public class employee
        {
            public int EmployeeId { get; set; }
            public string EmployeeName { get; set; } = null!;
            public int EmployeeAge { get; set; }
            
        }
       }
}
