﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TamaguchiBL.Models
{
    public partial class TamaguchiContext : DbContext
    {
        public TamaguchiContext()
        {
        }

        public TamaguchiContext(DbContextOptions<TamaguchiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<ExerciseType> ExerciseTypes { get; set; }
        public virtual DbSet<HealthStatus> HealthStatuses { get; set; }
        public virtual DbSet<LifeCycleStage> LifeCycleStages { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayerMethodsHistory> PlayerMethodsHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.Property(e => e.ExerciseName).IsUnicode(false);

                entity.HasOne(d => d.ExerciseType)
                    .WithMany(p => p.Exercises)
                    .HasForeignKey(d => d.ExerciseTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExercisesType");
            });

            modelBuilder.Entity<ExerciseType>(entity =>
            {
                entity.Property(e => e.TypeName).IsUnicode(false);
            });

            modelBuilder.Entity<HealthStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK__Health S__C8EE20438E2E2709");

                entity.Property(e => e.StatusName).IsUnicode(false);
            });

            modelBuilder.Entity<LifeCycleStage>(entity =>
            {
                entity.HasKey(e => e.StageId)
                    .HasName("PK__Life Cyc__03EB7AF846B4C0B6");

                entity.Property(e => e.StageName).IsUnicode(false);
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.Property(e => e.PetName).IsUnicode(false);

                entity.HasOne(d => d.HealthStatus)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.HealthStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PetHealthStatus");

                entity.HasOne(d => d.LifeCycleStage)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.LifeCycleStageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PetLifeStage");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PetPlayer");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Gender).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);

                entity.Property(e => e.UserPassword).IsUnicode(false);

                entity.HasOne(d => d.CurrentPet)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.CurrentPetId)
                    .HasConstraintName("FK_PlayerCurrentPet");
            });

            modelBuilder.Entity<PlayerMethodsHistory>(entity =>
            {
                entity.HasKey(e => e.MethodId)
                    .HasName("PK__Player M__FC681FB138477581");

                entity.HasOne(d => d.Exercise)
                    .WithMany(p => p.PlayerMethodsHistories)
                    .HasForeignKey(d => d.ExerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MethodExercise");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.PlayerMethodsHistories)
                    .HasForeignKey(d => d.PetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PetMethodsHistory");

                entity.HasOne(d => d.PetLifeCycleStage)
                    .WithMany(p => p.PlayerMethodsHistories)
                    .HasForeignKey(d => d.PetLifeCycleStageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MethodPetLifeCycleStage");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerMethodsHistories)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MethodPlayer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
