using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public int totalLaps = 20;
    public float nitroRate = 10f;
    public List<Player> players;

    void Start()
    {
        // Oyuncuları başlat
        players = new List<Player>();
        // Oyunu başlat
        StartGame();
    }

    void StartGame()
    {
        // Yarışı başlatmak için gerekli işlemler
    }

    public void EndGame()
    {
        // Oyunu sonlandırmak için gerekli işlemler
    }
}
