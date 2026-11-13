using TMPro;
using UnityEngine;

public class DataUi : MonoBehaviour
{
    public TextMeshProUGUI hPUi1;
    public TextMeshProUGUI hPUi2;
    public TextMeshProUGUI SpeedUi1;
    public TextMeshProUGUI SpeedUi2;
    public TextMeshProUGUI JumpUi1;
    public TextMeshProUGUI JumpUi2;
    public PlayerStats playerStats1;
    public PlayerStats playerStats2;

    // Update is called once per frame
    void Update()
    {
        hPUi1.text = playerStats1.hp.ToString();
        hPUi2.text = playerStats2.hp.ToString();
        SpeedUi1.text = playerStats1.speed.ToString();
        SpeedUi2.text = playerStats2.speed.ToString();
        JumpUi1.text = playerStats1.jumpForce.ToString();
        JumpUi2.text = playerStats2.jumpForce.ToString();
    }
}
