using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;//Kalıtım vermeden önce eklemeliyiz
using NoteBoard.Model;

namespace NoteBoard.DAL.Mapping
{
    class UserMapping:EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            Property(a => a.FirstName).IsRequired().HasMaxLength(20);
            Property(a => a.LastName).IsRequired().HasMaxLength(30);
            Property(a => a.UserName).IsRequired().HasMaxLength(18);
            Property(a => a.UserID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Map(a => a.MapInheritedProperties());//-> Aynı yerde tutmak için basedeki propertyleremizi de eklemiş oluyoruz.
            HasIndex(a => a.UserName).IsUnique();
        }
    }
}
