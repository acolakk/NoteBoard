using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;//Kalıtım vermeden önce eklemeliyiz
using NoteBoard.Model;

namespace NoteBoard.DAL.Mapping
{
    class NoteMapping:EntityTypeConfiguration<Note>
    {

        public NoteMapping()
        {
            Property(a => a.Tile).
                IsRequired()
                .HasMaxLength(25);
            Property(a => a.Content)
                .IsRequired()
                .HasMaxLength(250);
            HasRequired(a => a.User)
                .WithMany(a => a.Notes)
                .HasForeignKey(a => a.UserID);
            Map(a => a.MapInheritedProperties());

            HasKey(a => a.NoteID);
            Property(a => a.NoteID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

        }
    }
}
