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
    public IActionResult post([FromBody] Pedido pedido)
    {
        try
        {
            _repository.FecharPedido(pedido);
            return Ok(pedido);
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
        
    }

    [HttpDelete("{idProduto}")]
    public IActionResult DeletarItem(string idProduto)
    {
        _repository.DeletarItensDoPedido(idProduto);

        return NoContent();
    }

}