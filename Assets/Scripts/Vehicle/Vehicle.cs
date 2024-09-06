using UnityEngine;
using PathCreation;

public class Vehicle : MonoBehaviour
{
    public int vehicleID;
    public VehicleType type;
    public VehicleData vehicleData;  // Scriptable Object referansı
    public float distanceTravelled;  // Araç ne kadar yol aldı
    public Color vehicleColor;  // Araç rengi
    public MeshRenderer bodyRenderer; // Gövdenin MeshRenderer bileşeni

    public float CurrentSpeed { get; private set; }  // Araç hızı
    public float CurrentDurability { get; private set; }  // Araç dayanıklılığı

    public PathCreator pathCreator;  // Yolu buradan alacağız

    private Rigidbody rb;
    private Vector3 targetPosition;
    private Quaternion targetRotation;

    private void Start()
    {
        // Rigidbody bileşenini al
        rb = GetComponent<Rigidbody>();

        // Scriptable Object'ten verileri al
        if (vehicleData != null)
        {
            CurrentSpeed = vehicleData.speed;
            CurrentDurability = vehicleData.durability;
            vehicleColor = vehicleData.color;
            bodyRenderer.material.color = vehicleData.color;
        }
    }

    private void FixedUpdate()
    {
        if (pathCreator == null) return;
        // Zamanla artacak mesafeyi hesapla
        distanceTravelled += CurrentSpeed * Time.fixedDeltaTime;
        // Path üzerindeki hedef pozisyonu ve rotasyonu al
        targetPosition = pathCreator.path.GetPointAtDistance(distanceTravelled);
        targetRotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);

        // Rigidbody kullanarak pozisyonu ve rotasyonu ayarla
        rb.MovePosition(targetPosition);
        rb.MoveRotation(targetRotation);
    }

    // Hızı güncelleme metodu
    public void UpdateSpeed(float newSpeed)
    {
        CurrentSpeed = newSpeed;
    }

    // Dayanıklılığı güncelleme metodu
    public void UpdateDurability(float newDurability)
    {
        CurrentDurability = newDurability;
    }
}

public enum VehicleType
{
    Heavy,
    Medium,
    Fast
}
