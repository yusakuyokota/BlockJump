using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void OnCollisionEnter(Collision2D other)
    {
       
        if (other.gameObject.name == "Block")
        {
            if (color == Color.Red)
            {
                if (this.gameObject.CompareTag(WallBlue))
                {
                    Destroy(other.gameObject);
                }
               
            }
            if(color == Color.Blue)
            {
                if (this.gameObject.CompareTag(WallRed))
                {
                    Destroy(other.gameObject);
                }
             
            }
        }
    }
}
