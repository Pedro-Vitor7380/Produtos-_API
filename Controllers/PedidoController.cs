using Microsoft.AspNetCore.Mvc;
using Api_Produtos.Models;
using Api_Produtos.Repository;

namespace Api_Produtos.Controller;

[ApiController]
[Route("api/[controller]")] 
public class PedidoController : ControllerBase
{
    private readonly PedidoRepository _repository;
    private readonly ItemRepository _itemRepository;

    public PedidoController(PedidoRepository repository, ItemRepository itemRepository)
    {
        _repository = repository;
        _itemRepository = itemRepository;
    }


    [HttpGet]
    public ActionResult<List<Item>> MostrarItensDopedido()
    {
        return Ok(_repository.mostrarItensdoPedido());
    }
    [HttpPost]
    public IActionResult FecharPedido([FromBody] Pedido pedido)
    {
        Console.WriteLine($"---> CLIENTE RECEBIDO: '{pedido?.Cliente}'");
        Console.WriteLine($"---> QUANTIDADE DE ITENS: {pedido?.Itens?.Count ?? -1}");

        if (string.IsNullOrEmpty(pedido.Cliente))
        {
            return BadRequest(new { erro = "O nome do cliente é necessario para fechar o pedido " });
        }

        if (pedido.Itens == null|| pedido.Itens.Count == 0)
        {
            return BadRequest(new { erro = "Não é possível fechar um pedido sem itens no carrinho." });
        }

        try
        {
            _repository.FecharPedido(pedido);
            return Ok(pedido);
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = "Erro interno ao processar pedido: " + ex.Message });
        }
        
    }

    [HttpDelete("{idProduto}")]
    public IActionResult DeletarItem(string idProduto)
    {
        _repository.DeletarItensDoPedido(idProduto);

        return NoContent();
    }

}