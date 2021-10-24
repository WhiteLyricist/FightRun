using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] Canvas _enemyCanvas;
    [SerializeField] private TMP_Text _energyText;
    [SerializeField] private TMP_Text _hpText;

    public static Action<int, int, GameObject> EnemyAttack = delegate { };

    public int damage;
    public int price;

    private void OnCollisionEnter(Collision collision)
    {
        MoveController.stop = true;

        _camera.transform.localPosition = new Vector3(0f, 5.5f, -5.75f);
        _camera.transform.localEulerAngles = new Vector3(30, 0, 0);

        _enemyCanvas.gameObject.SetActive(true);
        _energyText.text = price.ToString();
        _hpText.text = damage.ToString();

        EnemyAttack(damage, price, gameObject);
    }
}
