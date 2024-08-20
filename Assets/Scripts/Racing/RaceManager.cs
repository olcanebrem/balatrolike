using UnityEngine;
using System.Collections.Generic;

public class RaceManager : MonoBehaviour
{
    public float segmentLength = 10f; // Her bir segmentin uzunluğu
    public int totalSegments = 30;    // Toplam segment sayısı
    public Dictionary<int, float> nitroBySegment; // Segment başına Nitro miktarı
    public Transform trackCenter;     // Pistin merkezini temsil eden Transform
    public float trackRadius = 50f;   // Pistin yarıçapı

    private void Start()
    {
        nitroBySegment = new Dictionary<int, float>();
        InitializeRace();
    }

    private void InitializeRace()
    {
        // Yarışın başlatılmasıyla ilgili işlemler
    }

    public void UpdateRaceProgress(Vehicle vehicle)
    {
        // Araçların pist üzerindeki ilerlemesini güncelle
        // Mesela, araç pist üzerindeki segmentleri geçtikçe Nitro miktarını artırabiliriz
        int currentSegment = Mathf.FloorToInt(vehicle.transform.position.magnitude / segmentLength);
        if (nitroBySegment.ContainsKey(currentSegment))
        {
            vehicle.UpdateNitro(nitroBySegment[currentSegment]);
        }
    }
}
