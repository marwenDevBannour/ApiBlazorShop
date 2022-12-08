namespace BlazorAppShop.ViewModel
{
    public class VmProduct
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool IsPublic { get; set; }
        public bool IsDelete { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        public int Views { get; set; }
        public int CategoryId { get; set; }
    }
}
