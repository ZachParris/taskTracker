using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TaskTracker.Data;

namespace TaskTracker.Migrations
{
    [DbContext(typeof(BangazonContext))]
    [Migration("20170119010850_PleaseWork")]
    partial class PleaseWork
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaskTracker.Models.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CompletedOn");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("ToDo");
                });
        }
    }
}
