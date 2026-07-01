using Microsoft.AspNetCore.Mvc;
using Api_Produtos.Models;
using Api_Produtos.Repository;

namespace Api_Produtos.Controller;

[ApiController]
[Route("api/controller")]
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
    public IActionResult AdicionarItemAoPedido(Item novoItem)
    {
        if (novoItem == null || string.IsNullOrEmpty(novoItem.Id))
        {
            return BadRequest("Dados Invalidos");
        }
        _repository.AdicionarAoPedido(novoItem);
        return Ok();
    }

    [HttpDelete("{idProduto}")]
    public IActionResult DeletarItem(string idProduto)
    {
        _repository.DeletarItensDoPedido(idProduto);

        return NoContent();
    }

}