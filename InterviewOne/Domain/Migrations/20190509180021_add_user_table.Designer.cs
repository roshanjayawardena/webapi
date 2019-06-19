﻿// <auto-generated />
using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Domain.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20190509180021_add_user_table")]
    partial class add_user_table
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Employee.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("Dob");

                    b.Property<int?>("EditedById");

                    b.Property<DateTime?>("EditedOn");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("RecordStatus");

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Domain.Security.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int?>("EditedById");

                    b.Property<DateTime?>("EditedOn");

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("Password");

                    b.Property<int>("RecordStatus");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
