using Microsoft.EntityFrameworkCore;

namespace AdvertisementsApi.classes
{
    public class AdvertismentDb:DbContext
    {
        public AdvertismentDb(DbContextOptions<AdvertismentDb> options)
        : base(options) { }

        public DbSet<Ad> Ads => Set<Ad>();
        public DbSet<Seller> Sellers=> Set<Seller>();
        public DbSet<Category> Categories => Set<Category>();
    }
}
