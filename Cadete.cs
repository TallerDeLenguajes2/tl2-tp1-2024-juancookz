class Cadete
{
    private int Id;
    private string Nombre;
    private string Direccion;
    private string Telefono;

    public Cadete(int id, string nombre, string direccion, string telefono)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
    }

    public void Mostrar()
    {
        System.Console.WriteLine(Id + " | " + Nombre);
    }
}