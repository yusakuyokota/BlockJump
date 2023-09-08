using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    public Text starText;
    private int coinCount = 0;

    private void Start()
    {
        UpdateStarText();
    }

    public void CollectStar()
    {
        coinCount++;
        UpdateStarText();
    }

    void UpdateStarText()
    {
        starText.text = "Stars: " + coinCount.ToString();
    }
}




