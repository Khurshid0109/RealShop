using AutoMapper;
using RealShop.Domain.Entities;
using RealShop.Data.IRepositories;
using RealShop.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using RealShop.Services.DTOs.Products;
using RealShop.Services.Interfaces.Products;
using RealShop.Services.Helpers;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;
using RealShop.Domain.Enums;

namespace RealShop.Services.Services.Products;
public class ProductsService : IProductService
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public ProductsService(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProductForResultDto> CreateAsync(ProductForCreationDto dto)
    {
        var mapped = _mapper.Map<Product>(dto);
        mapped.CreatedAt = DateTime.Now;
        mapped.ImageUrl =  await UploadFile(dto.ImageUrl); 

        var result =await _repository.InsertAsync(mapped);
        await _repository.SavechangesAsync();

        return _mapper.Map<ProductForResultDto>(result);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var product = await _repository.SelectAll()
            .Where(p => p.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (product is null)
            throw new CustomException(404, "Product is not found!");

        await _repository.DeleteAsync(id);
        await _repository.SavechangesAsync();

        return true;
    }

    public async Task<IEnumerable<ProductForResultDto>> RetriveAllAsync()
    {
        var products =  _repository.SelectAll();

        return _mapper.Map<IEnumerable<ProductForResultDto>>(products);
    }

    public async Task<ProductForResultDto> RetriveByIdAsync(long id)
    {
        var product = await _repository.SelectByIdAsync(id);

        if (product is null)
            throw new CustomException(404, "Product is not found!");

        return _mapper.Map<ProductForResultDto>(product);

    }

    public async Task<ProductForResultDto> ModifyAsync(long id,ProductForUpdateDto dto)
    {
        var product = await _repository.SelectAll()
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();

        if (product is null)
            throw new CustomException(404, "Product is not found!");

        var mapped = _mapper.Map(dto, product);
        mapped.UpdatedAt = DateTime.Now;
        mapped.ImageUrl = await UploadFile(dto.ImageUrl);

        await _repository.UpdateAsync(mapped);
        await _repository.SavechangesAsync();

        return _mapper.Map<ProductForResultDto>(mapped);
    }

    public async Task<string> UploadFile(IFormFile file)
    {
        string uniqueFileName = "";

        if (file != null && file.Length > 0)
        {
            string uploadsFolder = Path.Combine(WebEnvironmentHost.rootPath, "images");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string imageFilePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(imageFilePath, FileMode.Create))
            {
               await file.CopyToAsync(fileStream);
            }
        }
        return  uniqueFileName;
    }

}