using Api_Produtos.Models;
using Api_Produtos.Repository;

namespace Api_Produtos.Application;

public class ProdutoApplication
{
    private readonly ProdutoRepository _repository;

    public ProdutoApplication (ProdutoRepository repository)
    {
        _repository = repository;
    }

    public List<Produto> ListarEstoque()
    {
        return _repository.MostrarEstoque();
    }

    public Produto? BuscarPorId(string id)
    {
        return _repository.BuscarPorId(id);
    }

    public void CadastrarProduto(Produto produto)
    {
        _repository.AdicionarAoEstoque(produto);
    }
    public void AtualizarProduto(Produto produto)
    {
        _repository.atualizarProduto(produto);
    }

    public void DeletarProduto(string id)
    {
        _repository.DeletarProduto(id);
    }
}