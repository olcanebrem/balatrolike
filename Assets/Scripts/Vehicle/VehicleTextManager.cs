using UnityEngine;
using TMPro;

public class VehicleTextManager : MonoBehaviour
{
    public Vehicle vehicle; // Bu referans Inspector'dan atanacak
    private TextMeshProUGUI speedAndDurabilityText; // Prefab içinde bulunan TextMeshPro referansı
    private Camera mainCamera; // Kamerayı takip etmek için

    private void Start()
    {
        // TextMeshProUGUI bileşenini prefab içinden bul
        speedAndDurabilityText = GetComponentInChildren<TextMeshProUGUI>();

        if (speedAndDurabilityText == null)
        {
            Debug.LogError("TextMeshPro component not found in children!");
            return;
        }

        // Ana kamerayı bul
        mainCamera = Camera.main;

        // Başlangıç metin değerini ayarla
        UpdateSpeedAndDurabilityText();
    }

    private void LateUpdate()
    {
        if (speedAndDurabilityText != null)
        {
            // Metni kameraya doğru döndür
            Vector3 directionToCamera = speedAndDurabilityText.transform.position - mainCamera.transform.position;
            directionToCamera.y = 0; // Y eksenindeki rotasyonu sabitle
            speedAndDurabilityText.transform.rotation = Quaternion.LookRotation(directionToCamera);
        }
    }


    private void UpdateSpeedAndDurabilityText()
    {
        if (speedAndDurabilityText != null && vehicle != null)
        {
            speedAndDurabilityText.text = $"Speed: {vehicle.CurrentSpeed:F2}, Durability: {vehicle.CurrentDurability}";
        }
    }
}
