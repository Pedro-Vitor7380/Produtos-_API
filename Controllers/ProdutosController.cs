using Microsoft.AspNetCore.Mvc;
using Api_Produtos.Models;
using Api_Produtos.Application;


namespace Api_Produtos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly ProdutoApplication _application;

    public ProdutosController(ProdutoApplication application)
    {
        _application = application;
    }

    [HttpGet]
    public ActionResult<List<Produto>> ObterEstoque()
    {
        return Ok(_application.ListarEstoque());
    }

    [HttpPost]
    public IActionResult CriarProduto(Produto novoProduto)
    {
        if (novoProduto == null || string.IsNullOrEmpty(novoProduto.Nome))
        {
            return BadRequest("Dados Invalidos");
        }
        _application.CadastrarProduto(novoProduto);
        return Created($"api/produtos/{novoProduto.Id}", novoProduto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarProduto(string id, Produto produtoDadosNovos)
    {
        if (id != produtoDadosNovos.Id)
        {
            return BadRequest("O ID nao é compativel com o da url ");
        }
        var produtoExistente = _application.BuscarPorId(id);
        if (produtoExistente == null)
        {
            return NotFound("o produto nao existe para ser editado");
        }
        _application.AtualizarProduto(produtoDadosNovos);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarProduto(string id)
    {
        var produtoExistente = _application.BuscarPorId(id);
        if (produtoExistente == null)
        {
            return NotFound("o produto nao existe para ser excluido");
        }
        _application.DeletarProduto(id);
        return Ok("Produto deletado com sucesso");
    }
}