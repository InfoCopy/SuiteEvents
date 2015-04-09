using SuiteEvents.ReadModel.Dtos;

namespace SuiteEvents.ReadModel.EntityFramework.Mappings
{
    public class SuiteUsersMap : BaseMapping<SuiteUsers>
    {
        public SuiteUsersMap() :
            base("SuiteUsers")
        {
            this.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("UserId");

            this.Property(t => t.ApplicationName)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnName("ApplicationName");

            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("UserName");

            this.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Password");

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnName("Email");

            this.Property(t => t.CreationDate)
                .HasColumnName("CreationDate");

            this.Property(t => t.LastLoginDate)
                .HasColumnName("LastLoginDate");

            this.Property(t => t.Cognome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Cognome");

            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Nome");

            this.Property(t => t.IsApproved)
                .HasColumnName("IsApproved");

            this.Property(t => t.IsLocked)
                .HasColumnName("IsLocked");
        }
    }
}
