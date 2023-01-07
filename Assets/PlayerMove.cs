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

public class PlayerMove : MonoBehaviour
{
    // Movement values
    [SerializeField] InputActionReference _move;
    [SerializeField] float _speed;

    // Event pour les dev
    public event Action OnStartMove;
    public event Action OnEndMove;

    //FX event and values
    public event Action WhileUpdateMove;
    [SerializeField] private float _newParticleDelay;

    // Properties of movement
    public Vector2 JoystickDirection { get; private set; }
    Coroutine MovementRoutine { get; set; }

    private void Start()
    {
        _move.action.started += StartMove;
        _move.action.performed += UpdateMove;
        _move.action.canceled += StopMove;
    }

    private void OnDestroy()
    {
        _move.action.started -= StartMove;
        _move.action.performed -= UpdateMove;
        _move.action.canceled -= StopMove;
    }

    IEnumerator MoveRoutine()
    {
        //activate every function that as been registered to "OnStartMove"
        OnStartMove?.Invoke();

        //count time for fx
        float actualDelay = 0;

        while (true)
        {
            yield return new WaitForFixedUpdate();


            // Undo commentary for fun :)
/*
            float singleStep = _speed * Time.fixedDeltaTime;
            transform.position = Vector3.RotateTowards(transform.position, new Vector3(JoystickDirection.x, 0, JoystickDirection.y), singleStep, 0f);
*/

            //move in joystick direction
            transform.Translate(new Vector3(JoystickDirection.x, 0, JoystickDirection.y) * _speed * Time.fixedDeltaTime);

            //check if delay as passed and activate every function that as been registered to "WhileUpdateMove" (fx)
            if (actualDelay > _newParticleDelay)
            {
                WhileUpdateMove?.Invoke();
                actualDelay = 0;
            }
            actualDelay += Time.fixedDeltaTime;
        }
    }

    //called when joystick or (zqsd) is pressed
    private void StartMove(InputAction.CallbackContext obj)
    {
        JoystickDirection = obj.ReadValue<Vector2>();
        MovementRoutine = StartCoroutine(MoveRoutine());
    }

    //called when input is changed
    private void UpdateMove(InputAction.CallbackContext obj)
    {
        JoystickDirection = obj.ReadValue<Vector2>();
    }

    
    // check if an item and use the effect of the item
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Item>() != null)
        {
            Item a  = other.gameObject.GetComponent<Item>();
            a.Use();
        }

    }
    //called when joystick or (zqsd) is released
    private void StopMove(InputAction.CallbackContext obj)
    {
        //end coroutine so that no movement action can be performed
        StopCoroutine(MovementRoutine);
        OnEndMove?.Invoke();

        JoystickDirection = Vector2.zero;
    }

    



}
