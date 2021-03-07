﻿// <auto-generated />
using System;
using LeaveRequest.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LeaveRequest.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210305100528_addModelLR")]
    partial class addModelLR
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LeaveRequest.Models.Account", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NIK");

                    b.ToTable("TB_M_Account");
                });

            modelBuilder.Entity("LeaveRequest.Models.Parameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TB_M_Parameter");
                });

            modelBuilder.Entity("LeaveRequest.Models.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApprovedHRD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApprovedManager")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReasonRequest")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UploadProof")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NIK");

                    b.ToTable("TB_M_Request");
                });

            modelBuilder.Entity("LeaveRequest.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("TB_M_Role");
                });

            modelBuilder.Entity("LeaveRequest.Models.User", b =>
                {
                    b.Property<string>("NIK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("MarriedStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(12)")
                        .HasMaxLength(12);

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RemainingQuota")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("NIK");

                    b.HasIndex("RoleId");

                    b.ToTable("TB_M_User");
                });

            modelBuilder.Entity("LeaveRequest.Models.Account", b =>
                {
                    b.HasOne("LeaveRequest.Models.User", "User")
                        .WithOne("Account")
                        .HasForeignKey("LeaveRequest.Models.Account", "NIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LeaveRequest.Models.Request", b =>
                {
                    b.HasOne("LeaveRequest.Models.User", "User")
                        .WithMany("Request")
                        .HasForeignKey("NIK");
                });

            modelBuilder.Entity("LeaveRequest.Models.User", b =>
                {
                    b.HasOne("LeaveRequest.Models.Role", "Role")
                        .WithMany("User")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
