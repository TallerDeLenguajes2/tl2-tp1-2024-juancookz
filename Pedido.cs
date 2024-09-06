class Pedido
{
    public int Numero { get => numero; }
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
    public void Mostrar()
    {
        System.Console.WriteLine(Numero + " | " + estado);
    }
    public void AsignarCadete(Cadete cadeteAsignado)
    {
        estado = Estado.EnCurso;
        cadete = cadeteAsignado;
    }
}