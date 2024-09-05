IdGen idCadetes = new IdGen("idCadetes.csv");
IdGen idPedidos = new IdGen("idPedidos.csv");
List<Cadete> cadetes = LeerListaCadetesCsv("cadetes.csv");
List<Pedido> pedidos = new List<Pedido>();
Cadeteria cadeteria = new Cadeteria("Pepe","3813524023",cadetes, pedidos);


bool continuar = true;
Console.Clear();
while (continuar)
{
    Console.WriteLine("=== Menú de Gestión de Pedidos ===");
    Console.WriteLine("1. Dar de alta pedidos");
    Console.WriteLine("2. Asignar pedidos a cadetes");
    Console.WriteLine("3. Cambiar estado de un pedido");
    Console.WriteLine("4. Reasignar pedido a otro cadete");
    Console.WriteLine("5. Jornal a cobrar");
    Console.WriteLine("0. Salir");
    Console.Write("Seleccione una opción (0-5): ");
    int menu = elegirOpcion();
    switch (menu)
    {
        case 0:
            continuar = false;
            Console.WriteLine("Saliendo del programa...");
            break;
        case 1:
            int id = idPedidos.GenerateNewId();
            cadeteria.TomarPedido(id);
            break;
        case 2:
            cadeteria.AsignarPedido();
            break;
        case 3:
            break;
        case 4:
            break;
        case 5:
            break;
        default:
            Console.Clear();
            Console.WriteLine("Opción inválida, por favor seleccione un número del 0 al 4.");
            Thread.Sleep(750);
            break;
    }
}

static int elegirOpcion()
{
    int salida = -1;
    string entrada = "";
    while (!Int32.TryParse(entrada, out salida))
    {
        entrada = Console.ReadLine();
    }
    return salida;
}

List<Cadete> LeerListaCadetesCsv(string cadetesFilePath)
{
    CSV csvHandler = new CSV();
    List<string> ListaStringCadetes = csvHandler.ReadCSV(cadetesFilePath);
    List<Cadete> ListadoCadetesCsv = new List<Cadete>();
    foreach (var cadeteData in ListaStringCadetes)
    {
        string[] dataFields = cadeteData.Split(',');
        int id = int.Parse(dataFields[0]);
        string nombre = dataFields[1];
        string direccion = dataFields[2];
        string telefono = dataFields[3];

        Cadete cadete = new Cadete(id, nombre, direccion, telefono);
        ListadoCadetesCsv.Add(cadete);
    }
    return ListadoCadetesCsv;
}