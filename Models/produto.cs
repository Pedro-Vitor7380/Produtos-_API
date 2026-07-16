namespace Api_Produtos.Models;


public class Produto
{
    public string Id { get; set; }
    public string Nome { get; set; }
    public decimal Price { get; set; }
 
    public Produto()
    {

    }
    public Produto (string nome, decimal price)
    {
        Id = Guid.NewGuid().ToString();
        Nome = nome;
        Price = (decimal)price;
    }
}
