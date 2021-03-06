﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using NWSolution.DAL;
using System;

namespace NWSolution.Migrations
{
    [DbContext(typeof(NWSolutionContext))]
    [Migration("20171107232830_login")]
    partial class login
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NWSolution.Models.NW", b =>
                {
                    b.Property<int>("id");

                    b.Property<string>("Latitude");

                    b.Property<string>("Longtitude");

                    b.Property<string>("deviceosversion");

                    b.Property<string>("network");

                    b.Property<string>("problem_date");

                    b.Property<string>("problem_note");

                    b.Property<string>("problem_type");

                    b.Property<string>("report_date");

                    b.Property<string>("user_devicetype");

                    b.Property<string>("user_deviceversion");

                    b.Property<string>("user_email");

                    b.Property<string>("user_name");

                    b.Property<string>("user_phonenumber");

                    b.HasKey("id");

                    b.ToTable("nw");
                });

            modelBuilder.Entity("NWSolution.Models.SessionToken", b =>
                {
                    b.Property<Guid>("SessionID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Token")
                        .HasMaxLength(16);

                    b.HasKey("SessionID");

                    b.ToTable("SessionToken");
                });
#pragma warning restore 612, 618
        }
    }
}
