using UnityEngine;
using PathCreation;

public class VehicleSpawner : MonoBehaviour
{
    public Vehicle vehiclePrefab;  // Araç prefab'ını buradan atayacağız
    public PathCreator pathCreator;  // Yolu buradan alacağız
    public Transform startTransform;  // Araçların başladığı konum
    public float startDistance = 0f;  // Araçların başladığı uzaklık

    private void Start()
    {
        // Eğer başlangıçta bir araç varsa, başlangıç mesafesini ayarla
        startDistance = 0f;
            if (vehiclePrefab == null)
        {
            Debug.LogError("Vehicle Prefab is not assigned!");
        }
    }

    
    public void SpawnVehicle()
    {
        // Yeni bir araç oluştur
        Vehicle newVehicle = Instantiate(vehiclePrefab, startTransform.position, Quaternion.identity);

        // Araç üzerinde gerekli ayarlamaları yap
        newVehicle.pathCreator = pathCreator;
        newVehicle.distanceTravelled = startDistance;  // Araç başlangıç noktasında
    }
        
}
