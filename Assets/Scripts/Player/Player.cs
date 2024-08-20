using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public static Player instance; // Singleton instance

    public int playerID;
    public List<Vehicle> vehicles;
    public List<Building> buildings;
    public float currentNitro = 0;
    public float nitroIncome = 0;
    public int currentLap; // Bu özelliği ekleyin

    void Awake()
    {
        // Singleton yapısını kurma
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateNitro(float amount)
    {
        currentNitro += amount;
    }
}
