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
    private float nitroAmount;

    private void Update()
    {
        MoveOnTrack();
    }

    private void MoveOnTrack()
    {
        // Pist üzerinde hareketi sağlamak için gerekli kod
        // Dairesel bir rota boyunca hareket et
        transform.position += transform.forward * speed * Time.deltaTime;
        // Pist merkezine göre dönüş yapılabilir
        transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime);
    }

    public void ActivateSpecialAbility()
    {
        // Özel yetenekler burada aktif edilir
    }

    public void UpdateNitro(float amount)
    {
        nitroAmount += amount;
        // Nitro ile ilgili işlemler
    }
}
