using UnityEngine;
using PathCreation;
using System; // Action için gerekli
public class Vehicle : MonoBehaviour
{
    public int vehicleID;
    public VehicleType type;
    public VehicleData vehicleData;  // Scriptable Object referansı
    private VehicleData.SpecialAbility currentAbility;
    private float currentSpeed;
    public float CurrentSpeed
    { get { return currentSpeed; } }
    public float CurrentDurability
    { get { return currentDurability; } }
    private int currentDurability;
    public bool specialAbilityActive;
    public int currentLap;

    public PathCreator pathCreator;  // Yolu buradan alacağız
    public float distanceTravelled;  // Araç ne kadar yol aldı
    public int laneIndex;  // Araç hangi lane'de olduğunu belirler

    public Color vehicleColor;  // Araç rengi
    public MeshRenderer bodyRenderer; // Gövdenin MeshRenderer bileşeni
    private float targetSpeed; // Hedef hız
    private float speedChangeRate = 2f; // Hız değişim hızı (ne kadar hızlı ivmelenir/yavaşlar)
    public float crashSpeed;        // Çarpışma sonrası alınacak hız
    public float speedLerpDuration = 2f; // Hız değişim süresi

    private float speedLerpTime;     // Geçerli hız değiştirme zamanı
    private bool isLerpingSpeed;     // Hız değiştirme aktif mi?
    public float originalSpeed = 1f; // Araçların orijinal hızı

    void Start()
    {
        // Scriptable Object'ten verileri al
        
        currentSpeed = vehicleData.speed;
        currentDurability = vehicleData.durability;
        currentAbility = vehicleData.specialAbility;
        vehicleColor = vehicleData.color;
        bodyRenderer.material.color = vehicleData.color;

        pathCreator = FindObjectOfType<PathCreator>();
        targetSpeed = currentSpeed; // Başlangıçta hedef hız, mevcut hıza eşit

        originalSpeed = currentSpeed;

        
    }
    void Update()
    {
        if (pathCreator != null)
        {
            // Hız geçişini yumuşak yapmak için Lerp kullan
            currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, speedChangeRate * Time.deltaTime);

            // Mesafeyi her karede hız ile artır
            distanceTravelled += currentSpeed * Time.deltaTime;
            // Her karede mesafeyi artır
            distanceTravelled += currentSpeed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);

            
        }
        // Hız değerini smooth şekilde geri döndürme işlemi
        if (isLerpingSpeed)
        {
            speedLerpTime += Time.deltaTime;
            float t = speedLerpTime / speedLerpDuration;
            currentSpeed = Mathf.Lerp(currentSpeed, originalSpeed, t);

            if (t >= 1f)
            {
                isLerpingSpeed = false; // Hız değişim süreci tamamlandı
                currentSpeed = originalSpeed; // Hız orijinal değere döndü
            }
        }
    }
    // Olay tanımları
    public event Action OnSpeedOrDurabilityChanged;

    public void UpdateSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;
        OnSpeedOrDurabilityChanged?.Invoke(); // Olayı tetikleme
    }

    public void UpdateDurability(int newDurability)
    {
        currentDurability = newDurability;
        OnSpeedOrDurabilityChanged?.Invoke(); // Olayı tetikleme
    }
    void OnCollisionEnter(Collision collision)
    {
        // Eğer çarpışılan obje başka bir araçsa
        Vehicle otherVehicle = collision.gameObject.GetComponent<Vehicle>();

        if (otherVehicle != null)
        {
            if (currentSpeed > otherVehicle.currentSpeed)
            {
                // Hızlı olan aracın crashSpeed'ini hesapla
                float originalCrashSpeed = otherVehicle.currentSpeed;
                otherVehicle.crashSpeed = (currentSpeed / 4) + originalCrashSpeed;
                otherVehicle.SetSpeedSmooth(otherVehicle.crashSpeed);

                // Bu aracın hızını 1/4 oranında azalt
                float reducedSpeed = currentSpeed / 4;
                SetSpeedSmooth(reducedSpeed);
            }
            else if (currentSpeed < otherVehicle.currentSpeed)
            {
                // Yavaş olan aracın crashSpeed'ini hesapla
                float originalCrashSpeed = currentSpeed;
                crashSpeed = (otherVehicle.currentSpeed / 4) + originalCrashSpeed;
                SetSpeedSmooth(crashSpeed);

                // Diğer aracın hızını 1/4 oranında azalt
                float reducedSpeed = otherVehicle.currentSpeed / 4;
                otherVehicle.SetSpeedSmooth(reducedSpeed);
            }
            else
            {
                Debug.Log("Vehicles have the same speed; no changes made.");
            }
        }
    }
    // Smooth şekilde hız değiştirme işlemi
    public void SetSpeedSmooth(float targetSpeed)
    {
        currentSpeed = targetSpeed;
        speedLerpTime = 0f;
        isLerpingSpeed = true;
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
