namespace API.Dtos
{
    public class DeskToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public string QrCodeUrl { get; set; }
        public string Room { get; set; }

    }
}