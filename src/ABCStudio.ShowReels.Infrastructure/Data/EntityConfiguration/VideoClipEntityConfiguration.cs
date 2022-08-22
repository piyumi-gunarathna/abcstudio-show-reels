using System.Text.Json;
using ABCStudio.ShowReels.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ABCStudio.ShowReels.Infrastructure.Data.EntityConfiguration
{
    internal class VideoClipEntityConfiguration: IEntityTypeConfiguration<VideoClip>
    {
        public void Configure(EntityTypeBuilder<VideoClip> builder)
        {
            builder.ToTable("VideoClips");
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(v => v.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(v => v.Description)
                .HasColumnName("Description")
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(v => v.Definition)
                .HasColumnName("Definition")
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(v => v.Standard)
                .HasColumnName("Standard")
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(v => v.StartTimeCode)
                .HasColumnName("StartTimeCode")
                .HasColumnType("varchar(200)")
                .HasConversion(
                    t => JsonSerializer.Serialize(t, new JsonSerializerOptions { WriteIndented = false }),
                    t => JsonSerializer.Deserialize<TimeCode>(t, new JsonSerializerOptions { WriteIndented = false }))
                .IsRequired();

            builder.Property(v => v.EndTimeCode)
                .HasColumnName("EndTimeCode")
                .HasColumnType("varchar(200)")
                .HasConversion(
                    t => JsonSerializer.Serialize(t, new JsonSerializerOptions { WriteIndented = false }),
                    t => JsonSerializer.Deserialize<TimeCode>(t, new JsonSerializerOptions { WriteIndented = false }))
                .IsRequired();
        }
    }
}

