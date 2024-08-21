using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button leftButton;
    public Button rightButton;
    public VehicleSpawner vehicleSpawner;
    private int laneIndex = 0; // Varsayılan lane index (0: Left, 1: Right)

    void Start()
    {
        // Butonlara tıklama olaylarını bağlayın
        leftButton.onClick.AddListener(SetLaneIndexLeft);
        rightButton.onClick.AddListener(SetLaneIndexRight);
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
}
