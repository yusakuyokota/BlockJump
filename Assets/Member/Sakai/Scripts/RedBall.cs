using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBall : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        SpriteRenderer renderer = other.gameObject.GetComponent<SpriteRenderer>();

        // SpriteRendererが存在する場合、色を赤に変更
        if (renderer != null)
        {
            renderer.color = Color.red;
        }
        other.gameObject.tag = "Red";

        Destroy(this.gameObject);
    }
}
