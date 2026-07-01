namespace Api_Produtos.Models; // Trocando o d extra pelo e


public class Item
{
    public string Id { get; set; }
    public string IdProduto { get; set; }
    public int Quantidade { get; set; }
    public decimal valorTotal { get; set; }


    public Item()
    {
    }


    public Item(Produto produto, int quantidade)
    {
        Id = Guid.NewGuid().ToString();
        IdProduto = produto.Nome;
        Quantidade = quantidade;
        valorTotal = produto.Price * quantidade;
    }
}