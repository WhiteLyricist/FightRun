using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private bool _worked = false;

    public static Action HealingPlayer = delegate { };

    private void OnCollisionEnter(Collision collision)
    {
        if (!_worked)
        {
            _audioSource.PlayOneShot(_audioClip);
            _worked = true;
            HealingPlayer();
            Destroy(gameObject);
        }
    }
}
