using UnityEngine;
using PathCreation;

public class VehicleSpawner : MonoBehaviour
{
    public Vehicle vehiclePrefab;  // Araç prefab'ını buradan atayacağız
    public PathCreator[] pathCreators;  // Birden fazla PathCreator desteği için dizi
    public Transform startTransform;  // Araçların başladığı konum
    public float startDistance = 0f;  // Araçların başladığı uzaklık
    private UIManager uiManager;
    
    private void Start()
    {
        // Eğer başlangıçta bir araç varsa, başlangıç mesafesini ayarla
        startDistance = 0f;
        
        uiManager = FindObjectOfType<UIManager>();

        if (vehiclePrefab == null)
        {
            Debug.LogError("Vehicle Prefab is not assigned!");
        }

        if (pathCreators.Length == 0)
        {
            Debug.LogError("Path Creators are not assigned!");
        }
    }

    
     public void SpawnVehicle(int laneIndex)
    {
        if (laneIndex < 0 || laneIndex >= pathCreators.Length)
        {
            Debug.LogError("Invalid lane index!");
            return;
        }
        
        // Hangi şeritte araç spawn edileceğini UIManager'dan al
        int selectedLane = uiManager.laneIndex;
        PathCreator selectedPathCreator = pathCreators[selectedLane];
        

        Vehicle newVehicle = Instantiate(vehiclePrefab, startTransform.position, Quaternion.identity);

        // Doğru şeride göre PathCreator'ı ayarla
        newVehicle.pathCreator = pathCreators[laneIndex];
        newVehicle.distanceTravelled = startDistance;

        Debug.Log("Spawned vehicle on lane " + laneIndex);
    }
        
}
