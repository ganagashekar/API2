using EMSVAPIModel;
using EMSVExtentions;
using EMSVUAPIBusiness.Respositories.IServices;
using EMSVWPIDataContext;
using EMSVWPIDataContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace EMSVUAPIBusiness.Respositories.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly DatabaseContext _dbContext;

        public AccountServices()
        {
            _dbContext = new DatabaseContext();
        }


        public async Task<User_Model> ValidateUser(string UserName, string Password)
        {
            string encryptedpass = Password.Encrypt();
            var validatedUser = _dbContext.dl_usrs.Include(x => x.dl_vendor_sites).Include(x => x.dl_vendor_sites.dl_Site)
                .Include(x => x.userRoles).Include(x => x.userRoles.roles).FirstOrDefault(user => user.usr_name.Equals(UserName) && user.pass.Equals(encryptedpass));
            if (validatedUser.IsNotNull())
                return await Task.FromResult(validatedUser.ToDestination<dl_usr, User_Model>());
            return null;

        }
    }
}
