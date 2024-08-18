using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public void SaveGame(Player player)
    {
        // Oyuncu verilerini JSON formatında kaydet
        string jsonData = JsonUtility.ToJson(player);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", jsonData);
    }

    public Player LoadGame()
    {
        // Oyuncu verilerini JSON formatında yükle
        if (File.Exists(Application.persistentDataPath + "/savefile.json"))
        {
            string jsonData = File.ReadAllText(Application.persistentDataPath + "/savefile.json");
            Player player = JsonUtility.FromJson<Player>(jsonData);
            return player;
        }
        return null;
    }
}
