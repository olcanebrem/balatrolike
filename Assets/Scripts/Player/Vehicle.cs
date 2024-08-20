using UnityEngine;
using PathCreation;

public class Vehicle : MonoBehaviour
{
    public int vehicleID;
    public VehicleType type;
    public float speed;
    public int durability;
    public bool specialAbilityActive;
    public int currentLap;

    private PathCreator pathCreator; // PathCreator referansı
    private float distanceTravelled;

    void Start()
    {
        // PathCreator'ı referans al
        pathCreator = FindObjectOfType<PathCreator>();
    }

    void Update()
    {
        if (pathCreator != null)
        {
            // Araç path üzerinde hareket eder
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
        }
    }

    public void ActivateSpecialAbility()
    {
        // Özel yetenekler burada aktif edilir
    }
}
public enum VehicleType 
{ 
    Heavy, 
    Medium, 
    Fast 
}
