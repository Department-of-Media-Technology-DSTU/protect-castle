using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRemoval : MonoBehaviour
{
    public PlaceTower placeTower;
    private GameManagerBehavior gameManagere;  // to access the GameManager Behavior component of the scene's GameManager object

    public void Click()
    {
        Destroy(placeTower.Tower);
        gameManagere.Gold += placeTower.Tower.GetComponent<TowerData>().CurrentLevel.refundAmount;
        placeTower.transform.Find("tower work").gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManagere = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
    }
}
