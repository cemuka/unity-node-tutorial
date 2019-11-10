using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyView : MonoBehaviour
{
    public Text idText;
    public Text nameText;
    public Text healthText;
    public Text attackText;

    public void InitView(Enemy enemy)
    {
        idText.text = enemy.id.ToString();
        nameText.text = enemy.name;
        healthText.text = enemy.health.ToString();
        attackText.text = enemy.attack.ToString();
    }
}
