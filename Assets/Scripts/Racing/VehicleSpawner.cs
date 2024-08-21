using UnityEngine;
using PathCreation;

public class VehicleSpawner : MonoBehaviour
{
    public Vehicle vehiclePrefab;  // Araç prefab'ını buradan atayacağız
    public PathCreator[] pathCreators;  // Yolları buradan alacağız
    public float startDistance = 0f;  // Araçların başladığı uzaklık

    public int laneIndex = 0; // Varsayılan lane index (0: Left, 1: Right)

    private void Start()
    {
        if (vehiclePrefab == null)
        {
            Debug.LogError("Vehicle Prefab is not assigned!");
        }
        if (pathCreators == null || pathCreators.Length < 2)
        {
            Debug.LogError("PathCreators are not assigned correctly!");
        }
    }

        public void SpawnVehicle()
    {
        if (vehiclePrefab == null || pathCreators == null || pathCreators.Length < 2)
        {
            Debug.LogError("Missing vehicle prefab or path creators!");
            return;
        }

        // Doğru PathCreator'ı seç
        PathCreator selectedPathCreator = pathCreators[laneIndex]; // laneIndex değerine göre doğru path seçiliyor

        // Yeni bir araç oluştur ve doğru pozisyonda başlat
        Vehicle newVehicle = Instantiate(vehiclePrefab, selectedPathCreator.path.GetPointAtDistance(startDistance), selectedPathCreator.path.GetRotationAtDistance(startDistance));

        // Araç üzerinde gerekli ayarlamaları yap
        newVehicle.pathCreator = selectedPathCreator;
        newVehicle.distanceTravelled = startDistance;  // Araç başlangıç noktasında
    }


}
