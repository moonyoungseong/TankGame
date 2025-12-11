using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text skyText;
    public Text attackText;
    
    static public int Hit;
    static public int attack;

    void Start()
    {
        Hit = 0;
        attack = 0;
    }

    void Update()
    {
        skyText.text = "폭탄을 맞은 횟수 : " + Hit;
        attackText.text = "죽인 수 : " + attack;
    }
}
