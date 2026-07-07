using Api_Produtos.Models;
using Api_Produtos.data;

namespace Api_Produtos.Repository
{
    public class ItemRepository
    {
        
       private readonly AppDbContext _context;
        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AdicionarAoItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }
    }
}

