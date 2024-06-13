using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rigidbody;
    private bool _jump = false;
    public float jumpForce = 40f;
    public float moveSpeed = 2f;

    protected void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected void Update()
    {
        var moveInput = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));

        // Обновляем анимацию бега в зависимости от ввода
        _animator.SetFloat("moveSpeed", moveInput.magnitude);

        // Движение персонажа
        transform.Translate(moveInput * moveSpeed * Time.deltaTime);

        // Сбрасываем состояние прыжка после завершения прыжка
        if (_jump)
        {
            _jump = false;
            _animator.SetBool("Jump", _jump);
        }

        // Проверяем нажатие пробела и наличие ввода для движения
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jump = true;
            _animator.SetBool("Jump", _jump);
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
