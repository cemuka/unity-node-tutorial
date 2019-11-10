using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu]
public class EnemyDatabase : ScriptableObject 
{
    [SerializeField]
    private List<Enemy> database = new List<Enemy>();

    public List<Enemy> GetEnemies() => database;

    public void Add(Enemy enemy)
    {
        database.Add(enemy);
    }

    public void ClearInventory()
    {
        database.Clear();
    }
}