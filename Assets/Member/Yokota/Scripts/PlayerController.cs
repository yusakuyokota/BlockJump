using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerObj;

    [SerializeField]
    private Rigidbody2D _playerRb;

    private bool _isJumping = false;

    private bool _rightWallCollision = false;

    private bool _leftWallCollision = false;

    private Vector3 LocalGravity_right = new Vector3(1, 0, 0);

    private Vector3 LocalGravity_left = new Vector3(-1, 0, 0);

    private void Start()
    {

    }

    private void Update()
    {
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            if (!_isJumping)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _playerRb.AddForce(new Vector3(3, 3, 0), ForceMode2D.Impulse);
                }

                if (Input.GetMouseButtonDown(1))
                {
                    _playerRb.AddForce(new Vector3(-3, 3, 0), ForceMode2D.Impulse);
                }
            }
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            if (!_isJumping)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _playerRb.AddForce(new Vector3(10, 10, 0), ForceMode2D.Impulse);
                }

                if (Input.GetMouseButtonDown(1))
                {
                    _playerRb.AddForce(new Vector3(-10, 10, 0), ForceMode2D.Impulse);
                }
            }
        }

        if (_rightWallCollision)
        {
            _playerRb.AddForce(LocalGravity_right, ForceMode2D.Force);
        }

        if (_leftWallCollision)
        {
            _playerRb.AddForce(LocalGravity_left, ForceMode2D.Force);
        }
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    transform.position = _playerPos;
    //}

    // ï«Ç…ìñÇΩÇ¡ÇΩÇ∆Ç´èdóÕÇïœçXÇ∑ÇÈ
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isJumping = false;

        if (collision.gameObject.tag == "Ground")
        {
            _playerRb.gravityScale = 1;
        }
        else if (collision.gameObject.tag == "Ceiling")
        {
            _playerRb.gravityScale = -1;
        }
        else if (collision.gameObject.tag == "RightWall")
        {
            _playerRb.gravityScale = 0;
            _rightWallCollision = true;
        }
        else if (collision.gameObject.tag == "LeftWall")
        {
            _playerRb.gravityScale = 0;
            _leftWallCollision = true;
        }
    }

        private void OnCollisionExit2D(Collision2D collision)
    {
        _playerRb.gravityScale = 1;

        if (_rightWallCollision) _rightWallCollision = false;

        if (_leftWallCollision) _leftWallCollision = false;

        _isJumping = true;
    }
}
