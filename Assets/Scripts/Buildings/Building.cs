using UnityEngine;

public enum BuildingType { VehicleBuilding, TechBuilding, TrapBuilding }

public class Building : MonoBehaviour
{
    public int buildingID;
    public BuildingType type;
    public int gridPositionX;
    public int gridPositionY;
    public bool isActive = false;
    public float effectCooldown = 0;

    void Update()
    {
        if (isActive)
        {
            // Binanın aktif olduğu süre boyunca yapılacak işlemler
        }
    }

    public void ActivateBuilding()
    {
        isActive = true;
        // Binanın aktif edilmesi için gerekli işlemler
    }

    public void DeactivateBuilding()
    {
        isActive = false;
        // Binanın pasif hale getirilmesi için gerekli işlemler
    }
}
