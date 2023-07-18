
using Microsoft.EntityFrameworkCore;
using Quiz_V2.Models;

namespace Quiz_V2.Data.Mappings
{
    public class AnswerMap : IEntityTypeConfiguration<Answer>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Answer> builder)
        {
            builder.ToTable("Answer");

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder
            .Property(x => x.AnswerOrder)
            .IsRequired()
            .HasDefaultValue(0);

            builder
                .Property(x => x.Body)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(2000);

            builder
                .Property(x => x.IsCorrect)
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .HasOne(x => x.Question)
                .WithMany(x => x.Answers)
                .HasConstraintName("FK_Answers_Question")
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasIndex(x => x.Body, "IX_Answers_Body")
                .IsUnique();
        }
    }
}