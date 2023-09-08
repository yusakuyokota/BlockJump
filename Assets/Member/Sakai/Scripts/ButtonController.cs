using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("game");
    }

    // �^�C�g���֖߂�{�^�����N���b�N���ꂽ�Ƃ��̏���
    void ReturnToTitle()
    {
        if(returnToTitleButton != null)
        SceneManager.LoadScene("title");
    }
}