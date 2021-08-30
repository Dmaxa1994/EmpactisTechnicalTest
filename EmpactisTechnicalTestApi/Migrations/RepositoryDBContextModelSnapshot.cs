﻿// <auto-generated />
using System;
using EmpactisTechnicalTestApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmpactisTechnicalTestApi.Migrations
{
    [DbContext(typeof(RepositoryDBContext))]
    partial class RepositoryDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmpactisTechnicalTestApi.Model.Absence", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AbsenceType")
                        .HasColumnType("int")
                        .HasColumnName("Type");

                    b.Property<int>("EmployeeNumber")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeId");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime")
                        .HasColumnName("End");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime")
                        .HasColumnName("Start");

                    b.HasKey("ID");

                    b.ToTable("Absences");
                });

            modelBuilder.Entity("EmpactisTechnicalTestApi.Model.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Department");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<int>("EmployeeNumber")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeNumber");

                    b.HasKey("ID");

                    b.ToTable("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
