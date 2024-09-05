using System;
using System.Collections.Generic;
using System.IO;

public class CSV
{
    public List<string> ReadCSV(string filePath)
    {
        List<string> csvData = new List<string>();

        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("El archivo no existe.");
                File.Create(filePath);
                return csvData; // Return empty list
            }

            string[] lines = File.ReadAllLines(filePath);
            csvData.AddRange(lines);
        }
        catch (Exception)
        {
            Console.WriteLine("Ocurrio un error leyendo el archivo: ");
        }

        return csvData;
    }


    public void WriteCSV(string filePath, List<string> data)
    {
        try
        {
            File.WriteAllLines(filePath, data);
            Console.WriteLine("Archivo CSV guardado!");
        }
        catch (Exception)
        {
            Console.WriteLine("Ocurrio un error guardando el archivo: ");
        }
    }
}
