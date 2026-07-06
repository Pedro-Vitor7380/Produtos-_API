namespace Api_Produtos.Models; // Trocando o d extra pelo e



public class Pedido
{
    public string Id { get; set; }
    public string? Cliente { get; set; }
    public List<Item> Itens { get; set; } = new List<Item>();
    public decimal ValorTotal { get; set; }


    public Pedido()
    {

    }
    public Pedido(string? cliente)
    {
        Id = Guid.NewGuid().ToString();
        Cliente = cliente;
        
    }

        public void AdicionarItemAoPedido(Item novoItem)
    {
        Itens.Add(novoItem);
    }
    public void MostrarItensPedido()
    {
        Console.WriteLine($"Pedido do {Cliente}");

        foreach (var item in Itens)
        {
            Console.WriteLine($"-{item.IdProduto}");
        }

        Console.WriteLine($"valor total:{ValorTotal}");
    }
    public decimal CalcularTotal()
    {
        decimal total = 0;
        foreach (var item in Itens)
        {
            total += item.valorTotal;
        }
        ValorTotal = total;
        return ValorTotal;
    }

}