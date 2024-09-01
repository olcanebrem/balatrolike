using UnityEngine;
using TMPro;

public class VehicleTextManager : MonoBehaviour
{
    
    public Vehicle vehicle; // Bu referans Inspector'dan atanacak
    public TextMeshProUGUI textPrefab; // Prefab olarak atanacak
    public Vector3 textOffset = new Vector3(0, 2, 0); // Metnin araç üzerindeki pozisyonu için bir offset

    private TextMeshProUGUI speedAndDurabilityText; // TextMeshProUGUI referansı
    public Canvas canvasPrefab; // Canvas prefab'ına referans

    private void Start()
    {
                
                {
            if (canvasPrefab == null)
            {
                Debug.LogError("Canvas prefab not assigned!");
                return;
            }

            // Yeni Canvas oluştur ve sahneye ekle
            Canvas newCanvas = Instantiate(canvasPrefab);
            newCanvas.transform.SetParent(null); // Parent'ı kaldırarak sahnede kalmasını sağla

            // Metin bileşenini oluştur ve yeni Canvas'ın altına ekle
            GameObject textObj = Instantiate(textPrefab.gameObject, newCanvas.transform);
            textObj.transform.localPosition = new Vector3(0, 100, 0);
        }

        

        if (textPrefab == null)
        {
            Debug.LogError("Text prefab not assigned!");
            return;
        }

    
        // Başlangıç metin değerini ayarlayın
        UpdateSpeedAndDurabilityText();
    }

    private void LateUpdate()
    {
        // Metnin rotasyonunu koru
        if (speedAndDurabilityText != null)
        {
            speedAndDurabilityText.transform.rotation = Quaternion.identity;
        }
    }

    private void UpdateSpeedAndDurabilityText()
    {
        // Canlı hız ve dayanıklılık değerlerini metne yansıt
        if (speedAndDurabilityText != null && vehicle != null)
        {
            speedAndDurabilityText.text = $"Speed: {vehicle.CurrentSpeed.ToString("F2")}, Durability: {vehicle.CurrentDurability}";
        }
    }
}


