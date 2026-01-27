using Revija.Domain.Entities;
using Revija.Domain.Interfaces;
using Revija.Infrastructure.Data;

namespace Revija.Infrastructure.Repositories;

public class MenuItemRepository : IMenuItemRepository
{
    private readonly RevijaDbContext _context;

    public MenuItemRepository(RevijaDbContext context)
    {
        _context = context;
    }

    public IEnumerable<MenuItem> GetAll()
        => _context.MenuItems.ToList();

    public MenuItem? GetById(int id)
        => _context.MenuItems.Find(id);

    public void Add(MenuItem item)
    {
        _context.MenuItems.Add(item);
        _context.SaveChanges();
    }

    public void Update(MenuItem item)
    {
        _context.MenuItems.Update(item);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var item = _context.MenuItems.Find(id);
        if (item == null) return;

        _context.MenuItems.Remove(item);
        _context.SaveChanges();
    }
}
