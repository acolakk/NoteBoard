using NoteBoard.DAL.Mapping;
using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NoteBoard.DAL
{
    public class NoteBoardDbContext : DbContext
    {
        public NoteBoardDbContext()
            : base("Server=.;Database=NoteBoard;Integrated Security")
        {
            Database.SetInitializer(new NoteBoardDbIntializer());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Password> Passwords { get; set; }
        public DbSet<Note> Notes { get; set; }
        
        
        //Dbye mapleri tanıtmak için
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new NoteMapping());
            modelBuilder.Configurations.Add(new PasswordMapping());
            modelBuilder.Configurations.Add(new UserMapping());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //Database adını (Kalem -- Kalems) yapmasın diye
        }

        
    }





}

