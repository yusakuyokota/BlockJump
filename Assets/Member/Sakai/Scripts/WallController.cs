using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WallController : MonoBehaviour
{
    public enum Color
    {
       Red,
       Blue
    }
  
    [SerializeField]
    private Color color;
    private string WallRed = "Red";
    private string WallBlue = "Blue";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.name == "Block")
        {
          
            if (color == Color.Red)
            {
                
                if (other.gameObject.CompareTag(WallBlue))
                {
                    Debug.Log("hai");
                    Destroy(other.gameObject);
                    StartCoroutine(DestroyAction());
                }
               
            }
            if(color == Color.Blue)
            {
             
                if (other.gameObject.CompareTag(WallRed))
                {
                    Destroy(other.gameObject);
                    StartCoroutine(DestroyAction());
                }
             
            }
        }
    }
    private IEnumerator DestroyAction()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("gameover");
    }
}
