using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    public enum StarCount
    {
        Star1,
        Star2,
        Star3
    }
    // UI Textオブジェクトへの参照
    public Image uiImage;
    public Color collisionColor = Color.white; 
    [SerializeField]
    private StarCount starcount;
    // Start is called before the first frame update
    private Color originalColor; // 初期の色

    public Image Star1true;
    public Image Star2true;
    public Image Star3true;
    void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        if(starcount == StarCount.Star1)
        {
          Star1true.enabled = true;
        }
        if (starcount == StarCount.Star2)
        {
            Star2true.enabled = true;
        }
        if (starcount == StarCount.Star3)
        {
            Star3true.enabled = true;
        }
        Destroy(this.gameObject);
    }
}
