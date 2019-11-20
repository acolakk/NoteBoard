using NoteBoard.DAL.Repositories;
using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.BLL
{
    class UserController
    {
        UserDAL _userDAL;

        public UserController()
        {
            _userDAL = new UserDAL();
        }

        public bool Add(User user)
        {
            //Kullanıcı kayıt olduktan sonra kullanıcı hesabı admin onayından geçmeden kullanıcı giriş yapamasın.

            try
            {
                if (user.Passwords.Count > 0)
                {
                    user.IsActive = false;
                    user.CreatedDate = DateTime.Now;
                    user.Passwords.First().IsActive = true;
                    user.Passwords.First().CreatedDate = DateTime.Now;
                    //Admin onayıyla beraber 

                    _userDAL.Add(user);
                    return true;
                }
                else
                {
                    throw new Exception("Şifre Yok!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        public bool Update(User user)
        {
            try
            {
                user.ModifedDate = DateTime.Now;
                _userDAL.Update(user);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Delete(User user)
        {
            user.IsActive = false;
            return Update(user);
            //Hesap 30 günden fazla pasif kalırsa veritaanından silinsin.
        }

        public User GetByID(int userID)
        {
            return _userDAL.GetByID(userID);
        }

        public User GetByLogin(string username,string password)
        {
            List<User> users = _userDAL.GetAll();
            User user = users.Where(a => a.IsActive && a.UserName == username).Single();//Hata versin dediğimiz için

            if (user !=null)
            {
                Password pass = user.Passwords.Where(a => a.IsActive && a.PasswordText == password).Single();
                if (pass==null)
                {
                    return null;
                }
            }
                return user;
        }

        public List<User> GetAll()
        {
            return _userDAL.GetAll();
        }
    }
}
