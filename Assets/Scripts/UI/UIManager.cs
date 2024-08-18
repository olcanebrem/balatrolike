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
        // Nitro ve tur sayısı gibi UI elemanlarını güncelle
    }

    public void ToggleBuildMenu(bool show)
    {
        buildMenu.SetActive(show);
    }
}
