using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if(!context.Rooms.Any())
                {
                    var roomsData = File.ReadAllText("../Infrastructure/Data/SeedData/RoomList.json");
                    var rooms = JsonSerializer.Deserialize<List<Room>>(roomsData);
                    foreach(var item in rooms)
                    {
                        context.Rooms.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if(!context.Desks.Any())
                {
                    var desksData = File.ReadAllText("../Infrastructure/Data/SeedData/DeskList.json");
                    var desks = JsonSerializer.Deserialize<List<Desk>>(desksData);
                    foreach(var item in desks)
                    {
                        context.Desks.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}