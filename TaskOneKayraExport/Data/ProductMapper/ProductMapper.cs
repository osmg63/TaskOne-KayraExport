using AutoMapper;
using TaskOneKayraExport.Dto;
using TaskOneKayraExport.Entity;

namespace TaskOneKayraExport.Data.ProductMapper
{
    public class ProductMapper:Profile
    {
        public ProductMapper()
        {

            CreateMap<Product, ProductResponseDto>().ReverseMap();
            CreateMap<Product, ProductRequestDto>().ReverseMap();





        }






    }
}
