using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutPlay : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(FadeManager.Instance.FadeOut());
    }
}
