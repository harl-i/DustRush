using System;
using System.Collections.Generic;

public static class ServerTower 
{
    private static List<int>  _savedIdTower = new List<int>();

    public static void ActivateServer()
    {
        _savedIdTower.Add(1);
        _savedIdTower.Add(2);
    }

    public static List<int> LoadData()
    {
        return _savedIdTower;
    }
}