using Api_Produtos.Models;
using Api_Produtos.Repository;
using Api_Produtos.Application;


namespace Api_Produtos.Repository
{

    public class PedidoRepository
    {
        private readonly ItemRepository _itemRepository;
        private readonly ProdutoRepository _produtoRepository;
        private List<Item> _itens = new List<Item>();
        public PedidoRepository(ItemRepository itemRepository, ProdutoRepository produtoRepository)
        {
            _itemRepository = itemRepository;
            _produtoRepository = produtoRepository;
        }
        public void AdicionarAoPedido(Item item)
        {
            _itens.Add(item);
        }
        public List<Item> mostrarItensdoPedido()
        {
            return _itens;
        }
        public void DeletarItensDoPedido(string idProduto)
        {
            
            var produtoExcluir = _itens.FirstOrDefault(i => i.IdProduto == idProduto);
            if (produtoExcluir != null)
            {
                _itens.Remove(produtoExcluir);
            }
        }

    }
}
