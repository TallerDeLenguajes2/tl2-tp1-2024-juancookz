using System.ComponentModel;
using System.Reflection;

IdGen idCadetes = new IdGen("csv/cadetes.csv");
IdGen idPedidos = new IdGen("csv/idPedidos.csv");
List<Cadete> cadetes = LeerListaCadetesCsv("csv/cadetes.csv");
List<Pedido> pedidos = new List<Pedido>();
Cadeteria cadeteria = new Cadeteria("Pepe", "3813524023", cadetes, pedidos);


bool continuar = true;
while (continuar)
{
    Console.Clear();
    Console.WriteLine("=== Menú de Gestión de Pedidos ===");
    Console.WriteLine("1. Dar de alta pedidos");
    Console.WriteLine("2. Asignar pedidos a cadetes");
    Console.WriteLine("3. Cambiar estado de un pedido");
    Console.WriteLine("4. Reasignar pedido a otro cadete");
    Console.WriteLine("5. Jornal a cobrar");
    Console.WriteLine("6. Estado Pedidos");
    Console.WriteLine("0. Salir");
    Console.Write("Seleccione una opción (0-6): ");
    int menu = elegirOpcion();
    switch (menu)
    {
        case 0:
            continuar = false;
            Console.WriteLine("Saliendo del programa...");
            break;
        case 1:
            MenuTomarPedido(idPedidos, pedidos, cadeteria);
            break;
        case 2:
            MenuAsignarPedido(cadetes, pedidos, cadeteria);
            break;
        case 3:
            MenuFinalizarPedido(pedidos, cadeteria);
            break;
        case 4:
            MenuReasignarPedido(cadetes, pedidos, cadeteria);
            break;
        case 5:
            MenuJornalACobrar(cadetes, cadeteria);
            break;
        case 6:
            MenuEstadoPedidos(pedidos);
            break;
        default:
            Console.Clear();
            Console.WriteLine("Opción inválida, por favor seleccione un número del 0 al 4.");
            Thread.Sleep(750);
            break;
    }
}

int elegirOpcion()
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

void MenuTomarPedido(IdGen idPedidos, List<Pedido> pedidos, Cadeteria cadeteria)
{
    int id = idPedidos.GenerateNewId();

    Console.WriteLine("Ingrese el nombre del cliente: ");
    string nombre = Console.ReadLine();

    Console.WriteLine("Ingrese la dirección del cliente: ");
    string direccion = Console.ReadLine();

    Console.WriteLine("Ingrese el número de teléfono del cliente: ");
    string telefono = Console.ReadLine();

    Console.WriteLine("Ingrese una referencia para la dirección del cliente (opcional): ");
    string referenciaDireccion = Console.ReadLine();

    Console.WriteLine("Ingrese la observación del pedido (opcional): ");
    string observacion = Console.ReadLine();

    pedidos.Add(cadeteria.TomarPedido(id, nombre, direccion, telefono, referenciaDireccion, observacion));
}

void MenuAsignarPedido(List<Cadete> cadetes, List<Pedido> pedidos, Cadeteria cadeteria)
{
    if (pedidos.Where(p => p.estado == Pedido.Estado.Asignar).Count() > 0)
    {
        int idPedido, idCadete, asignacion = 0;
        do
        {
            System.Console.WriteLine("Elija un pedido a asignar:");
            System.Console.WriteLine("Nº| Estado  | Cliente | Direccion | Cadete");
            foreach (var pedido in pedidos.Where(p => p.estado == Pedido.Estado.Asignar))
            {
                System.Console.WriteLine(pedido.Mostrar());
            }
            System.Console.Write("Ingrese Nº: ");
            idPedido = elegirOpcion();
            System.Console.WriteLine("=== Listado de cadetes ===");
            System.Console.WriteLine("Id | Nombre");
            foreach (var cadete in cadetes)
            {
                System.Console.WriteLine(cadete.Mostrar());
            }
            System.Console.Write("Ingrese Nº: ");
            idCadete = elegirOpcion();
            asignacion = cadeteria.AsignarPedido(idCadete, idPedido);
            if (asignacion == 0)
            {
                Console.Clear();
                System.Console.WriteLine("Numero de cadete o pedido invalido.");
                System.Console.WriteLine("Por favor ingrese un Nº valido.");
                Thread.Sleep(500);
            }
        } while (asignacion == 0);
    }
    else
    {
        System.Console.WriteLine("No hay pedidos a asignar");
        System.Console.WriteLine("Presione cualquier tecla para salir");
        Console.ReadKey();
    }
}

void MenuFinalizarPedido(List<Pedido> pedidos, Cadeteria cadeteria)
{
    if (pedidos.Where(p => p.estado == Pedido.Estado.EnCurso).Count() > 0)
    {
        int idPedido, asignacion = 0;
        do
        {
            System.Console.WriteLine("Elija un pedido en curso:");
            System.Console.WriteLine("Nº| Estado | Cliente | Direccion | Cadete");
            foreach (var pedido in pedidos.Where(p => p.estado == Pedido.Estado.EnCurso))
            {
                System.Console.WriteLine(pedido.Mostrar());
            }
            System.Console.Write("Ingrese Nº: ");
            idPedido = elegirOpcion();
            cadeteria.FinalizarPedido(idPedido);
            asignacion = cadeteria.FinalizarPedido(idPedido);
            if (asignacion == 0)
            {
                Console.Clear();
                System.Console.WriteLine("Numero de pedido invalido.");
                System.Console.WriteLine("Por favor ingrese un Nº valido.");
                Thread.Sleep(500);
            }
        } while (asignacion == 0);
        System.Console.WriteLine("Pedido marcado como finalizado.");
        Thread.Sleep(300);
        System.Console.WriteLine("Presione cualquier tecla para continuar.");
        Console.ReadKey();
    }
    else
    {
        System.Console.WriteLine("No hay pedidos en curso");
        System.Console.WriteLine("Presione cualquier tecla para salir");
        Console.ReadKey();
    }
}

void MenuReasignarPedido(List<Cadete> cadetes, List<Pedido> pedidos, Cadeteria cadeteria)
{
    if (pedidos.Where(p => p.estado == Pedido.Estado.EnCurso).Count() > 0)
    {
        int idPedido, idCadete, asignacion = 0;
        do
        {
            System.Console.WriteLine("Elija un pedido en curso:");
            System.Console.WriteLine("Nº| Estado  | Cliente | Direccion | Cadete");
            foreach (var pedido in pedidos.Where(p => p.estado == Pedido.Estado.EnCurso))
            {
                System.Console.WriteLine(pedido.Mostrar());
            }
            System.Console.Write("Ingrese Nº pedido a reasignar: ");
            idPedido = elegirOpcion();
            System.Console.WriteLine("=== Listado de cadetes ===");
            System.Console.WriteLine("Id | Nombre");
            foreach (var cadete in cadetes)
            {
                System.Console.WriteLine(cadete.Mostrar());
            }
            System.Console.Write("Ingrese Nº: ");
            idCadete = elegirOpcion();
            asignacion = cadeteria.AsignarPedido(idCadete, idPedido);
            if (asignacion == 0)
            {
                Console.Clear();
                System.Console.WriteLine("Numero de cadete o pedido invalido.");
                System.Console.WriteLine("Por favor ingrese un Nº valido.");
                Thread.Sleep(500);
            }
        } while (asignacion == 0);
    }
    else
    {
        System.Console.WriteLine("No hay pedidos en curso para reasignar");
        System.Console.WriteLine("Presione cualquier tecla para salir");
        Console.ReadKey();
    }
}

static void MenuEstadoPedidos(List<Pedido> pedidos)
{
    if (pedidos.Count == 0)
    {
        System.Console.WriteLine("No hay pedidos");
        System.Console.WriteLine("Presione cualquier tecla para salir");
        Console.ReadKey();
    }
    else
    {
        System.Console.WriteLine("== Estado Pedidos ==");
        System.Console.WriteLine("Nº| Estado  | Cliente | Direccion | Cadete");
        foreach (var pedido in pedidos)
        {
            System.Console.WriteLine(pedido.Mostrar());
        }
        System.Console.WriteLine("Presione cualquier tecla para salir");
        Console.ReadKey();
    }
}

void MenuJornalACobrar(List<Cadete> cadetes, Cadeteria cadeteria)
{
    int idCadete;
    System.Console.WriteLine("=== Listado de cadetes ===");
    System.Console.WriteLine("Id | Nombre");
    foreach (var cadete in cadetes)
    {
        System.Console.WriteLine(cadete.Mostrar());
    }
    System.Console.Write("Ingrese Nº: ");
    idCadete = elegirOpcion();
    Console.Clear();
    System.Console.WriteLine("Jornal a cobrar: $ " + cadeteria.JornalACobrar(idCadete));
    Thread.Sleep(500);
    System.Console.WriteLine("Presione cualquier tecla para salir");
    Console.ReadKey();
}