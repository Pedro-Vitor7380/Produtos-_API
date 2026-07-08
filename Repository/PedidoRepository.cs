using Api_Produtos.Models;
using Api_Produtos.data;
using System.Linq;

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

        public void FecharPedido(Pedido pedido)
        {
            // 1. Pega os itens que estão no carrinho (onde o PedidoId ainda está vazio ou nulo)
            var itensDoCarrinho = _context.Items.Where(i => i.PedidoId == null|| i.PedidoId=="").ToList(); 

            if (itensDoCarrinho.Count == 0)
            {
                throw new Exception("Não é possível fechar um pedido com o carrinho vazio.");
            }

            // 2. Calcula o valor total
            double totalDoPedido = 0;
            foreach (var item in itensDoCarrinho)
            {
                totalDoPedido += item.Quantidade * item.PrecoUnitario;

                // Vincular esse item ao Pedido atual!
                item.PedidoId = pedido.Id;
            }

            // 3. Preenche os dados do pedido
            pedido.ValorTotal = totalDoPedido;
            pedido.DataPedido = DateTime.Now;

            // 4. Adiciona o pedido ao banco (o Entity Framework já vai atualizar os itens automaticamente por causa do PedidoId)
            _context.Pedidos.Add(pedido);
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
