using UnityEngine;
using System.Collections.Generic;

public class LaneManager : MonoBehaviour
{
    public int laneID;
    public List<Vehicle> vehiclesOnLane;
    public float laneLength = 100f;

    private void Update()
    {
        // Şeritteki araçların durumunu kontrol et
        foreach (var vehicle in vehiclesOnLane)
        {
            // Araçların hareketini ve konumunu kontrol et
        }
    }

    public void AddVehicleToLane(Vehicle vehicle)
    {
        vehiclesOnLane.Add(vehicle);
    }

    public void RemoveVehicleFromLane(Vehicle vehicle)
    {
        vehiclesOnLane.Remove(vehicle);
    }
}
