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

public class FxPlayer : MonoBehaviour
{
    [SerializeField] PlayerMove _playerMove;
    [SerializeField] ParticleSystem _startmoveParticle;
    [SerializeField] ParticleSystem _whilemoveParticle;

    List<ParticleSystem> _moveParticles;

    private void Start()
    {
        //EndMoveParticle();

        _playerMove.OnStartMove += LaunchMoveParticle;
        _playerMove.WhileUpdateMove += WhileMovingParticle;
        //playerMove.OnEndMove += EndMoveParticle;
    }

    private void LaunchMoveParticle ()
    {
        ParticleSystem particleSystem = Instantiate(_startmoveParticle, transform.position, transform.rotation);
        particleSystem.Play();
        //_moveParticles.Add(particleSystem);

        StartCoroutine(Routine());
        IEnumerator Routine()
        {
            yield return new WaitForSeconds(0.8f);
            particleSystem.Stop( false,ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }

    private void WhileMovingParticle()
    {
        ParticleSystem particleSystem2 = Instantiate(_whilemoveParticle, transform.position, transform.rotation);
        particleSystem2.Play();
        //_moveParticles.Add(particleSystem2);

        StartCoroutine(Routine());
        IEnumerator Routine()
        {
            yield return new WaitForSeconds(0.2f);
            particleSystem2.Stop(false, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }

}
