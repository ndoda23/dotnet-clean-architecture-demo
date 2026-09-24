using ECommerce.Api.DTOs;
using ECommerce.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Services;

public class AnalyticsService
{
    private readonly AppDbContext _context;

    public AnalyticsService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TopProductDto?> GetTopSellingProductAsync()
    {
        var topProduct = await _context.OrderItems
            .GroupBy(item => item.ProductId)
            .Select(group => new TopProductDto
            {
                ProductId = group.Key,
                TotalQuantitySold = group.Sum(item => item.Quantity),
                TotalRevenue = group.Sum(item => item.Quantity * item.UnitPrice)
            })
            .OrderByDescending(dto => dto.TotalQuantitySold)
            .FirstOrDefaultAsync();

        return topProduct;
    }
}