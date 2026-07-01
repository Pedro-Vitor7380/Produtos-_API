using Api_Produtos.Models;
using System.Linq;

namespace Api_Produtos.Repository;

public class ProdutoRepository
{
    private static List<Produto> _estoque = new List<Produto>()
    {
        new Produto("Celular POCO x6", 1870.99m),
        new Produto("Fone Bluetooth Xiaomi",120m),
        new Produto("patinete eletrico",3000m)
    };

    public List<Produto> MostrarEstoque()
    {
        return _estoque;
    }

    public Produto? BuscarPorId(string id)
    {
        return _estoque.FirstOrDefault(p => p.Id == id);
    }

    public void AdicionarAoEstoque(Produto novoProduto)
    {
        _estoque.Add(novoProduto);
    }

    public void atualizarProduto(Produto produtoAtualizado)
    {
        var ProdutoAntigo = BuscarPorId(produtoAtualizado.Id);
        if (ProdutoAntigo != null)
        {
            ProdutoAntigo.Nome = produtoAtualizado.Nome;
            ProdutoAntigo.Price = produtoAtualizado.Price;
        }
    }

    public void DeletarProduto(string id)
    {
        var produto = BuscarPorId(id);
            if (produto != null)
        {
            _estoque.Remove(produto);
        }
    }
}