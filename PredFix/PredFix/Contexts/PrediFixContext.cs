using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PredFix.Domains;

namespace PredFix.Contexts;

public partial class PrediFixContext : DbContext
{
    public PrediFixContext()
    {
    }

    public PrediFixContext(DbContextOptions<PrediFixContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Inspecao> Inspecao { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=N03S05-1253867;Database=PrediFix;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Inspecao>(entity =>
        {
            entity.HasKey(e => e.InspecaoID).HasName("PK__Inspecao__7FEBF39B93D72EAC");

            entity.Property(e => e.Cliente)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Equipamento)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Localizacao)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Inspecao)
                .HasForeignKey(d => d.UsuarioID)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioID).HasName("PK__Usuario__2B3DE798290A4E3D");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534FEE64F3F").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Senha).HasMaxLength(32);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
