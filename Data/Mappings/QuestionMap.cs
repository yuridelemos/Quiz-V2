using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz_V2.Models;
namespace Quiz_V2.Data.Mappings
{
    public class QuestionMap : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Question");

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder
                .Property(x => x.Body)
                .IsRequired()
                .HasColumnName("Body")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(2000);

            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Questions)
                .HasConstraintName("FK_Question_Category")
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasIndex(x => x.Body, "IX_Question_Body")
                .IsUnique();
        }
    }
}