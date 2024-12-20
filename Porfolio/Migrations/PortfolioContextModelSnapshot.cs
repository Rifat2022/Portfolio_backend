﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Porfolio.Data;

#nullable disable

namespace Porfolio.Migrations
{
    [DbContext(typeof(PortfolioContext))]
    partial class PortfolioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Porfolio.Model.CustomerReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FileDetailsId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quotation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReviewDescription")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("ReviewTime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FileDetailsId")
                        .IsUnique();

                    b.ToTable("CustomerReviews");
                });

            modelBuilder.Entity("Porfolio.Model.FileDetails", b =>
                {
                    b.Property<int>("FileDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FileDetailsId"));

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FileDetailsId");

                    b.ToTable("FileDetails");
                });

            modelBuilder.Entity("Porfolio.Model.OfferedService", b =>
                {
                    b.Property<int>("OfferedServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OfferedServiceId"));

                    b.Property<string>("bootstrap_icon_code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("headings")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("quote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("service_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OfferedServiceId");

                    b.ToTable("OfferedServices");
                });

            modelBuilder.Entity("Porfolio.Model.CustomerReview", b =>
                {
                    b.HasOne("Porfolio.Model.FileDetails", "FileDetails")
                        .WithOne()
                        .HasForeignKey("Porfolio.Model.CustomerReview", "FileDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FileDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
