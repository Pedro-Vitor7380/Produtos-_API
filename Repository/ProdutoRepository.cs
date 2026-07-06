using Api_Produtos.data;
using Api_Produtos.Models;
using System.Linq;

namespace Api_Produtos.Repository;

public class ProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Produto> MostrarEstoque()
    {
        return _context.Produtos.ToList();
    }

    public Produto? BuscarPorId(string id)
    {
        return _context.Produtos.FirstOrDefault(p => p.Id == id);
    }

    public void AdicionarAoEstoque(Produto novoProduto)
    {
        _context.Produtos.Add(novoProduto);
        _context.SaveChanges();
    }

    public void atualizarProduto(Produto produtoAtualizado)
    {
        var ProdutoAntigo = BuscarPorId(produtoAtualizado.Id);
        if (ProdutoAntigo != null)
        {
            ProdutoAntigo.Nome = produtoAtualizado.Nome;
            ProdutoAntigo.Price = produtoAtualizado.Price;

            _context.Produtos.Update(ProdutoAntigo);
            _context.SaveChanges();
        }
    }

    public void DeletarProduto(string id)
    {
        var produto = BuscarPorId(id);
            if (produto != null)
        {
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }
    }
}