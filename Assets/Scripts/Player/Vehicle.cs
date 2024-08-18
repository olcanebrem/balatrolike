using UnityEngine;

public enum VehicleType { Heavy, Medium, Fast }

public class Vehicle : MonoBehaviour
{
    public int vehicleID;
    public VehicleType type;
    public float speed;
    public int durability;
    public bool specialAbilityActive;
    public int currentLap;

    void Update()
    {
        // Araç hareket ve davranışları burada kontrol edilir
    }

    public void ActivateSpecialAbility()
    {
        // Özel yetenekler burada aktif edilir
    }
}
