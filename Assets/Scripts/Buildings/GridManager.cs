using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int gridWidth = 4;
    public int gridHeight = 9;
    public Building[,] grid;

    private void Start()
    {
        grid = new Building[gridWidth, gridHeight];
        // Grid'i başlat
    }

    public void PlaceBuilding(int x, int y, Building building)
    {
        grid[x, y] = building;
    }

    public Building GetBuilding(int x, int y)
    {
        return grid[x, y];
    }
}
