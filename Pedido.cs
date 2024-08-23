class Pedido
{
    private int Numero;
    private string Observacion;
    private Cliente Cliente;
    private Estado estado;
    private enum Estado
    {
        Pendiente,
        EnCurso,
        Entregado
    };
    public Pedido(int numero, string observacion, Cliente cliente)
    {
        Numero = numero;
        Observacion = observacion;
        Cliente = cliente;
        estado = Estado.Pendiente;
    }
}