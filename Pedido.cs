class Pedido
{
    private int Numero;
    private string Observacion;
    private Cliente Cliente;
    private Estado estado;
    private enum Estado
    {
        Asignar,
        EnCurso,
        Finalizado
    };
    private Cadete Cadete;
    public Pedido(int numero, string observacion, Cliente cliente)
    {
        Numero = numero;
        Observacion = observacion;
        Cliente = cliente;
        estado = Estado.Asignar;
    }


    public void Mostrar()
    {
        System.Console.WriteLine(Numero + " | " + estado);
    }
    
}