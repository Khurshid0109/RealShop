using AutoMapper;
using RealShop.Domain.Entities;
using RealShop.Data.IRepositories;
using RealShop.Services.Exceptions;
using RealShop.Services.DTOs.Orders;
using Microsoft.EntityFrameworkCore;
using RealShop.Services.Interfaces.Orders;
using RealShop.Data.Repositories;
using System.Linq;

namespace RealShop.Services.Services.Orders;
public class OrdersService : IOrdersService
{
    private readonly IMapper _mapper;
    private readonly IOrdersRepository _repository;
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;

    public OrdersService(IMapper mapper, IOrdersRepository repository, IUserRepository userRepository, IProductRepository productRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _userRepository = userRepository;
        _productRepository = productRepository;
    }

    public async Task<OrdersForResultDto> CreateAsync(OrdersForCreationDto dto)
    {
        var user = await _userRepository.SelectAll()
            .Where(u => u.Id == dto.UserId)
            .FirstOrDefaultAsync();

        if (user is null)
            throw new CustomException(404, "User is not found!");

        var mapped = _mapper.Map<Order>(dto);
        mapped.CreatedAt = DateTime.Now;

        var productIds = dto.orderItems.Select(item => item.Id).ToList();

        mapped.Products = await _productRepository.SelectAll()
            .Where(product => productIds.Contains((product.Id)))
            .ToListAsync();
       
        var order = await _repository.InsertAsync(mapped);

        await _repository.SavechangesAsync();

        return _mapper.Map<OrdersForResultDto>(order);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var order = await _repository.SelectAll()
            .Where(o => o.Id == id)
            .FirstOrDefaultAsync();

        if (order is null)
            throw new CustomException(404, "Order is not found!");

        await _repository.DeleteAsync(id);

        return true;
    }

    public async Task<OrdersForResultDto> ModifyAsync(long id, OrdersForUpdateDto dto)
    {
        var order = await _repository.SelectAll()
             .Where(o => o.Id == id)
             .FirstOrDefaultAsync();

        if (order is null)
            throw new CustomException(404, "Order is not found!");

        var mapped = _mapper.Map(dto, order);
        mapped.UpdatedAt = DateTime.Now;

        await _repository.UpdateAsync(mapped);

        return _mapper.Map<OrdersForResultDto>(mapped);
    }

    public async Task<IEnumerable<OrdersForResultDto>> RetriveAllAsync()
    {
        var orders = _repository.SelectAll();

        return _mapper.Map<IEnumerable<OrdersForResultDto>>(orders);
    }

    public async Task<OrdersForResultDto> RetriveByIdAsync(long id)
    {
        var order = await _repository.SelectByIdAsync(id);

        if (order is null)
            throw new CustomException(404, "Order is not found!");

        return _mapper.Map<OrdersForResultDto>(order);
    }
}
