using Api_Produtos.Application;
using Microsoft.AspNetCore.Mvc;
using Api_Produtos.Repository;
using Api_Produtos.Models;

namespace Api_Produtos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController : ControllerBase
{
    private readonly ItemRepository _repository;

    public ItemController(ItemRepository itemRepository)
    {
        _repository = itemRepository;
    }

    [HttpPost]
    public IActionResult CriarItem(Item novoItem)
    {
        if (novoItem == null || string.IsNullOrEmpty(novoItem.IdProduto))
        {
            return BadRequest("Dados Invalidos");
        }
        _repository.AdicionarAoItem(novoItem);
        return Ok(novoItem);
    }
}