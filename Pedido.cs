class Pedido
{
    private int Numero;
    private string Observacion;
    private Cliente Cliente;
    public Estado estado;
    public enum Estado
    {
        Asignar,
        EnCurso,
        Finalizado
    };
    private Cadete Cadete;

    public Pedido(int numero, string observacion, Cliente cliente,Cadete cadete)
    {
        Numero = numero;
        Observacion = observacion;
        Cliente = cliente;
        estado = Estado.Asignar;
        Cadete = cadete;
    }


    public void Mostrar()
    {
        System.Console.WriteLine(Numero + " | " + estado);
    }
    
}