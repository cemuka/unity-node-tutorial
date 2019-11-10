using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public Transform canvasParent;
    public ClientApi client;
    public EnemyDatabase enemyDatabase;
    
    private Transform contentParent;
    private GameObject enemyViewPrefab;
    private EnemyFormView formView;

    private List<EnemyView> enemyViews = new List<EnemyView>();

    private void Start()
    {
        CreateListView();
        CreateFormView();
        enemyViewPrefab = Resources.Load<GameObject>("Prefabs/EnemyView");
        
        RequestEnemies();
    }

    private void CreateFormView()
    {
        var formPanelPrefab = Resources.Load("Prefabs/EnemyFormPanel");
        var formPanelGO = Instantiate(formPanelPrefab, canvasParent) as GameObject;
        formView = formPanelGO.GetComponent<EnemyFormView>();
        formView.InitFormView(SendCreateRequest);
    }

    private void CreateListView()
    {
        var listPanelPrefab = Resources.Load("Prefabs/EnemyListPanel");
        var listPanelGO = Instantiate(listPanelPrefab, canvasParent) as GameObject;
        contentParent = listPanelGO.GetComponentInChildren<ScrollRect>().content;
    }  

    private void SendCreateRequest(EnemyRequestData data)
    {
        client.PostRequest(client.postUrl, data, result => {
            Debug.Log(result);
            OnDataRecieved(result);
            });
    }

    private void RequestEnemies()
    {
        client.GetRequest(client.getUrl, result => {
            Debug.Log(result);
            OnDataRecieved(result);
        });
    }

    private void OnDataRecieved(string json)
    {
        var recievedEnemies = JsonHelper.FromJson<Enemy>(json);
        enemyDatabase.ClearInventory();

        foreach (var enemy in recievedEnemies)
        {
            enemyDatabase.Add(enemy);
        }

        CreateEnemyViews();
    }

    private void CreateEnemyViews()
    {
        var currentEnemies = enemyDatabase.GetEnemies();

        //destroy old views
        if (enemyViews.Count > 0)
        {
            foreach (var enemy in enemyViews)
            {
                Destroy(enemy.gameObject);
            }
        }

        //create new enemy views
        foreach (var enemy in currentEnemies)
        {
            var enemyViewGO = Instantiate(enemyViewPrefab, contentParent) as GameObject;
            var enemyView = enemyViewGO.GetComponent<EnemyView>();
            enemyView.InitView(enemy);
            enemyViews.Add(enemyView);
        }
    }
}
