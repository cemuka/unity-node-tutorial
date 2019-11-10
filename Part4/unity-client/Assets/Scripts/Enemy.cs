[System.Serializable]
public class Enemy
{
    public string id;
    public string name;
    public int health;
    public int attack;
}

public class EnemyRequestData
{
    public string name;
    public int health;
    public int attack;

    public EnemyRequestData(string name, int health, int attack)
    {
        this.name = name;
        this.health = health;
        this.attack = attack;
    }
}
