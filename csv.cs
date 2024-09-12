public class CSV
{
    public List<string> ReadCSV(string filePath)
    {
        try
        {
            if (!FileExistsAndCreateIfNot(filePath))
            {
                return new List<string>(); // Devuelve una lista vacía si el archivo fue recién creado y se asume que está vacío.
            }

            string[] lines = File.ReadAllLines(filePath);
            return new List<string>(lines);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Se produjo un error al leer el archivo: {ex.Message}"); // Muestra mensaje de error detallado en caso de fallo.
            return new List<string>(); // Devuelve una lista vacía en caso de fallo.
        }
    }

public bool WriteCSV(string filePath, List<string> data)
{
    try
    {
        if (FileExistsAndCreateIfNot(filePath))
        {
            File.WriteAllLines(filePath, data);
            return true; // Devuelve verdadero si la operación fue exitosa.
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Se produjo un error al guardar el archivo: {ex.Message}"); // Muestra mensaje de error detallado en caso de fallo.
        return false; // Devuelve falso en caso de fallo.
    }

    return false; // Add this line to ensure that the method always returns something.
}


    private bool FileExistsAndCreateIfNot(string filePath)
    {
        try
        {
            if (!Directory.Exists(filePath))
            {
                
                Console.WriteLine("El archivo no existe. Creando uno nuevo..."); // Mensaje en caso de que el archivo no exista y se esté creando un nuevo archivo.
                Directory.CreateDirectory("csv");
                File.Create("csv/" + filePath).Close(); // Cierra la secuencia después de crear el archivo para liberar recursos.
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Se produjo un error al crear el directorio: {ex.Message}"); // Muestra mensaje de error detallado en caso de fallo.
            return false;
        }

        return true;
    }
}
