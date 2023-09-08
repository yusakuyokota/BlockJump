using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("game");
    }

    // タイトルへ戻るボタンがクリックされたときの処理
    void ReturnToTitle()
    {
        if(returnToTitleButton != null)
        SceneManager.LoadScene("title");
    }
}