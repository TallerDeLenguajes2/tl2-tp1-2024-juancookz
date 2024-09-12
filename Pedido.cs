class Pedido
{
    public int Numero { get => numero; }
    internal Cadete Cadete { get => cadete;}

    private int numero;
    private string observacion;
    private Cliente cliente;
    public Estado estado;
    private Cadete cadete;
    public enum Estado
    {
        Asignar,
        EnCurso,
        Finalizado
    };
    
    public Pedido(int numero, string observacion, Cliente cliente, Cadete cadete)
    {
        this.numero = numero;
        this.observacion = observacion;
        this.cliente = cliente;
        estado = Estado.Asignar;
        this.cadete = cadete;
    }
    public string Mostrar()
    {
        string nombreCadete;
        if (cadete == null)
        {
            nombreCadete = "N/A";
        }else
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