using System.Data.Common;
using System.Linq;
using System.Text;
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
        return new Pedido(numero, observacion, cliente, cadete, Pedido.Estado.Asignar);
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
            .Where(p => p.Cadete.Id == idCadete && p.EstadoPedido == Pedido.Estado.Finalizado)
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
    public string InformeJornada()
    {
        int enviosTotal = 0, montoGanado = 0, cantCadetes = 0;
        float enviosPromedio = 0;

        enviosTotal = (ListadoPedidos
            .Where(p => p.EstadoPedido == Pedido.Estado.Finalizado)
            .Count());

        montoGanado = enviosTotal * 500;
        cantCadetes = ListadoCadetes.Count();
        enviosPromedio = enviosTotal / cantCadetes;

        // Start building the report string
        StringBuilder informe = new StringBuilder();
        informe.AppendLine("Informe de jornada");
        informe.AppendLine("== Detalle cadetes ==");
        informe.AppendLine("ID|      Nombre      | Envios | Monto ganado");

        foreach (var cadete in ListadoCadetes)
        {
            informe.AppendLine($"{cadete.Mostrar()} | {CantEntregasCadete(cadete.Id)} | {JornalACobrar(cadete.Id)}");
        }

        informe.AppendLine($"Monto total ganado: ${montoGanado}");
        informe.AppendLine("Cantidad de envios:");
        informe.AppendLine($"- Promedio por cadete: {enviosPromedio:0.0000}");
        informe.AppendLine($"- Total: {enviosTotal}");

        // Return the full report as a string
        return informe.ToString();
    }
}