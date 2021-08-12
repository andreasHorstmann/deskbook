using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class DeskUrlResolver : IValueResolver<Desk, DeskToReturnDto, string>
    {
        private readonly IConfiguration _config;
        public DeskUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Desk source, DeskToReturnDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.QrCodeUrl))
            {
                return _config["ApiUrl"] + source.QrCodeUrl;
            }
            return null;
        }
    }
}