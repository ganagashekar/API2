using EMSVAPIModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMSVUAPIBusiness.Respositories.IServices
{
   public  interface IAccountServices
    {
        Task<User_Model> ValidateUser(string UserName, string Password);
    }
}
