namespace Core.Entities
{
    public class Desk : BaseEntity
    {
        public string Name { get; set; } 
        public string Description { get; set; }
        //  https://github.com/codebude/QRCoder
        public string QrCodeUrl { get; set; }
        public Room Room { get; set; }
        public int RoomId { get; set; }
    }
}