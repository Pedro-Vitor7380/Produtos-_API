namespace Api_Produtos.Models; // Trocando o d extra pelo e



using System;
using System.Collections.Generic;

public class Pedido
{
    public string Id { get; set; } // Representa o seu pedido_id
    public string? Cliente { get; set; } // Cliente (pode deixar um padrão ou receber no JSON
    public DateTime DataPedido { get; set; }
    public double ValorTotal { get; set; }
    public List<Item> Itens { get; set; } = new List<Item>();


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
        double total = 0;
        foreach (var item in Itens)
        {
            total += item.valorTotal;
        }
        ValorTotal = total;
        return (decimal)ValorTotal;
    }

}