using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;//Kalıtım vermeden önce eklemeliyiz
using NoteBoard.Model;

namespace NoteBoard.DAL.Mapping
{
    class PasswordMapping:EntityTypeConfiguration<Password>
    {
        public PasswordMapping()
        {
            Property(p => p.PasswordText).IsRequired().HasMaxLength(16);

            HasRequired(a => a.User).WithMany(a => a.Passwords).HasForeignKey(a => a.UserID);

            HasKey(p => p.PasswordNum);
            Property(p => p.PasswordNum).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

        }
    }
}
