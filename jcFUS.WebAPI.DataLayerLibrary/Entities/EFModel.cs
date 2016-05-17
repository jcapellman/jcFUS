using System;
using System.Data.Entity;

using jcFUS.WebAPI.DataLayerLibrary.EFObjects.Tables;

namespace jcFUS.WebAPI.DataLayerLibrary.Entities {    
    public class EFModel : DbContext {
        public DbSet<Locations> LocationSet { get; set; }

        public DbSet<Users> UserSet { get; set; }

        public DbSet<Room> RoomSet { get; set; }

        public DbSet<EmailSentLog> EmailSentLogs { get; set; }

        public DbSet<Users2Locations> Users2LocationSet { get; set; }

        public EFModel() : base("name=EFModel") { }

        public override int SaveChanges() {
            foreach (var item in this.ChangeTracker.Entries()) {
                if (item.State == EntityState.Deleted || item.State == EntityState.Modified ||
                    item.State == EntityState.Added) {
                    item.Member("Modified").CurrentValue = DateTimeOffset.Now;
                }

                switch (item.State) {
                    case EntityState.Deleted:
                        item.Member("Active").CurrentValue = false;
                        break;
                    case EntityState.Added:
                        item.Member("Created").CurrentValue = DateTimeOffset.Now;
                        item.Member("Active").CurrentValue = true;
                        break;
                }
            }

            return base.SaveChanges();
        }
    }
}