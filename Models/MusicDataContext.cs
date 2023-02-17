using MySql.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;
using PlayList.Models;


public class MusicDataContext : DbContext
{


    public DbSet<BaiHat> BaiHat { get; set; }
    public DbSet<CaSi> CaSi { get; set; }
    public DbSet<NguoiNghe> NguoiNghe { get; set; }
    public DbSet<PlayList.Models.PlayList> PlayList { get; set; }
    public DbSet<PlayList_BaiHat> PlayList_BaiHat { get; set; }
    public DbSet<CaSi_BaiHat> CaSi_BaiHat { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=localhost;database=qlplaylist;user=root;password=");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<BaiHat>(entity =>
        {
            entity.HasKey(e => e.MaBaiHat);
            entity.Property(e => e.TenBaiHat).IsRequired();
            entity.Property(e => e.TheLoai).IsRequired();
        });
        modelBuilder.Entity<CaSi>(entity =>
        {
            entity.HasKey(e => e.MaCaSi);
            entity.Property(e => e.TenCaSi).IsRequired();
            entity.Property(e => e.NamSinh).IsRequired();
            entity.Property(e => e.GioiTinh).IsRequired();

        });
        modelBuilder.Entity<NguoiNghe>(entity =>
        {
            entity.HasKey(e => e.MaNN);
            entity.Property(e => e.TenNN);
            entity.Property(e => e.GioiTinh);
        });
        modelBuilder.Entity<PlayList.Models.PlayList>(entity =>
        {
            entity.HasKey(e => e.MaPlayList);
            entity.Property(e => e.TenPlayList);
            entity.Property(e => e.SoLuong);
            entity.Property(e => e.MaNN);
        });
        modelBuilder.Entity<PlayList_BaiHat>(entity =>
        {
           entity.HasKey(e => e.MaPlayList);
           entity.HasKey(e => e.MaPlayList);
        });
        modelBuilder.Entity<CaSi_BaiHat>(entity =>
        {
            entity.HasKey(e => e.MaCaSi);
            entity.HasKey(e => e.MaBaiHat);
        });
    }
    // public Table<CASI> CASIs;
    // public Table<NGUOINGHE> NGUOINGHEs;
    // public Table<PLAYLIST> PLAYLISTs;
    // public Table<CASI_BAIHAT> CASI_BAIHATs;
    // public Table<PLAYLIST_BAIHAT> PLAYLIST_BAIHATs;
}