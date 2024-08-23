using UnityEngine;
using PathCreation;

public class Vehicle : MonoBehaviour
{
    public int vehicleID;
    public VehicleType type;
    public VehicleData vehicleData;  // Scriptable Object referansı
    private VehicleData.SpecialAbility currentAbility;
    private float currentSpeed;
    private int currentDurability;
    public bool specialAbilityActive;
    public int currentLap;

    public PathCreator pathCreator;  // Yolu buradan alacağız
    public float distanceTravelled;  // Araç ne kadar yol aldı
    public int laneIndex;  // Araç hangi lane'de olduğunu belirler

    public Color vehicleColor;  // Araç rengi
    public MeshRenderer bodyRenderer; // Gövdenin MeshRenderer bileşeni

    void Start()
    {
        // Scriptable Object'ten verileri al
        currentSpeed = vehicleData.speed;
        currentDurability = vehicleData.durability;
        currentAbility = vehicleData.specialAbility;
        vehicleColor = vehicleData.color;
        bodyRenderer.material.color = vehicleData.color;
    }
    void Update()
    {
        if (pathCreator != null)
        {
            // Her karede mesafeyi artır
            distanceTravelled += currentSpeed * Time.deltaTime;
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
