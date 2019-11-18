using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.DAL.Repositories
{
    public class PasswordDAL
    {
        NoteBoardDbContext _db;
        public PasswordDAL()
        {
            _db = new NoteBoardDbContext();
        }

        public int Add(Password password)
        {
            _db.Passwords.Add(password);
            return _db.SaveChanges();
        }

        public int Delete(Password password)
        {
            _db.Entry(password).State = EntityState.Deleted;
            return _db.SaveChanges();
        }

        public int Update(Password password)
        {
            _db.Entry(password).State = EntityState.Modified;
            return _db.SaveChanges();
        }

        public List<Password> GetAll()
        {
            return _db.Passwords.ToList();
        }

        public Password GetByID(int passwordID)
        {
            return _db.Passwords.FirstOrDefault(a => a.PasswordNum == passwordID);
        }

       
    }
}
