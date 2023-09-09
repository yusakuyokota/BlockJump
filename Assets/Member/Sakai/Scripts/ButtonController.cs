using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class ButtonController : MonoBehaviour
{
    public Button retryButton;
    public Button returnToTitleButton;

    private void Start()
    {
        // Retryボタンにクリック時の処理を追加
        retryButton.onClick.AddListener(RetryGame);
        if (returnToTitleButton != null)
        {
            // タイトルへ戻るボタンにクリック時の処理を追加
            returnToTitleButton.onClick.AddListener(ReturnToTitle);
        }
    }

    // Retryボタンがクリックされたときの処理
    void RetryGame()
    {
        StartCoroutine(FadeManager.Instance.FadeIn(() => SceneManager.LoadScene("game")));

        for (int i = 0; i < 3; i++)
        {
            FadeManager.Instance.GetStars[i] = 0;
        }
    }

    // タイトルへ戻るボタンがクリックされたときの処理
    void ReturnToTitle()
    {
        if (returnToTitleButton != null)
        {
            StartCoroutine(FadeManager.Instance.FadeIn(() => SceneManager.LoadScene("title")));
        }
    }
}