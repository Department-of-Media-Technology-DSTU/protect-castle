using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    private GameObject tower;  // object to be handled during the game

    public GameObject towerName;
    public GameObject towerDescription;
    public GameObject towerBuild;
    public GameObject towerUpgrade;
    public GameObject towerDelete;

    public GameObject Tower
    {
        get
        {
            return tower;
        }
        set
        {
            tower = value;
        }
    }

    public void Filling()
    {
        towerName.transform.Find("TowerView").GetComponent<Image>().sprite = tower.GetComponent<TowerData>().icon;
        towerName.transform.Find("TowerViewLabel").GetComponent<Text>().text = tower.GetComponent<TowerData>().Name;
        towerDescription.transform.Find("StrengthLabel").GetComponent<Text>().text = tower.GetComponent<TowerData>().CurrentLevel.strength;
        towerDescription.transform.Find("RateOfFireLabel").GetComponent<Text>().text = tower.GetComponent<TowerData>().CurrentLevel.rateOfFire;
        towerDescription.transform.Find("AttackRadiusLabel").GetComponent<Text>().text = tower.GetComponent<TowerData>().CurrentLevel.attackRadius;
    }

    public void FillingTowerBuild(BuildingTower prefab)
    {
        towerBuild.transform.Find("TowerImg").GetComponent<Image>().sprite = prefab.towerPrefab.GetComponent<TowerData>().levels[0].img;
        towerBuild.transform.Find("TowerNameLabel").GetComponent<Text>().text = prefab.towerPrefab.GetComponent<TowerData>().Name;
        towerBuild.transform.Find("StrangeLabel").GetComponent<Text>().text = "Сила: " + prefab.towerPrefab.GetComponent<TowerData>().levels[0].strength;
        towerBuild.transform.Find("SpeedLabel").GetComponent<Text>().text = "Скорость: " + prefab.towerPrefab.GetComponent<TowerData>().levels[0].rateOfFire;
        towerBuild.transform.Find("RadiousLabel").GetComponent<Text>().text = "Радиус: " + prefab.towerPrefab.GetComponent<TowerData>().levels[0].attackRadius;
        towerBuild.transform.Find("CostLabel").GetComponent<Text>().text = "Цена: " + prefab.towerPrefab.GetComponent<TowerData>().levels[0].cost;
    }

    public void FillingTowerUpgrade()
    {
        int indexTower = tower.GetComponent<TowerData>().levels.IndexOf(tower.GetComponent<TowerData>().CurrentLevel) + 1;
        if (indexTower < 3)
        {
            towerUpgrade.transform.Find("TowerImg").GetComponent<Image>().sprite = tower.GetComponent<TowerData>().levels[indexTower].img;
            towerUpgrade.transform.Find("TowerNameLabel").GetComponent<Text>().text = tower.GetComponent<TowerData>().Name;
            towerUpgrade.transform.Find("StrangeLabel").GetComponent<Text>().text = "Сила: " + tower.GetComponent<TowerData>().levels[indexTower].strength;
            towerUpgrade.transform.Find("SpeedLabel").GetComponent<Text>().text = "Скорость: " + tower.GetComponent<TowerData>().levels[indexTower].rateOfFire;
            towerUpgrade.transform.Find("RadiousLabel").GetComponent<Text>().text = "Радиус: " + tower.GetComponent<TowerData>().levels[indexTower].attackRadius;
            towerUpgrade.transform.Find("CostLabel").GetComponent<Text>().text = "Цена: " + tower.GetComponent<TowerData>().levels[indexTower].cost;
        }
    }

    public void FillingTowerDelete()
    {
        towerDelete.transform.Find("TowerImg").GetComponent<Image>().sprite = tower.GetComponent<TowerData>().CurrentLevel.img;
        towerDelete.transform.Find("TowerNameLabel").GetComponent<Text>().text = tower.GetComponent<TowerData>().Name;
        towerDelete.transform.Find("CostLabel").GetComponent<Text>().text = "Цена продажи: " + tower.GetComponent<TowerData>().CurrentLevel.refundAmount;
    }
}
