﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SettlementAPI.Entities;

namespace SettlementAPI.Migrations
{
    [DbContext(typeof(SettlementDbContext))]
    [Migration("20211121010721_intskdnfsknjf")]
    partial class intskdnfsknjf
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SettlementAPI.Entities.Settlement", b =>
                {
                    b.Property<int>("SettlementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedByUserUserId")
                        .HasColumnType("int");

                    b.HasKey("SettlementId");

                    b.HasIndex("CreatedByUserUserId");

                    b.ToTable("Settlements");
                });

            modelBuilder.Entity("SettlementAPI.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SettlementAPI.Entities.UserSettlement", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("SettlementId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "SettlementId");

                    b.HasIndex("SettlementId");

                    b.ToTable("UserSettlement");
                });

            modelBuilder.Entity("SettlementAPI.Entities.Settlement", b =>
                {
                    b.HasOne("SettlementAPI.Entities.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserUserId");

                    b.Navigation("CreatedByUser");
                });

            modelBuilder.Entity("SettlementAPI.Entities.UserSettlement", b =>
                {
                    b.HasOne("SettlementAPI.Entities.Settlement", "Settlement")
                        .WithMany("UserSettlementList")
                        .HasForeignKey("SettlementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SettlementAPI.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Settlement");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SettlementAPI.Entities.Settlement", b =>
                {
                    b.Navigation("UserSettlementList");
                });
#pragma warning restore 612, 618
        }
    }
}
