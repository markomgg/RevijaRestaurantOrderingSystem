using Revija.Domain.Entities;

namespace Revija.Domain.Interfaces;

public interface IMenuItemRepository
{
    IEnumerable<MenuItem> GetAll();
    MenuItem? GetById(int id);
    void Add(MenuItem item);
    void Update(MenuItem item);
    void Delete(int id);
}
