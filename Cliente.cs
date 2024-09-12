class Cliente
{
    private string nombre;
    private string direccion;
    private string telefono;
    private string referenciaDireccion;

    public Cliente(string nombre, string direccion, string telefono, string referenciaDireccion)
    {
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.referenciaDireccion = referenciaDireccion;
    }

    public string Nombre { get => nombre;}
    public string Direccion { get => direccion;}
    public string Telefono { get => telefono;}
    public string ReferenciaDireccion { get => referenciaDireccion;}

    public string Mostrar()
    {
        return nombre + " | " + direccion;
    }
}