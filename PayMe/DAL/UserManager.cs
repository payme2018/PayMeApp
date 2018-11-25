using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class UserManager
    {
        public Registration ValidateUser(string userName, string passWord)
        {
            try
            {
                using (var _context = new DatabaseContext())
                {

                    var test = _context.Registration;
                    var validate = (from user in _context.Registration
                                    where user.Username == userName && user.Password == passWord
                                    select user).SingleOrDefault();

                    return validate;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
