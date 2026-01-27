using Revija.Application.DTOs;

namespace Revija.Application.Interfaces;

public interface IMenuItemService
{
    IEnumerable<MenuItemDto> GetAll();
}
