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
        // Retry�{�^���ɃN���b�N���̏�����ǉ�
        retryButton.onClick.AddListener(RetryGame);
        if (returnToTitleButton != null)
        {
            // �^�C�g���֖߂�{�^���ɃN���b�N���̏�����ǉ�
            returnToTitleButton.onClick.AddListener(ReturnToTitle);
        }
    }

    // Retry�{�^�����N���b�N���ꂽ�Ƃ��̏���
    void RetryGame()
    {
        StartCoroutine(FadeManager.Instance.FadeIn(() => SceneManager.LoadScene("game")));

        for (int i = 0; i < 3; i++)
        {
            FadeManager.Instance.GetStars[i] = 0;
        }
    }

    // �^�C�g���֖߂�{�^�����N���b�N���ꂽ�Ƃ��̏���
    void ReturnToTitle()
    {
        if (returnToTitleButton != null)
        {
            StartCoroutine(FadeManager.Instance.FadeIn(() => SceneManager.LoadScene("title")));
        }
    }
}