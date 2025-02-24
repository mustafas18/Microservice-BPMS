﻿// <auto-generated />
using System;
using BPMS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BPMS.Infrastructure.Migrations
{
    [DbContext(typeof(BpmsDbContext))]
    [Migration("20240829182152_init345")]
    partial class init345
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BPMS.Domain.Entities.Node", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Assignees")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Departments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmailId")
                        .HasColumnType("int");

                    b.Property<int?>("FormId")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("NodeType")
                        .HasColumnType("int");

                    b.Property<int?>("PoolId")
                        .HasColumnType("int");

                    b.Property<string>("PositionInPool")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PositionX")
                        .HasColumnType("int");

                    b.Property<int>("PositionY")
                        .HasColumnType("int");

                    b.Property<int?>("ScriptId")
                        .HasColumnType("int");

                    b.Property<string>("SignalKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartIntermediateNodeCondition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TaskOverdue")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.Property<int>("WorkflowId")
                        .HasColumnType("int");

                    b.Property<int?>("WorkflowTemplateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkflowTemplateId");

                    b.ToTable("Nodes");
                });

            modelBuilder.Entity("BPMS.Domain.Entities.Workflow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CompleteDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("WorkflowTemplateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkflowTemplateId");

                    b.ToTable("Workflows");
                });

            modelBuilder.Entity("BpmsDomain.Entities.WorkflowTemplate", b =>
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

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("WorkflowTemplates");
                });

            modelBuilder.Entity("BPMS.Domain.Entities.Node", b =>
                {
                    b.HasOne("BpmsDomain.Entities.WorkflowTemplate", null)
                        .WithMany("Nodes")
                        .HasForeignKey("WorkflowTemplateId");

                    b.OwnsOne("System.Collections.Generic.List<BPMS.Domain.Entities.NextNode>", "NextNodes", b1 =>
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

                    b.Navigation("NextNodes");
                });

            modelBuilder.Entity("BPMS.Domain.Entities.Workflow", b =>
                {
                    b.HasOne("BpmsDomain.Entities.WorkflowTemplate", "WorkflowTemplate")
                        .WithMany()
                        .HasForeignKey("WorkflowTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkflowTemplate");
                });

            modelBuilder.Entity("BpmsDomain.Entities.WorkflowTemplate", b =>
                {
                    b.Navigation("Nodes");
                });
#pragma warning restore 612, 618
        }
    }
}
