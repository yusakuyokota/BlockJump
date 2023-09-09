using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultCreate : MonoBehaviour
{
    [SerializeField]
    private Image Star1true;
    [SerializeField]
    private Image Star2true;
    [SerializeField]
    private Image Star3true;

    private void Start()
    {
        if (FadeManager.Instance.GetStars[0] == 1)
        {
            Star1true.enabled = true;
        }
        if (FadeManager.Instance.GetStars[1] == 1)
        {
            Star2true.enabled = true;
        }
        if (FadeManager.Instance.GetStars[2] == 1)
        {
            Star3true.enabled = true;
        }
    }
}
