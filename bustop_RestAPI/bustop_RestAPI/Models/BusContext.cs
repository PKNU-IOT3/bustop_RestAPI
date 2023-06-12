using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace bustop_RestAPI.Models;

public partial class BusContext : DbContext
{
    public BusContext()
    {
    }

    public BusContext(DbContextOptions<BusContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BusTable> BusTables { get; set; }

    public virtual DbSet<ManagerTable> ManagerTables { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseMySQL("server=localhost;port=3306;database=bus;user=root;password=12345;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BusTable>(entity =>
        {
            entity.HasKey(e => e.BusIdx).HasName("PRIMARY");

            entity.ToTable("bus_table", tb => tb.HasComment("버스 정보를 담는 테이블"));

            entity.Property(e => e.BusIdx).HasColumnName("bus_idx");
            entity.Property(e => e.BusCnt).HasColumnName("bus_cnt");
            entity.Property(e => e.BusGap).HasColumnName("bus_gap");
            entity.Property(e => e.BusNowIn).HasColumnName("bus_NowIn");
            entity.Property(e => e.BusNum)
                .HasMaxLength(50)
                .HasColumnName("bus_num");
        });

        modelBuilder.Entity<ManagerTable>(entity =>
        {
            entity.HasKey(e => e.ManagerId).HasName("PRIMARY");

            entity.ToTable("manager_table");

            entity.Property(e => e.ManagerId)
                .HasMaxLength(45)
                .HasColumnName("manager_id");
            entity.Property(e => e.ManagerPwd)
                .HasMaxLength(45)
                .HasColumnName("manager_pwd");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
