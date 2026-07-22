namespace Api_Produtos.Models;

public class Pedido
{
    public string Id { get; set; }
    public string? Cliente { get; set; }
    public DateTime DataPedido { get; set; } = DateTime.Now;
    public decimal ValorTotal { get; set; }
    public List<Item> Itens { get; set; } = new List<Item>();

    // Construtor padrão limpo (essencial para o JSON binding funcionar)
    public Pedido()
    {
    }

    // Se quiser manter o outro construtor, repasse a inicialização da lista
    public Pedido(string? cliente) : this()
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
        return (decimal)ValorTotal;
    }

}