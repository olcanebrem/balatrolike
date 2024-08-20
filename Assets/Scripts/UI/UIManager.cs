using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text nitroText;
    public Text lapText;
    public GameObject buildMenu;

    void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (Player.instance != null)
        {
            nitroText.text = "Nitro: " + Player.instance.currentNitro.ToString();
            lapText.text = "Lap: " + Player.instance.currentLap.ToString(); // Güncellenmiş
        }
    }

    public void ToggleBuildMenu(bool show)
    {
        buildMenu.SetActive(show);
    }
}
