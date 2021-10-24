using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] public Slider slider;
    [SerializeField] public Image image;

    public int maxValue = 6;
    public Color color = Color.red;
    public int width = 4;
    public bool isRight;

    private int _current;
    private RectTransform _rect;

    public static Action Defeat = delegate { };

    void Start()
    {
        Healing.HealingPlayer += OnHealingPlayer;
        EnemyController.FightEnemy += OnFightEnemy;
        EnemyHouse.HouseAttack += OnHouseAttack;

        slider.fillRect.GetComponent<Image>().color = color;

        _rect = slider.GetComponent<RectTransform>();

        slider.maxValue = maxValue;
        slider.minValue = 0;
        _current = maxValue;

        UpdateUI();
    }

    void Update()
    {
        if (_current < 0) _current = 0;
        if (_current > maxValue) _current = maxValue;
        slider.value = _current;
    }

    void UpdateUI()
    {
        int rectDeltaX = Screen.width / width;
        float rectPosX = 0;

        if (isRight)
        {
            rectPosX = _rect.position.x - (rectDeltaX - _rect.sizeDelta.x) / 2;
            slider.direction = Slider.Direction.RightToLeft;
        }
        else
        {
            rectPosX = _rect.position.x + (rectDeltaX - _rect.sizeDelta.x) / 2;
            slider.direction = Slider.Direction.LeftToRight;
        }

        _rect.sizeDelta = new Vector2(rectDeltaX, _rect.sizeDelta.y);
        _rect.position = new Vector3(rectPosX, _rect.position.y, _rect.position.z);
    }

    void OnHealingPlayer()
    {
        _current++;
    }

    void OnHouseAttack() 
    {
        _current--;
        if (_current < 1)
        {
            Defeat();
        }
    }

    void OnFightEnemy(int damage) 
	{
		_current-=damage;
		if (_current < 1) 
		{
            Defeat();
        }
	}

    private void OnDestroy()
    {
		Healing.HealingPlayer -= OnHealingPlayer;
		EnemyController.FightEnemy -= OnFightEnemy;
		EnemyHouse.HouseAttack -= OnHouseAttack;
	}
}
