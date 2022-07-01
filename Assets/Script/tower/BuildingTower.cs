using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTower : MonoBehaviour
{
    public PlaceTower placeTower;
    public GameObject towerPrefab;
    private GameManagerBehavior gameManagere;  // to access the GameManager Behavior component of the scene's GameManager object

    public bool CanPlaceTower()
    {
        int cost = towerPrefab.GetComponent<TowerData>().levels[0].cost;
        return placeTower.Tower == null && gameManagere.Gold >= cost;
    }

    // positions the tower on mouse click or screen touch
    public void Click()
    {
        if (CanPlaceTower())
        {
            placeTower.Tower = Instantiate(towerPrefab, placeTower.transform.position, Quaternion.identity);
            gameManagere.Gold -= placeTower.Tower.GetComponent<TowerData>().CurrentLevel.cost;
            placeTower.transform.Find("tower selection").gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManagere = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
    }

}
