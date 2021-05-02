﻿// <auto-generated />
using System;
using Bistrotic.Infrastructure.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bistrotic.Infrastructure.EfCore.Migrations
{
    [DbContext(typeof(StateStoreDbContext))]
    [Migration("20210502124020_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bistrotic.Infrastructure.EfCore.Repositories.OutboxMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CausationId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorrelationId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Event")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("InProgressSince")
                        .HasColumnType("datetime2");

                    b.Property<string>("MessageId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RepositoryType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SentUtcDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SystemUtcDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MessageId")
                        .IsUnique();

                    b.HasIndex("SentUtcDateTime");

                    b.ToTable("MessageOutbox");
                });

            modelBuilder.Entity("Bistrotic.Infrastructure.EfCore.Repositories.State", b =>
                {
                    b.Property<int>("IdHash")
                        .HasColumnType("int");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedByUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedUtcDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Json")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JsonType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedByUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedUtcDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.HasKey("IdHash", "Id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("Bistrotic.Infrastructure.EfCore.Repositories.StateStreamItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CausationId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorrelationId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Events")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdHash")
                        .HasColumnType("int");

                    b.Property<string>("MessageId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SystemUtcDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdHash");

                    b.ToTable("StateStreams");
                });
#pragma warning restore 612, 618
        }
    }
}
