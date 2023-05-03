using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SixthTokenApi.Models;
using SixthTokenApi.ViewModel;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static SixthTokenApi.ViewModel.ResponseModel;

namespace SixthTokenApi.Repository
{
    public class Employee : IEmployee
    {                      
  
         private IConfiguration _config;
        public Employee(IConfiguration obj)
        {
            _config = obj;

        }

                    private string GenerateJSONWebToken(LoginModel userInfo)
                    {
                        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                        var claims = new List<Claim>
                         {
                         new Claim(ClaimTypes.Name, userInfo.UserName),
                         new Claim(ClaimTypes.Email, "admin@gmail.com"),
                         new Claim(ClaimTypes.Sid, "101"),
                         new Claim(ClaimTypes.Role , "admin"),
                         new Claim(ClaimTypes.Role , "Employee")
                         };



                        claims.Add(new Claim(ClaimTypes.Role, "Admin"));



                        var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                                 _config["Jwt:Issuer"],
                                      claims,
                                      expires: DateTime.Now.AddMinutes(120),
                                      signingCredentials: credentials);
                                    return new JwtSecurityTokenHandler().WriteToken(token);
                                }
                 
      

        public Response Login(LoginModel data)
        {
            Response response = new Response();
            sdirectdbContext sdirectdb = new sdirectdbContext();
            var user = sdirectdb.Logins.Where(h => h.Username == data.UserName && h.Password == data.Password).FirstOrDefault();
            if (user != null)
            {
                response.responsecode = 200;
                response.responsemessage = "Success";
                response.Token = GenerateJSONWebToken(data);
                return response;
            }           
            response.responsecode = 400;
            response.responsemessage = "failed";
            return response;
        }

        public List<employee> GetRecord()

        {
            sdirectdbContext sdirectdb = new sdirectdbContext();
            var data = (from emp in sdirectdb.Harshit20s
                        select new employee
                        {
                            EmployeeId = emp.EmployeeId,
                            EmployeeName = emp.EmployeeName,
                            EmployeeAge = emp.EmployeeAge,
                        }).ToList();

            return data;
            
        }

     


    }
}
