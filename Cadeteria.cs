using System.Data.Common;
using System.Linq;
class Cadeteria
{
    private string Nombre;
    private string Telefono;
    private List<Cadete> ListadoCadetes;
    private List<Pedido> ListadoPedidos;

    public Cadeteria(string nombre, string telefono, List<Cadete> listadoCadetes, List<Pedido> listadoPedidos)
    {
        Nombre = nombre;
        Telefono = telefono;
        ListadoCadetes = listadoCadetes;
        ListadoPedidos = listadoPedidos;
    }

    public Pedido TomarPedido(string nombre, string direccion, string telefono, string referenciaDireccion, string observacion)
    {
        int numero;

        if (ListadoPedidos.Count() == 0)
        {
            numero = 1;
        }
        else
        {
            numero = ListadoPedidos.Last().Numero + 1;
        }

        Cadete cadete = null;
        Cliente cliente = new Cliente(nombre, direccion, telefono, referenciaDireccion);
        return new Pedido(numero, observacion, cliente, cadete);
    }
    public int AsignarPedido(int idCadete, int idPedido)
    {
        Cadete cadete = ListadoCadetes.FirstOrDefault(c => c.Id == idCadete);
        Pedido pedido = ListadoPedidos.FirstOrDefault(p => p.Numero == idPedido);
        if (cadete != null && pedido != null)
        {
            pedido.AsignarCadete(cadete);
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public int FinalizarPedido(int idPedido)
    {
        Pedido pedido = ListadoPedidos.FirstOrDefault(p => p.Numero == idPedido);
        if (pedido != null)
        {
            pedido.Finalizar();
            return 1;
        }
        else
        {
            return 0;
        }
    }
    private int CantEntregasCadete(int idCadete)
    {
        try
        {
            return ListadoPedidos
            .Where(p => p.Cadete.Id == idCadete && p.estado == Pedido.Estado.Finalizado)
            .Count();
        }
        catch (System.Exception)
        {
            return 0;
        }
        
    }

    public int JornalACobrar(int idCadete)
    {
        int monto = CantEntregasCadete(idCadete) * 500;
        return monto;
    }
    public void InformeJornada()
    {
        int enviosTotal = 0, montoGanado = 0, cantCadetes = 0;

        float enviosPromedio = 0;

        enviosTotal = (ListadoPedidos
        .Where(p => p.estado == Pedido.Estado.Finalizado)
        .Count());

        montoGanado = enviosTotal * 500;

        cantCadetes = ListadoCadetes.Count();

        enviosPromedio = enviosTotal / cantCadetes;

        Console.Clear();
        System.Console.WriteLine("Informe de jornada");
        System.Console.WriteLine("== Detalle cadetes ==");
        System.Console.WriteLine("ID|      Nombre      | Envios | Monto ganado");
        foreach (var cadete in ListadoCadetes)
        {
            System.Console.WriteLine(cadete.Mostrar() + " | " + CantEntregasCadete(cadete.Id) + " | " + JornalACobrar(cadete.Id));

        }
        System.Console.WriteLine("Monto total ganado: $" + montoGanado);
        System.Console.WriteLine("Cantidad de envios:");
        System.Console.WriteLine("- Promedio por cadete: {0:0.0000}", enviosPromedio);
        System.Console.WriteLine("- Total: " + enviosTotal);
    }
}