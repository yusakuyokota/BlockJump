using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _playerRb;

    private byte _countJump = 0;

    private bool _rightWallCollision = false;

    private bool _leftWallCollision = false;

    private sbyte _onGroundKey = 0;

    private Vector3 LocalGravity_right = new Vector3(1, 0, 0);

    private Vector3 LocalGravity_left = new Vector3(-1, 0, 0);

    private Vector3 _mousePosition = Vector3.zero;

    private Vector3 _velocity = Vector3.zero;

    private AudioSource _audioSource;

    [SerializeField] 
    private AudioClip _normalJump;

    [SerializeField]
    private AudioClip _superJump;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayerJump();
            
        }

        if (_rightWallCollision)
        {
            _playerRb.AddForce(LocalGravity_right, ForceMode2D.Force);
        }

        if (_leftWallCollision)
        {
            _playerRb.AddForce(LocalGravity_left, ForceMode2D.Force);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
        }
    }

    // ï«Ç…ìñÇΩÇ¡ÇΩÇ∆Ç´èdóÕÇïœçXÇ∑ÇÈ
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _playerRb.gravityScale = 1;
            _playerRb.velocity = Vector3.zero;
            _onGroundKey = 1;
        }
        else if (collision.gameObject.tag == "Ceiling")
        {
            _playerRb.gravityScale = -1;
            _playerRb.velocity = Vector3.zero;
            _onGroundKey = -1;
        }
        else if (collision.gameObject.tag == "RightWall")
        {
            _playerRb.gravityScale = 0;
            _playerRb.velocity = Vector3.zero;
            _rightWallCollision = true;
        }
        else if (collision.gameObject.tag == "LeftWall")
        {
            _playerRb.gravityScale = 0;
            _playerRb.velocity = Vector3.zero;
            _leftWallCollision = true;
        }
    }

        private void OnCollisionExit2D(Collision2D collision)
    {
        _playerRb.gravityScale = 1;

        _onGroundKey = 1;

        if (_rightWallCollision) _rightWallCollision = false;

        if (_leftWallCollision) _leftWallCollision = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        _countJump = 0;
    }

    private void PlayerJump()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (_countJump < 1)
            {
                _playerRb.velocity = Vector3.zero;

                _mousePosition = (Input.mousePosition - new Vector3(960.0f, 540.0f)) / 100;
                _velocity = _mousePosition - _playerRb.transform.position;
                _playerRb.AddForce(_velocity.normalized * 8, ForceMode2D.Impulse);
                _countJump++;

                _audioSource.PlayOneShot(_superJump);
            }
        }
        else
        {
            if (_countJump < 1)
            {
                _playerRb.velocity = Vector3.zero;

                _mousePosition = (Input.mousePosition - new Vector3(960.0f, 540.0f)) / 100;
                _velocity = _mousePosition - _playerRb.transform.position;
                sbyte key = 0;
                if (_velocity.x > 0) key = 1;
                else if (_velocity.x < 0) key = -1;
                _playerRb.AddForce(new Vector3(key * 2, _onGroundKey * 3, 0), ForceMode2D.Impulse);
                _countJump++;

                _audioSource.PlayOneShot(_normalJump);
            }
        }
    }
}
