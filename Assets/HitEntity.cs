using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEntity : MonoBehaviour
{
    [SerializeField] float _damage;
    EntityHealth _otherEntityHealth;

    public float Damage { get { return _damage; } set { _damage = value ; }}

    private void OnTriggerEnter(Collider other)
    {
        _otherEntityHealth = other.GetComponentInParent<EntityHealth>();

        if (_otherEntityHealth != null)
        {
            _otherEntityHealth.TakeDamage(Damage);
            GetComponent<Collider>().enabled = false;
        }
    }
}
