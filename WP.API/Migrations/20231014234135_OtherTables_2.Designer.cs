﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WP.DAL.Context;

#nullable disable

namespace WP.API.Migrations
{
    [DbContext(typeof(WorkPlaceContext))]
    [Migration("20231014234135_OtherTables_2")]
    partial class OtherTables_2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusinessLocationEmployee", b =>
                {
                    b.Property<long>("BusinessLocationsBusinessLocationId")
                        .HasColumnType("bigint");

                    b.Property<long>("EmployeesEmployeeId")
                        .HasColumnType("bigint");

                    b.HasKey("BusinessLocationsBusinessLocationId", "EmployeesEmployeeId");

                    b.HasIndex("EmployeesEmployeeId");

                    b.ToTable("BusinessLocationEmployee");
                });

            modelBuilder.Entity("CustomerEmployee", b =>
                {
                    b.Property<long>("CustomersCustomerId")
                        .HasColumnType("bigint");

                    b.Property<long>("EmployeesEmployeeId")
                        .HasColumnType("bigint");

                    b.HasKey("CustomersCustomerId", "EmployeesEmployeeId");

                    b.HasIndex("EmployeesEmployeeId");

                    b.ToTable("CustomerEmployee");
                });

            modelBuilder.Entity("WP.DAL.Entities.BusinessLocation", b =>
                {
                    b.Property<long>("BusinessLocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("BusinessLocationId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelephoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BusinessLocationId");

                    b.HasIndex("CustomerId");

                    b.ToTable("BusinessLocation");
                });

            modelBuilder.Entity("WP.DAL.Entities.Customer", b =>
                {
                    b.Property<long>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CustomerId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WP.DAL.Entities.Employee", b =>
                {
                    b.Property<long>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("EmployeeId"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("BusinessLocationEmployee", b =>
                {
                    b.HasOne("WP.DAL.Entities.BusinessLocation", null)
                        .WithMany()
                        .HasForeignKey("BusinessLocationsBusinessLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WP.DAL.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CustomerEmployee", b =>
                {
                    b.HasOne("WP.DAL.Entities.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomersCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WP.DAL.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WP.DAL.Entities.BusinessLocation", b =>
                {
                    b.HasOne("WP.DAL.Entities.Customer", "Customer")
                        .WithMany("BusinessLocations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("WP.DAL.Entities.Customer", b =>
                {
                    b.Navigation("BusinessLocations");
                });
#pragma warning restore 612, 618
        }
    }
}
