using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Goal : MonoBehaviour
{
    
    void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        this.enabled = false;
        Rigidbody2D otherRigidbody = other.gameObject.GetComponent<Rigidbody2D>();

        if (otherRigidbody != null)
        {
            // ‘ŠŽè‚ÌRigidbody2D‚ð–³Œø‚É‚·‚é
            otherRigidbody.velocity = Vector2.zero;
            otherRigidbody.isKinematic = true;
        }
        StartCoroutine(DelayedAction());
      
    }
    private IEnumerator DelayedAction()
    {

        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("clear");
    }
}
