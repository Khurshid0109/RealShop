using AutoMapper;
using RealShop.Domain.Entities;
using RealShop.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using RealShop.Services.Exceptions;
using RealShop.Services.DTOs.OrderItems;
using RealShop.Services.Interfaces.OrderItems;

namespace RealShop.Services.Services.OrderItems;
public class OrderItemsService:IOrderItemsService
{
    private readonly IMapper _mapper;
    private readonly IOrderItemsRepository _repository;

    public OrderItemsService(IMapper mapper, IOrderItemsRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<OrderItemsForResultDto> CreateAsync(OrderItemsForCreation dto)
    {
        var mapped = _mapper.Map<OrderItem>(dto);
        mapped.CreatedAt = DateTime.Now;

        var result = await _repository.InsertAsync(mapped);
        await _repository.SavechangesAsync();

        return _mapper.Map<OrderItemsForResultDto>(result);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var item = await _repository.SelectAll()
             .Where(i => i.Id == id)
             .FirstOrDefaultAsync();

        if (item is null)
            throw new CustomException(404, "OrderItem is not found!");

        await _repository.DeleteAsync(id);

        return true;
    }

    public async Task<OrderItemsForResultDto> ModifyAsync(long id, OrderItemsForUpdateDto dto)
    {
        var item = await _repository.SelectAll()
             .Where(i => i.Id == id)
             .FirstOrDefaultAsync();

        if (item is null)
            throw new CustomException(404, "OrderItem is not found!");

        var mapped = _mapper.Map(dto, item);
        mapped.UpdatedAt = DateTime.Now;

        return _mapper.Map<OrderItemsForResultDto>(mapped);
    }

    public async Task<IEnumerable<OrderItemsForResultDto>> RetriveAllAsync()
    {
        var items =  _repository.SelectAll();

        return _mapper.Map<IEnumerable<OrderItemsForResultDto>>(items);
    }

    public async Task<OrderItemsForResultDto> RetriveByIdAsync(long id)
    {
        var item = await _repository.SelectByIdAsync(id);

        if (item is null)
            throw new CustomException(404, "OrderItem is not found!");

        return _mapper.Map<OrderItemsForResultDto>(item);
    }
}
