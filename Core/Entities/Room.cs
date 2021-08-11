namespace Core.Entities
{
    public class Room : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        //  https://github.com/codebude/QRCoder
        public string QrCodeUrl { get; set; }

    }
}