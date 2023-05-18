using AutoMapper;
using DTO;
using Entities;
using Repositories;

namespace Lesson1_login;
public class Mapper : Profile
{
   // EstyWebApiContext _estyWebApiContext;
    public Mapper()
	{
		CreateMap<Category, CategoryDto>().ReverseMap();
		CreateMap<Product, ProductDto>().ForMember(productDto => productDto.CategoryName,
														opt => opt.MapFrom(product => product.Category.Name)).
                                                        ForMember(productDto => productDto.CategoryId,
                                                        opt => opt.MapFrom(product => product.CategoryId));
		CreateMap<ProductDto, Product>();
		CreateMap<LoginDto, User>();
		CreateMap<User, UserDto>();
		CreateMap<Order, OrderDto>().ReverseMap();
		CreateMap<OrderItem, OrderItemDto>().
			//ForMember(orderItem => orderItem.Product,
   //                                                     opt => opt.MapFrom(orderItemDto => estyWebApiContext.Products.FindAsync(orderItemDto.ProductId))
   //                                                     ).
   ReverseMap();
		
                                                        


	}

}



