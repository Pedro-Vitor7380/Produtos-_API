using Api_Produtos.Models;
using Api_Produtos.Repository;

namespace Api_Produtos.Repository
{
    public class ItemRepository
    {
        private List<Item> ProdutosDoItem = new List<Item>();
       
        public void AdicionarAoItem(Item item)
        {
            ProdutosDoItem.Add(item);
        }
    }
}

