using AutoMapper;
using CiklumTask.Models;
using System.Linq;

namespace CiklumTask.ViewModels
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Product, ProductVM>()
                    .ForMember(vm => vm.Images, m => m.MapFrom(l => l.Pics.Select(p => p.url_pic).ToList()))
                    .ForMember(vm => vm.FrontImage, m => m.MapFrom(l => l.Pics.First().url_pic))
                    .ForMember(vm => vm.Price, m => m.MapFrom(l => l.price));
            });
        }
    }
}