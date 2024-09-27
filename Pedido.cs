public class Pedido
{
    public enum Estado
    {
        Asignar,
        EnCurso,
        Finalizado
    }

    private int numero;
    private string observacion;
    private Cliente cliente;
    private Cadete cadete;
    private Estado estado;  // Private field

    public int Numero { get => numero; }
    public string Observacion { get => observacion; }
    public Cliente Cliente { get => cliente; }
    public Cadete Cadete { get => cadete; }

    // Public getter, but private setter for Estado
    public Estado EstadoPedido { get => estado; }

    public Pedido(int numero, string observacion, Cliente cliente, Cadete cadete, Estado estado)
    {
        this.numero = numero;
        this.observacion = observacion;
        this.cliente = cliente;
        this.cadete = cadete;
        this.estado = estado;  // Set state via constructor
    }
    public string Mostrar()
    {
        string nombreCadete;
        if (cadete == null)
        {
            nombreCadete = "N/A";
        }
        else
        {
            nombreCadete = cadete.Nombre;
        }
        string retorno = Numero + " | " + estado + " | " + cliente.Nombre + " | " + cliente.Direccion + " | " + nombreCadete;
        return retorno;
    }
    public void AsignarCadete(Cadete cadeteAsignado)
    {
        estado = Estado.EnCurso;
        cadete = cadeteAsignado;
    }
    public void Finalizar()
    {
        estado = Estado.Finalizado;
    }
}