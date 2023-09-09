using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    [SerializeField]
    private Image _fadeImage;

    public static FadeManager Instance { get; private set; } = null;   // シングルトン

    public sbyte[] GetStars = new sbyte[3];

    void Awake()
    {
        if (Instance == null)
        {
            // インスタンスがない場合は代入
            Instance = this;

            // シーン切り替え時に消さないようにする
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // ある場合は２つ目なのでゲームオブジェクトを消す
            Destroy(this.gameObject);
        }
    }

    public IEnumerator FadeIn(Action action)
    {
        while (_fadeImage.color.a < 1)
        {
            float alpha
                = _fadeImage.color.a + Time.deltaTime * 2f;
            if (alpha > 1) alpha = 1f;
            _fadeImage.color = new Color(_fadeImage.color.r
                                        , _fadeImage.color.g
                                        , _fadeImage.color.b
                                        , alpha);
            yield return null;
        }

        if (action != null) action();

        yield return null;
    }

    public IEnumerator FadeOut()
    {
        while (_fadeImage.color.a > 0)
        {
            float alpha
                = _fadeImage.color.a - Time.deltaTime * 2f;
            if (alpha < 0) alpha = 0f;
            _fadeImage.color = new Color(_fadeImage.color.r
                                        , _fadeImage.color.g
                                        , _fadeImage.color.b
                                        , alpha);
            yield return null;
        }

        yield return null;
    }
}
