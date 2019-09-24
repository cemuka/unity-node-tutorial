using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyViewController : MonoBehaviour
{
    public Text nameText;
    public Text healthText;
    public Text attackText;

    public void DisplayEnemyData(string name, string health, string attack)
    {
        nameText.text = name;
        healthText.text = health;
        attackText.text = attack;
    }
}
