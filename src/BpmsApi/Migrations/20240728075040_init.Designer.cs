﻿// <auto-generated />
using System;
using BpmsApi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BpmsApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240728075040_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BpmsApi.Entities.Node", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmailId")
                        .HasColumnType("int");

                    b.Property<int>("FormId")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("NodeType")
                        .HasColumnType("int");

                    b.Property<int>("PoolId")
                        .HasColumnType("int");

                    b.Property<string>("PositionInPool")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PositionX")
                        .HasColumnType("int");

                    b.Property<int>("PositionY")
                        .HasColumnType("int");

                    b.Property<int>("ScriptId")
                        .HasColumnType("int");

                    b.Property<string>("SignalKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartIntermediateNodeCondition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TaskOverdue")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPostIds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.Property<int>("WorkflowId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkflowId");

                    b.ToTable("Nodes");
                });

            modelBuilder.Entity("BpmsApi.Entities.Workflow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Workflows");
                });

            modelBuilder.Entity("BpmsApi.Entities.Node", b =>
                {
                    b.HasOne("BpmsApi.Entities.Workflow", null)
                        .WithMany("Nodes")
                        .HasForeignKey("WorkflowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("System.Collections.Generic.List<BpmsApi.Entities.FormElementVariableMapper>", "FormVariableMapper", b1 =>
                        {
                            b1.Property<int>("NodeId")
                                .HasColumnType("int");

                            b1.Property<int>("Capacity")
                                .HasColumnType("int");

                            b1.HasKey("NodeId");

                            b1.ToTable("Nodes");

                            b1.ToJson("FormVariableMapper");

                            b1.WithOwner()
                                .HasForeignKey("NodeId");
                        });

                    b.OwnsOne("System.Collections.Generic.List<BpmsApi.Entities.NextNode>", "NextNodes", b1 =>
                        {
                            b1.Property<int>("NodeId")
                                .HasColumnType("int");

                            b1.Property<int>("Capacity")
                                .HasColumnType("int");

                            b1.HasKey("NodeId");

                            b1.ToTable("Nodes");

                            b1.ToJson("NextNodes");

                            b1.WithOwner()
                                .HasForeignKey("NodeId");
                        });

                    b.Navigation("FormVariableMapper")
                        .IsRequired();

                    b.Navigation("NextNodes")
                        .IsRequired();
                });

            modelBuilder.Entity("BpmsApi.Entities.Workflow", b =>
                {
                    b.Navigation("Nodes");
                });
#pragma warning restore 612, 618
        }
    }
}
