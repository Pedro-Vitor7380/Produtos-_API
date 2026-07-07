using Api_Produtos.Models;
using Api_Produtos.Repository;
using Api_Produtos.Application;
using Api_Produtos.data;


namespace Api_Produtos.Repository
{

    public class PedidoRepository
    {
        private readonly ItemRepository _itemRepository;
        private readonly ProdutoRepository _produtoRepository;


        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AdicionarAoPedido(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }
        public List<Item> mostrarItensdoPedido()
        {
            return _context.Items.ToList();

        }
        public void DeletarItensDoPedido(string idProduto)
        {
            
            var produtoExcluir = _context.Items.FirstOrDefault(i => i.IdProduto == idProduto);
            if (produtoExcluir != null)
            {
                _context.Items.Remove(produtoExcluir);
                _context.SaveChanges();
            }
        }

    }
}
