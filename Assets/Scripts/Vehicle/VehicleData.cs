using UnityEngine;

[CreateAssetMenu(fileName = "NewVehicle", menuName = "Vehicle")]
public class VehicleData : ScriptableObject
{
    public string vehicleName;
    public float speed;
    public int durability;
    public Color color;
    public SpecialAbility specialAbility;

    public enum SpecialAbility
    {
        None,
        Magnet,
        Armored,
        Double,
        Magnetic,
        LaneChanger,
        Follower,
        Warrior,
        Cutter,
        Kamikaze,
        Jet
    }
}
