using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace NoteBoard.DAL.Repositories
{
    public class UserDAL
    {
        NoteBoardDbContext _db;

        public UserDAL()
        {
            _db = new NoteBoardDbContext();
        }

        public int Add(User user)
        {
            _db.Entry(user).State = EntityState.Added;
            //Savechanges->execute non cury i çalıştırır
            //_db.Users.Add(user);
            return _db.SaveChanges();
        }

        public int Update(User User)
        {
            _db.Entry(User).State = EntityState.Modified;
            return _db.SaveChanges();
        }

        public int Delete(User User)
        {
            _db.Entry(User).State = EntityState.Deleted;
            return _db.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public User GetByID(int UserID)
        {
            //Hepsine baksın eşleşenlerden ilkini getirsin
            return _db.Users.FirstOrDefault(a => a.UserID == UserID);
        }
    }
}
