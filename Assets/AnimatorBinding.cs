using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class AnimatorBinding : MonoBehaviour
{

    [SerializeField] private PlayerMove _playerMoveScript;
    [SerializeField] private PlayerAttack _playerAttackScript;
    [SerializeField] private PlayerHealth _playerHealthScript;

    private Animator _animator;


    void Start()
    {
        _animator = GetComponent<Animator>();

        if (_playerMoveScript != null) { 
            _playerMoveScript.OnStartMove += Walking;
            _playerMoveScript.OnEndMove += StopWalking;
        }

        if (_playerAttackScript != null) { 
            _playerAttackScript.OnStartAttack += Attacking;
            _playerAttackScript.OnEndAttack += StopAttacking;
        }

        if (_playerHealthScript != null)
        {

            _playerHealthScript.OnHealthUpdate += GetHit;
        }
    }

    private void OnDestroy()
    {
        if (_playerMoveScript != null)
        {
            _playerMoveScript.OnStartMove -= Walking;
            _playerMoveScript.OnEndMove -= StopWalking;
        }

        if (_playerAttackScript != null)
        {
            _playerAttackScript.OnStartAttack -= Attacking;
            _playerAttackScript.OnEndAttack -= StopAttacking;
        }

        if (_playerHealthScript != null)
        {

            _playerHealthScript.OnHealthUpdate -= GetHit;
        }
    }

    private void GetHit(float currentHealth, float maxHealth)
    {
        _animator.SetBool("GetHit", true);

        StartCoroutine(Wait());
        IEnumerator Wait()
        {
            yield return new WaitForSeconds(1f);
            _animator.SetBool("GetHit", false);
        }
    }

    private void Walking()
    {
        _animator.SetBool("Walking", true);
    }

    private void StopWalking()
    {
        _animator.SetBool("Walking", false);
    }

    private void Attacking()
    {
        _animator.SetBool("Attack", true);
    }
    private void StopAttacking()
    {
        _animator.SetBool("Attack", false);
    }
}
