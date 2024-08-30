using System;
using System.Collections.Generic;
using System.Linq;

public class IdGen
{
    private CSV csvHandler;
    private List<int> existingIds;

    public IdGen(string filePath)
    {
        csvHandler = new CSV();
        LoadExistingIds(filePath);
    }

    private void LoadExistingIds(string filePath)
    {
        existingIds = new List<int>();
        List<string> data = csvHandler.ReadCSV(filePath);

        foreach (string line in data)
        {
            if (int.TryParse(line, out int id))
            {
                existingIds.Add(id);
            }
        }
    }

    public int GenerateNewId(string filePath)
    {
        int newId = 1;

        if (existingIds.Count > 0)
        {
            newId = existingIds.Max() + 1;
        }

        existingIds.Add(newId);
        csvHandler.WriteCSV(filePath, 
        existingIds
        .Select(id => id.ToString()).ToList()
        );

        return newId;
    }
}
