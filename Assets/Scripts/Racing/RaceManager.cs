using UnityEngine;
using System.Collections.Generic;

public class RaceManager : MonoBehaviour
{
    public float segmentLength = 10f;
    public int totalSegments = 30;
    public Dictionary<int, float> nitroBySegment;

    void Start()
    {
        nitroBySegment = new Dictionary<int, float>();
        InitializeRace();
    }

    void InitializeRace()
    {
        // Yarışı başlatmak için gerekli işlemler
    }

    public void UpdateRaceProgress()
    {
        // Yarışın ilerleyişini güncelle
    }
}
