﻿// <auto-generated />
using System;
using BudgetPal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BudgetPal.Infrastructure.Migrations
{
    [DbContext(typeof(BudgetPalContext))]
    partial class BudgetPalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "currency_code", new[] { "dkk", "usd", "gbp", "eur" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("BalanceAmount")
                        .HasColumnType("double precision");

                    b.Property<int>("BalanceCurrencyCode")
                        .HasColumnType("integer");

                    b.Property<Guid?>("BudgetId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.HasIndex("UserId");

                    b.HasIndex("BalanceAmount", "BalanceCurrencyCode");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("Core.Models.Budget", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("Core.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("AssignedAmountAmount")
                        .HasColumnType("double precision");

                    b.Property<int>("AssignedAmountCurrencyCode")
                        .HasColumnType("integer");

                    b.Property<Guid?>("CategoryGroupId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TargetId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CategoryGroupId");

                    b.HasIndex("TargetId");

                    b.HasIndex("AssignedAmountAmount", "AssignedAmountCurrencyCode");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Core.Models.CategoryGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("AssignedAmountAmount")
                        .HasColumnType("double precision");

                    b.Property<int>("AssignedAmountCurrencyCode")
                        .HasColumnType("integer");

                    b.Property<Guid?>("BudgetId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.HasIndex("AssignedAmountAmount", "AssignedAmountCurrencyCode");

                    b.ToTable("CategoryGroup");
                });

            modelBuilder.Entity("Core.Models.Currency", b =>
                {
                    b.Property<int>("Code")
                        .HasColumnType("integer");

                    b.HasKey("Code");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("Core.Models.MoneyAmount", b =>
                {
                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<int>("CurrencyCode")
                        .HasColumnType("integer");

                    b.HasKey("Amount", "CurrencyCode");

                    b.ToTable("MoneyAmount");
                });

            modelBuilder.Entity("Core.Models.Target", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Target");
                });

            modelBuilder.Entity("Core.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Models.Account", b =>
                {
                    b.HasOne("Core.Models.Budget", null)
                        .WithMany("Accounts")
                        .HasForeignKey("BudgetId");

                    b.HasOne("Core.Models.User", null)
                        .WithMany("Accounts")
                        .HasForeignKey("UserId");

                    b.HasOne("Core.Models.MoneyAmount", "Balance")
                        .WithMany()
                        .HasForeignKey("BalanceAmount", "BalanceCurrencyCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Balance");
                });

            modelBuilder.Entity("Core.Models.Budget", b =>
                {
                    b.HasOne("Core.Models.User", null)
                        .WithMany("Budgets")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Core.Models.Category", b =>
                {
                    b.HasOne("Core.Models.CategoryGroup", null)
                        .WithMany("Categories")
                        .HasForeignKey("CategoryGroupId");

                    b.HasOne("Core.Models.Target", "Target")
                        .WithMany()
                        .HasForeignKey("TargetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.MoneyAmount", "AssignedAmount")
                        .WithMany()
                        .HasForeignKey("AssignedAmountAmount", "AssignedAmountCurrencyCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedAmount");

                    b.Navigation("Target");
                });

            modelBuilder.Entity("Core.Models.CategoryGroup", b =>
                {
                    b.HasOne("Core.Models.Budget", null)
                        .WithMany("CategoryGroups")
                        .HasForeignKey("BudgetId");

                    b.HasOne("Core.Models.MoneyAmount", "AssignedAmount")
                        .WithMany()
                        .HasForeignKey("AssignedAmountAmount", "AssignedAmountCurrencyCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedAmount");
                });

            modelBuilder.Entity("Core.Models.Budget", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("CategoryGroups");
                });

            modelBuilder.Entity("Core.Models.CategoryGroup", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Core.Models.User", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Budgets");
                });
#pragma warning restore 612, 618
        }
    }
}
