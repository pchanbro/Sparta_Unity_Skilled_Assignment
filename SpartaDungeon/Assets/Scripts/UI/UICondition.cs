using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICondition : MonoBehaviour
{
    // 상태를 추가한다면 PlayerCondition에서 어떤식으로 다룰지도 생각하기
    public Condition health;
    
    void Start()
    {
        CharacterManager.Instance.Player.playerCondition.uiCondition = this;
    }

    void Update()
    {
        health.uiBar.fillAmount = health.GetPercentage();
    }
}
