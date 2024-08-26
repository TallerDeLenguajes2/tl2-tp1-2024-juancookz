class Cadeteria
{
    private string Nombre;
    private string Telefono;
    private List<Cadete> ListadoCadetes;
    private List<Pedido> ListadoPedidosAsignar;
    private List<Pedido> ListadoPedidosEnCurso;
    public Cadeteria(string nombre, string telefono)
    {
        Nombre = nombre;
        Telefono = telefono;
    }
}    