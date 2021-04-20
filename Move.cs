using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Animator _animator;
    private CharacterController _controller;
    private Vector3 _playerVelocity;
    private bool _groundedPlayer;
    private float _playerSpeed;
    private float _jumpHeight = 1.0f;
    private float _gravity = Physics.gravity.y;
    [SerializeField] private float _playerRotationSpeed;    

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {

        _playerSpeed = Input.GetKey(KeyCode.LeftShift) ? 2.0f : 1.0f;
        _groundedPlayer = _controller.isGrounded;
        if (_playerVelocity.y <= 0.02)
        {
            _playerVelocity.y = 0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(x, 0.0f, z);
        
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("RunningJump") == false)
        {
            if (z != 0)
            {
                _controller.Move(transform.forward * z * _playerSpeed * Time.deltaTime);
                if (z < 0) {
                    _animator.ResetTrigger("Walk");
                    _animator.ResetTrigger("Run");
                    _animator.SetTrigger("WalkBackward");
                } else {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    _animator.SetTrigger("Run");
                    _animator.ResetTrigger("Walk");
                    _animator.ResetTrigger("WalkBackward");
                }
                else
                {
                    _animator.SetTrigger("Walk");
                    _animator.ResetTrigger("Run");
                    _animator.ResetTrigger("WalkBackward");
                }
                }
            }
            else
            {
                _animator.ResetTrigger("Walk");
                _animator.ResetTrigger("Run");
                _animator.ResetTrigger("WalkBackward");
            }
            if (x != 0)
            {
                transform.Rotate(transform.up * x * _playerRotationSpeed * Time.deltaTime);
            }
        }
        
        // Changes the height position of the player..        
         if (Input.GetButtonDown("Jump") && _groundedPlayer && _animator.GetBool("Run"))        
        {            
             _animator.SetTrigger("RunningJump");            
             _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -2.0f * _gravity);
             _playerVelocity.x = 0;
        } 
         

        _playerVelocity.y += _gravity * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);
    }
}