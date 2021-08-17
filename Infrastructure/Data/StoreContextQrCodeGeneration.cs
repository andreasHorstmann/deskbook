using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;
using QRCoder;

namespace Infrastructure.Data
{
    public class StoreContextQrCodeGeneration
    {
        public static void QrCodeGenAsync(ILoggerFactory loggerFactory)
        {
            var logger_ = loggerFactory.CreateLogger<StoreContextQrCodeGeneration>();
            // logger_.LogInformation("StoreContextQrCodeGeneration.cs => QrCodeGenAsync => QRCodeGenerator qrGenerator = new QRCodeGenerator();");
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            var path = "../API/wwwroot/images/";
            var rpath = Path.Combine(path, "rooms");
            var dpath = Path.Combine(path, "desks");

            try
            {
                logger_.LogInformation(rpath);
                if(!Directory.Exists(rpath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(rpath);
                    var roomsData = File.ReadAllText("../Infrastructure/Data/SeedData/RoomList.json");
                    var rooms = JsonSerializer.Deserialize<List<Room>>(roomsData);
                    foreach(var item in rooms)
                    {
                        // logger_.LogInformation(item.Name);
                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(item.QrCodeUrl, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        Bitmap qrCodeImage = qrCode.GetGraphic(20);
                        SaveQrCodeImage(qrCodeImage, di, item.QrCodeUrl);
                    }
                }
                if(!Directory.Exists(dpath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(dpath);
                    var desksData = File.ReadAllText("../Infrastructure/Data/SeedData/DeskList.json");
                    var desks = JsonSerializer.Deserialize<List<Desk>>(desksData);
                    foreach(var item in desks)
                    {
                        // logger_.LogInformation(item.Name);
                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(item.QrCodeUrl, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        Bitmap qrCodeImage = qrCode.GetGraphic(20);
                        SaveQrCodeImage(qrCodeImage, di, item.QrCodeUrl);
                        // logger_.LogInformation(Directory.Exists(Path.Combine(di.FullName)).ToString());
                        // logger_.LogInformation(Path.GetDirectoryName(di.FullName));
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextQrCodeGeneration>();
                logger.LogError(ex.Message);
            }
        }

        private static void SaveQrCodeImage(Bitmap qrCodeImage, DirectoryInfo di, string fileName)
        {   //  https://docs.microsoft.com/de-de/dotnet/api/system.drawing.image.save?view=net-5.0
            ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
            // for the Quality parameter category.
            Encoder myEncoder = Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            // Save the bitmap as a JPEG file with quality level 25.
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 75L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            qrCodeImage.Save(Path.Combine(di.FullName, fileName), myImageCodecInfo, myEncoderParameters);
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {   //  https://docs.microsoft.com/de-de/dotnet/api/system.drawing.image.save?view=net-5.0
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for(j = 0; j < encoders.Length; ++j)
            {
                if(encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
    }
}