namespace AdvertisementsApi.classes
{
    public class Ad
    {
        public int? Id { get; set; }
        public int? SellerId { get; set; }
        public int? CategoryId { get; set; }

        public string Title { get; set; }
        public string? Description { get; set; }

        public DateTime? UploadDate { get; set; }
    }
}
