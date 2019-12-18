using EMSVWPIDataContext.Entities;
using System.Data.Entity;
namespace EMSVWPIDataContext
{

    public class DatabaseContext : DbContext
    {

        public DatabaseContext()
           : base("name=dbConnection")
        {
        }
        //public DatabaseContext(DbContextOptions<DatabaseContext> options)
        //    : base(options)
        //{

        //}



        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySql("server=localhost;database=dektos;user=root;password=240149");
        //    base.OnConfiguring(optionsBuilder);
        //}


        //protected override void OnModelCreating()
        //{
        //    //base.OnModelCreating(modelBuilder);

        //    //modelBuilder.Entity<Publisher>(entity =>
        //    //{
        //    //    entity.HasKey(e => e.ID);
        //    //    entity.Property(e => e.Name).IsRequired();
        //    //});

        //    //modelBuilder.Entity<Book>(entity =>
        //    //{
        //    //    entity.HasKey(e => e.ISBN);
        //    //    entity.Property(e => e.Title).IsRequired();
        //    //    entity.HasOne(d => d.Publisher)
        //    //      .WithMany(p => p.Books);
        //    //});
        //}
        public DbSet<dl_data> dl_data { get; set; }

        public DbSet<dl_data_Historical> dl_data_Historical { get; set; }

        public DbSet<dl_data_live> dl_data_live { get; set; }



        public DbSet<dl_audit> dl_audits { get; set; }
        public DbSet<dl_confg> dl_confgs { set; get; }
        public DbSet<dl_controller> dl_controllers { set; get; }

        public DbSet<dl_controller_bus> dl_controller_buss { set; get; }
        public DbSet<dl_param> dl_params { set; get; }
        public DbSet<dl_role> dl_roles { set; get; }
        public DbSet<dl_site> dl_sites { set; get; }
        public DbSet<dl_log> dl_logs { set; get; }

        public DbSet<dl_usr> dl_usrs { set; get; }

        public DbSet<dl_usr_roles> dl_usr_roless { set; get; }

        public DbSet<dl_vendor> dl_vendors { set; get; }

        public DbSet<dl_error_cd> dl_errors { set; get; }
        public DbSet<Referencerecords> Referencerecords { set; get; }

        public DbSet<Referencerecordtypes> Referencerecordtypes { set; get; }

        public DbSet<dl_calib_cmd_setup> dl_calib_cmd_setups { set; get; }
        public DbSet<dl_calibrations> dl_calibrations { set; get; }
        public DbSet<dl_camera> dl_Camerass { set; get; }

    }
}
