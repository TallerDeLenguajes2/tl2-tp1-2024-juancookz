class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    public int Id { get => id; }
    public Cadete(int id, string nombre, string direccion, string telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
    }
    public void Mostrar()
    {
        System.Console.WriteLine(id + " | " + nombre);
    }
}