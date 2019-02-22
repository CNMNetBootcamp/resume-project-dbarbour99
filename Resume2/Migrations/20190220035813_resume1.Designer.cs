﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Resume2.Data;
using System;

namespace Resume2.Migrations
{
    [DbContext(typeof(Resume2Context))]
    [Migration("20190220035813_resume1")]
    partial class resume1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Resume2.Models.Duty", b =>
                {
                    b.Property<int>("DutyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("ExperienceID");

                    b.Property<int>("Priority");

                    b.HasKey("DutyID");

                    b.HasIndex("ExperienceID");

                    b.ToTable("Duty");
                });

            modelBuilder.Entity("Resume2.Models.Education", b =>
                {
                    b.Property<int>("EducationID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Degree");

                    b.Property<string>("EndDate");

                    b.Property<string>("Institution");

                    b.Property<int>("ResumeID");

                    b.Property<string>("StartDate");

                    b.Property<string>("State");

                    b.HasKey("EducationID");

                    b.HasIndex("ResumeID");

                    b.ToTable("Education");
                });

            modelBuilder.Entity("Resume2.Models.Experience", b =>
                {
                    b.Property<int>("ExperienceID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Company");

                    b.Property<string>("CompanyDesc");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("JobTitle");

                    b.Property<string>("Position");

                    b.Property<int>("ResumeID");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("ExperienceID");

                    b.HasIndex("ResumeID");

                    b.ToTable("Experience");
                });

            modelBuilder.Entity("Resume2.Models.Reference", b =>
                {
                    b.Property<int>("ReferenceID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Company");

                    b.Property<string>("FirstLast");

                    b.Property<string>("Position");

                    b.Property<int>("ResumeID");

                    b.HasKey("ReferenceID");

                    b.HasIndex("ResumeID");

                    b.ToTable("Reference");
                });

            modelBuilder.Entity("Resume2.Models.Resume", b =>
                {
                    b.Property<int>("ResumeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .HasMaxLength(20);

                    b.Property<string>("Email");

                    b.Property<string>("FirstLast")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Phone");

                    b.Property<string>("State")
                        .HasMaxLength(2);

                    b.Property<string>("Summary");

                    b.HasKey("ResumeID");

                    b.ToTable("Resume");
                });

            modelBuilder.Entity("Resume2.Models.Duty", b =>
                {
                    b.HasOne("Resume2.Models.Experience", "Experience")
                        .WithMany("Duty")
                        .HasForeignKey("ExperienceID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Resume2.Models.Education", b =>
                {
                    b.HasOne("Resume2.Models.Resume", "Resume")
                        .WithMany("Education")
                        .HasForeignKey("ResumeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Resume2.Models.Experience", b =>
                {
                    b.HasOne("Resume2.Models.Resume", "Resume")
                        .WithMany("Experience")
                        .HasForeignKey("ResumeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Resume2.Models.Reference", b =>
                {
                    b.HasOne("Resume2.Models.Resume", "Resume")
                        .WithMany("Reference")
                        .HasForeignKey("ResumeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}