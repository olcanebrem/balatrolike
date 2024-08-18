using UnityEngine;
using System.Collections.Generic;

public class Player
{
    public int playerID;
    public List<Vehicle> vehicles;
    public List<Building> buildings;
    public float currentNitro = 0;
    public float nitroIncome = 0;

    public void UpdateNitro(float amount)
    {
        currentNitro += amount;
    }
}
