using Api_Produtos.Models;
using Api_Produtos.data;
using Microsoft.AspNetCore.Http.HttpResults;

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
            var produtoDoEstoque = _context.Produtos.FirstOrDefault(x => x.Id == item.IdProduto);

            if (produtoDoEstoque != null)
            {
                item.PrecoUnitario = produtoDoEstoque.Price;

                item.valorTotal = item.Quantidade * item.PrecoUnitario;
            }
            else
            {
                throw new Exception("Produto nao encontrado no banco");
            }

            _context.Items.Add(item);
            _context.SaveChanges();
        }
    }
}

