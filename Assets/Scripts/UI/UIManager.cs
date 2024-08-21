using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text nitroText;
    public Text lapText;
    public GameObject buildMenu;
    public Button leftLaneButton;
    public Button rightLaneButton;

    public int laneIndex = 1;  // Başlangıçta right lane (1)

    void Start()
    {
        leftLaneButton.onClick.AddListener(() => SetLaneIndex(0));  // Left lane (0)
        rightLaneButton.onClick.AddListener(() => SetLaneIndex(1));  // Right lane (1)
    }
    void SetLaneIndex(int index)
    {
        laneIndex = index;
        Debug.Log("Lane index set to: " + laneIndex);
    }
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
