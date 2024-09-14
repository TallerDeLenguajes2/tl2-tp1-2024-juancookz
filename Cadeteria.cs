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

    public Pedido TomarPedido(int numero, string nombre, string direccion, string telefono, string referenciaDireccion, string observacion)
    {
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
        return ListadoPedidos
            .Where(p => p.Cadete.Id == idCadete && p.estado == Pedido.Estado.Finalizado)
            .Count();
    }

    public int JornalACobrar(int idCadete)
    {
        int monto = CantEntregasCadete(idCadete) * 500;
        return monto;
    }
}