using Revija.Application.DTOs;
using Revija.Application.Interfaces;
using Revija.Domain.Interfaces;

namespace Revija.Application.Services;

public class MenuItemService : IMenuItemService
{
    private readonly IMenuItemRepository _repository;

    public MenuItemService(IMenuItemRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<MenuItemDto> GetAll()
    {
        return _repository.GetAll().Select(m => new MenuItemDto
        {
            Id = m.Id,
            Name = m.Name,
            Description = m.Description,
            Price = m.Price,
            Category = m.Category
        });
    }
}
