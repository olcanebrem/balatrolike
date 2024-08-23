using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool isBuildingMode = false;
    public Vehicle selectedVehicle;
    public Building selectedBuilding;

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (isBuildingMode)
        {
            // Bina yerleştirme girdilerini işle
            if (Input.GetMouseButtonDown(0)) // Sol tıklama
            {
                // Bina yerleştirme işlemleri
            }
        }
        else
        {
            // Araç seçme ve kontrol girdilerini işle
            if (Input.GetMouseButtonDown(0)) // Sol tıklama
            {
                // Araç seçme işlemleri
            }
        }
    }
}
