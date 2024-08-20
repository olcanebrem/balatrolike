using UnityEngine;
using System.Collections.Generic;
using PathCreation;  // PathCreator sınıfı için gerekli namespace

public class RaceManager : MonoBehaviour
{
    public PathCreator pathCreator; // Path referansı
    public List<Vehicle> vehicles;

    void Start()
    {
        InitializeRace();
    }

    void InitializeRace()
    {
        foreach (Vehicle vehicle in vehicles)
        {
            vehicle.transform.position = pathCreator.path.GetPointAtDistance(0);
            vehicle.transform.rotation = pathCreator.path.GetRotationAtDistance(0);
        }
    }

    public void UpdateRaceProgress()
    {
        // Yarışın ilerleyişini güncelle
    }
}
