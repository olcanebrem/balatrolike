using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool isBuildingMode = false;
    public Vehicle selectedVehicle;
    public Building selectedBuilding;

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (isBuildingMode)
        {
            // Bina yerleştirme girdilerini işle
        }
        else
        {
            // Araç seçme ve kontrol girdilerini işle
        }
    }
}
