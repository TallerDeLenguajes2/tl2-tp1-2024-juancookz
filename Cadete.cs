class Cadete
{
    private string id;
    private string Nombre;
    private string Direccion;
    private string Telefono;
    private List<Pedido> ListadoPedidos;


    public void Mostrar()
    {
        System.Console.WriteLine(id + " | " + Nombre);
    }
}