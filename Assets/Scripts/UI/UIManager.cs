using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button leftButton;
    public Button rightButton;
    public VehicleSpawner vehicleSpawner;
    private int laneIndex = 0; // Varsayılan lane index (0: Left, 1: Right)
    public Image[] vehicleImages; // Araçları temsil eden resimler

    void Start()
    {
        // Butonlara tıklama olaylarını bağlayın
        leftButton.onClick.AddListener(SetLaneIndexLeft);
        rightButton.onClick.AddListener(SetLaneIndexRight);
        // Her bir resim için tıklanma olayını bağla
        for (int i = 0; i < vehicleImages.Length; i++)
        {
            int index = i; // İç içe lambda kullanımı için yerel bir kopya oluştur
            vehicleImages[i].GetComponent<Button>().onClick.AddListener(() => OnVehicleImageClicked(index));
        }
    }

    void SetLaneIndexLeft()
    {
        laneIndex = 0; // Left lane
        vehicleSpawner.laneIndex = laneIndex;
        Debug.Log("Lane Index set to: " + laneIndex);
    }

    void SetLaneIndexRight()
    {
        laneIndex = 1; // Right lane
        vehicleSpawner.laneIndex = laneIndex;
        Debug.Log("Lane Index set to: " + laneIndex);
    }
    private void OnVehicleImageClicked(int index)
    {
        // Tıklanan resmin indexine göre aracı spawn et
        vehicleSpawner.SpawnVehicle(index);
    }
}
