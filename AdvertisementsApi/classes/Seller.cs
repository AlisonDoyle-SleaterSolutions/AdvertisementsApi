using Microsoft.EntityFrameworkCore;

namespace AdvertisementsApi.classes
{
    public class Seller
    {
        public int? Id { get; set; }

        public string Name { get; set; }
        
        public List<Ad> Ads { get; set; }
    }
}
