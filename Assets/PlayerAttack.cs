using Cinemachine;
using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PlayerAttack : MonoBehaviour
{
    [SerializeField] InputActionReference _attack;
    [SerializeField] GameObject _attackBoxObject;
    [SerializeField] private HitEntity _hitEntity;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _attackDelay;
    [SerializeField] int _damage = 5;

    bool _canDamage = true;

    //
    public event Action OnStartAttack;
    public event Action OnEndAttack;


    private void OnDestroy()
    {
        _attack.action.started -= StartAttack;
        _attack.action.canceled -= EndAttack;
    }

    private void Start()
    {
        _attack.action.started += StartAttack;
        _attack.action.canceled += EndAttack;
    }

    
    IEnumerator delayNextAttack ()
    {
        yield return new WaitForSeconds(_attackDelay);
        _canDamage = true;
    }

    IEnumerator Attacking()
    {
        _hitEntity.Damage = _damage;
        //delay before hitbox ON
        yield return new WaitForSeconds(0.03f);
        _hitEntity.gameObject.GetComponent<BoxCollider>().enabled = true;

        //delay while hitbox ON
        yield return new WaitForSeconds(0.03f);
        _hitEntity.gameObject.GetComponent<BoxCollider>().enabled = false;
    }


    void Attack()
    {
        if (_hitEntity != null)
        {
            _canDamage = false;
            
            //delay manage for smash bros like box hit
            StartCoroutine(Attacking());
            
            //1 sec delay before next attack
            StartCoroutine(delayNextAttack());
        }
    }

    public float GetCurrentAnimatorTime(Animator targetAnim, int layer = 0)
    {
        AnimatorStateInfo animState = targetAnim.GetCurrentAnimatorStateInfo(layer);
        if (animState.IsName("Attack01_SwordAndShiled 0"))
        {
            float currentTime = animState.normalizedTime % 1;
            return currentTime;
        }
        else { return 0f; }
    }

    private void StartAttack(InputAction.CallbackContext obj)
    {
        if (_canDamage)
        {
            OnStartAttack?.Invoke();
            Attack();
        }

         //0.3, 0.6
    }

    private void EndAttack(InputAction.CallbackContext obj)
    {
        OnEndAttack?.Invoke();
    }

/*    private void Update()
    {
        Debug.Log(GetCurrentAnimatorTime(_animator));
    }*/
}

// permet de timer l'activation de la box selon le statut de l'animation ( ici entre 0.2 et 0.5 )
/*            if (GetCurrentAnimatorTime(_animator) > 0.4f && GetCurrentAnimatorTime(_animator) < 0.5f)
            {
                Debug.Log(GetCurrentAnimatorTime(_animator));
                _hitEntity.ApplyDamage(_damage);
                break;
            }*/
