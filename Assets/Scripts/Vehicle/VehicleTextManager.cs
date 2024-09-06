using UnityEngine;
using TMPro;

public class VehicleTextManager : MonoBehaviour
{
    private Vehicle vehicle; // Bu referans Inspector'dan atanacak
    private TextMeshProUGUI speedAndDurabilityText; // Prefab içinde bulunan TextMeshPro referansı
    private Camera mainCamera; // Kamerayı takip etmek için

    private void Start()
    {
        vehicle = GetComponent<Vehicle>();
        // TextMeshProUGUI bileşenini prefab içinden bul
        speedAndDurabilityText = GetComponentInChildren<TextMeshProUGUI>();

        if (speedAndDurabilityText == null)
        {
            Debug.LogError("TextMeshPro component not found in children!");
            return;
        }

        // Ana kamerayı bul
        mainCamera = Camera.main;

        
    }

    private void LateUpdate()
    {
        if (speedAndDurabilityText != null)
        {
            // Metni kameraya doğru döndür
            Vector3 directionToCamera = speedAndDurabilityText.transform.position - mainCamera.transform.position;
            directionToCamera.y = 0; // Y eksenindeki rotasyonu sabitle
            speedAndDurabilityText.transform.rotation = Quaternion.LookRotation(directionToCamera);

            UpdateSpeedAndDurabilityText();
        }
    }


    private void UpdateSpeedAndDurabilityText()
    {
        if (vehicle != null)
        {
            speedAndDurabilityText.text = $"Spe: {vehicle.CurrentSpeed.ToString("F2")}, Dur: {vehicle.CurrentDurability}";
        } else {
        Debug.Log(" vehicle != null");
        }   
    }
}
