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
   
    [SerializeField]
    private StarCount starcount;
    // Start is called before the first frame update
    private Color originalColor; // 初期の色

    public Image Star1true;
    public Image Star2true;
    public Image Star3true;

    private AudioSource _audioSource;

    // スター獲得音追加　横田
    [SerializeField,Header("スター獲得音")]
    private AudioClip _starSound;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }


    void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        AudioSource.PlayClipAtPoint(_starSound,transform.position);

        if(starcount == StarCount.Star1)
        {
            Star1true.enabled = true;
            FadeManager.Instance.GetStars[0] = 1;
        }
        if (starcount == StarCount.Star2)
        {
            Star2true.enabled = true;
            FadeManager.Instance.GetStars[1] = 1;
        }
        if (starcount == StarCount.Star3)
        {
            Star3true.enabled = true;
            FadeManager.Instance.GetStars[2] = 1;
        }

        Destroy(this.gameObject);
    }
}
