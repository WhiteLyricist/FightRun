using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIEnergy : MonoBehaviour
{
    [SerializeField] private TMP_Text _energyText;
    [SerializeField] public Image image;
    [SerializeField] private TMP_Text _wonText;
    [SerializeField] private TMP_Text _defeatText;
    [SerializeField] public Image won;

    private int _energy = 0;
    private bool _won = true;

    void Start()
    {
        Recharge.RechargePlayer += OnRechargePlayer;
        EnemyController.BuyOffEnemy += OnBuyOffEnemy;
        Victory.Won += OnWon;
        UIHealthBar.Defeat += OnDefeat;

        _energyText.text = _energy.ToString();
    }

    void OnRechargePlayer()
    {
        _energy++;
        _energyText.text = _energy.ToString();
    }

    void OnBuyOffEnemy(int price) 
    {
        _energy -= price;
        if (_energy < 0) 
        {
            OnDefeat();
        }
        _energyText.text = _energy.ToString();
    }

    void OnWon() 
    {
        if (_won)
        {
            won.gameObject.SetActive(true);
            MoveController.stop = true;
            _wonText.text = _energy.ToString();
        }
    }

    void OnDefeat() 
    {
        _won = false;
        MoveController.stop = true;
        image.gameObject.SetActive(true);
        _defeatText.text += _energy.ToString(); ;
    }

    private void OnDestroy()
    {
        Recharge.RechargePlayer -= OnRechargePlayer;
        Victory.Won -= OnWon;
        EnemyController.BuyOffEnemy -= OnBuyOffEnemy;
        UIHealthBar.Defeat -= OnDefeat;
    }
}
