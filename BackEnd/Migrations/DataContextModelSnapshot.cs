// <auto-generated />
using BackEnd.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackEnd.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BackEnd.Models.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("Sigla")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("BackEnd.Models.Municipio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<int>("Populacao")
                        .HasColumnType("int");

                    b.Property<string>("Prefeito")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Municipio");
                });

            modelBuilder.Entity("BackEnd.Models.Municipio", b =>
                {
                    b.HasOne("BackEnd.Models.Estado", "Estado")
                        .WithMany("Municipios")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
