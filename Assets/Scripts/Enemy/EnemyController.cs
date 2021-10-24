using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Canvas _enemyCanvas;
    [SerializeField] Camera _camera;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private int _damage;
    private int _price;
    private GameObject _enemy;

    public static Action<int> FightEnemy = delegate { };
    public static Action<int> BuyOffEnemy = delegate { };

    void Start()
    {
        Enemy.EnemyAttack += OnEnemyAttack;
    }

    void OnEnemyAttack(int damage, int price, GameObject enemy) 
    {
        _damage = damage;
        _enemy = enemy;
        _price = price;
    }

    public void Fight()
    {
        _enemyCanvas.gameObject.SetActive(false);

        _camera.transform.localPosition = new Vector3(0, 0.5f, -0.2f);
        _camera.transform.localEulerAngles = Vector3.zero;

        MoveController.stop = false;

        FightEnemy(_damage);
        _audioSource.PlayOneShot(_audioClip);
        Destroy(_enemy);
    }

    public void BuyOff() 
    {
        _enemyCanvas.gameObject.SetActive(false);

        _camera.transform.localPosition = new Vector3(0, 0.5f, -0.2f);
        _camera.transform.localEulerAngles = Vector3.zero;

        MoveController.stop = false;

        BuyOffEnemy(_price);
        _audioSource.PlayOneShot(_audioClip);
        Destroy(_enemy);
    }

    private void OnDestroy()
    {
        Enemy.EnemyAttack -= OnEnemyAttack;
    }
}
