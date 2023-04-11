﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JustMeetWebService.Models;

public partial class JustmeetContext : DbContext
{
    public JustmeetContext()
    {
    }

    public JustmeetContext(DbContextOptions<JustmeetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Gametype> Gametypes { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Trusted_Connection=True; Encrypt=false; Database=Justmeet");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.IdAnswer);

            entity.ToTable("Answer");

            entity.Property(e => e.IdAnswer).HasColumnName("idAnswer");
            entity.Property(e => e.Answer1).HasColumnName("answer");
            entity.Property(e => e.Selected).HasColumnName("selected");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.IdGame);

            entity.ToTable("Game");

            entity.Property(e => e.IdGame).HasColumnName("idGame");
            entity.Property(e => e.Match)
                .HasDefaultValueSql("((0))")
                .HasColumnName("match");
            entity.Property(e => e.RegistrationDate)
                .HasColumnType("date")
                .HasColumnName("registrationDate");

            entity.HasMany(d => d.IdQuestions).WithMany(p => p.IdGames)
                .UsingEntity<Dictionary<string, object>>(
                    "QuestionGame",
                    r => r.HasOne<Question>().WithMany()
                        .HasForeignKey("IdQuestion")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_QuestionGame_Question"),
                    l => l.HasOne<Game>().WithMany()
                        .HasForeignKey("IdGame")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_QuestionGame_Game"),
                    j =>
                    {
                        j.HasKey("IdGame", "IdQuestion");
                        j.ToTable("QuestionGame");
                        j.IndexerProperty<int>("IdGame").HasColumnName("idGame");
                        j.IndexerProperty<int>("IdQuestion").HasColumnName("idQuestion");
                    });

            entity.HasMany(d => d.IdUsers).WithMany(p => p.IdGames)
                .UsingEntity<Dictionary<string, object>>(
                    "UserGame",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserGame_User"),
                    l => l.HasOne<Game>().WithMany()
                        .HasForeignKey("IdGame")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserGame_Game"),
                    j =>
                    {
                        j.HasKey("IdGame", "IdUser");
                        j.ToTable("UserGame");
                        j.IndexerProperty<int>("IdGame").HasColumnName("idGame");
                        j.IndexerProperty<int>("IdUser").HasColumnName("idUser");
                    });
        });

        modelBuilder.Entity<Gametype>(entity =>
        {
            entity.HasKey(e => e.IdGametype);

            entity.ToTable("Gametype");

            entity.Property(e => e.IdGametype).HasColumnName("idGametype");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.IdLocation);

            entity.ToTable("Location");

            entity.Property(e => e.IdLocation).HasColumnName("idLocation");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Latitud).HasColumnName("latitud");
            entity.Property(e => e.Longitud).HasColumnName("longitud");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Locations)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Location_User");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.IdQuestion);

            entity.ToTable("Question");

            entity.Property(e => e.IdQuestion).HasColumnName("idQuestion");
            entity.Property(e => e.IdGametype).HasColumnName("idGametype");
            entity.Property(e => e.Question1).HasColumnName("question");

            entity.HasOne(d => d.IdGametypeNavigation).WithMany(p => p.Questions)
                .HasForeignKey(d => d.IdGametype)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Question_Gametype");

            entity.HasMany(d => d.IdAnswers).WithMany(p => p.IdQuestions)
                .UsingEntity<Dictionary<string, object>>(
                    "QuestionAnswer",
                    r => r.HasOne<Answer>().WithMany()
                        .HasForeignKey("IdAnswer")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_QuestionAnswer_Answer"),
                    l => l.HasOne<Question>().WithMany()
                        .HasForeignKey("IdQuestion")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_QuestionAnswer_Question"),
                    j =>
                    {
                        j.HasKey("IdQuestion", "IdAnswer");
                        j.ToTable("QuestionAnswer");
                        j.IndexerProperty<int>("IdQuestion").HasColumnName("idQuestion");
                        j.IndexerProperty<int>("IdAnswer").HasColumnName("idAnswer");
                    });
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.IdSetting);

            entity.ToTable("Setting");

            entity.Property(e => e.IdSetting).HasColumnName("idSetting");
            entity.Property(e => e.Genre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("genre");
            entity.Property(e => e.IdGametype).HasColumnName("idGametype");
            entity.Property(e => e.MaxAge)
                .HasDefaultValueSql("((99))")
                .HasColumnName("maxAge");
            entity.Property(e => e.MaxDistance)
                .HasDefaultValueSql("((0.0))")
                .HasColumnName("maxDistance");
            entity.Property(e => e.MinAge)
                .HasDefaultValueSql("((18))")
                .HasColumnName("minAge");

            entity.HasOne(d => d.IdGametypeNavigation).WithMany(p => p.Settings)
                .HasForeignKey(d => d.IdGametype)
                .HasConstraintName("FK_Setting_Gametype");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("User");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Birthday)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("birthday");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Genre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("genre");
            entity.Property(e => e.IdSetting).HasColumnName("idSetting");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.Premium).HasColumnName("premium");

            entity.HasOne(d => d.IdSettingNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdSetting)
                .HasConstraintName("FK_User_Setting");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}