using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHouse : MonoBehaviour
{

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private bool _worked = false;

    public static Action HouseAttack = delegate { };

    private void OnCollisionEnter(Collision collision)
    {
        if (!_worked)
        {
            _worked = true;
            HouseAttack();
            _audioSource.PlayOneShot(_audioClip);
            Destroy(gameObject);
        }
    }
}
