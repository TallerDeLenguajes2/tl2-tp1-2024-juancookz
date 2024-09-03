using System.Data.Common;
using System.Linq;
class Cadeteria
{
    private string Nombre;
    private string Telefono;
    private List<Cadete> ListadoCadetes;
    private List<Pedido> ListadoPedidos;
    public Cadeteria(string nombre, string telefono)
    {
        Nombre = nombre;
        Telefono = telefono;
    }
    public void TomarPedido(int numero)
    {
        Console.WriteLine("Ingrese el nombre del cliente: ");
        string nombre = Console.ReadLine();

        Console.WriteLine("Ingrese la dirección del cliente: ");
        string direccion = Console.ReadLine();

        Console.WriteLine("Ingrese el número de teléfono del cliente: ");
        string telefono = Console.ReadLine();

        Console.WriteLine("Ingrese una referencia para la dirección del cliente (opcional): ");
        string referenciaDireccion = Console.ReadLine();

        Console.WriteLine("Ingrese la observación del pedido (opcional): ");
        string observacion = Console.ReadLine();

        Cadete cadete = null;
        Cliente cliente = new Cliente(nombre, direccion, telefono, referenciaDireccion);
        Pedido pedido = new Pedido(numero, observacion, cliente, cadete);
        ListadoPedidos.Add(pedido);
    }
    public void AsignarPedido()
    {
        System.Console.WriteLine("Elija un pedido a asignar:");
        System.Console.WriteLine("Nº|Estado");
        foreach (var pedido in ListadoPedidos.Where(p => p.estado == Pedido.Estado.Asignar))
        {
            pedido.Mostrar();
        }
    }

}