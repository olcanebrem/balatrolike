using UnityEngine;
using PathCreation;

public class Vehicle : MonoBehaviour
{
    public int vehicleID;
    public VehicleType type;
    public float speed = 1f;
    public int durability;
    public bool specialAbilityActive;
    public int currentLap;

    public PathCreator pathCreator;  // Yolu buradan alacağız
    public float distanceTravelled;  // Araç ne kadar yol aldı
    public int laneIndex;  // Araç hangi lane'de olduğunu belirler

    void Update()
    {
        if (pathCreator != null)
        {
            // Her karede mesafeyi artır
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);

            Debug.Log("Vehicle is moving along lane: " + laneIndex);
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
