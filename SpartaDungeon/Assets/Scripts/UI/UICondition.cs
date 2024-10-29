using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICondition : MonoBehaviour
{
    // ���¸� �߰��Ѵٸ� PlayerCondition���� ������� �ٷ����� �����ϱ�
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
