using SixthTokenApi.Models;
using SixthTokenApi.ViewModel;
using static SixthTokenApi.ViewModel.ResponseModel;

namespace SixthTokenApi.Repository
{
    public interface IEmployee
    {


        public Response Login(LoginModel data);
        public List<employee> GetRecord();

    }
}
