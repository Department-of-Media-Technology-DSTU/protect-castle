using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    private PlaceTower placeTower;
    private BuildingTower buildingTower;
    private TowerUpgrade towerUpgrade;
    private TowerRemoval towerRemoval;

    public GameObject gameMode;

    public GameObject towerName;
    public GameObject towerDescription;

    private void showTowerSelection()
    {
        if (placeTower.Tower == null)
        {
            placeTower.transform.Find("tower selection").gameObject.SetActive(true);
        }
        else
        {
            placeTower.transform.Find("tower work").gameObject.SetActive(true);
        }
    }

    private void hideTowerSelection()
    {
        if (placeTower.Tower == null)
        {
            placeTower.transform.Find("tower selection").gameObject.SetActive(false);
        }
        else
        {
            placeTower.transform.Find("tower work").gameObject.SetActive(false);
        }
    }

    public void ExitBuild()
    {
        buildingTower = null;
        showTowerSelection();
    }

    public void ExitUpgrade()
    {
        towerUpgrade = null;
        showTowerSelection();
        if (placeTower.Tower)
        {
            towerName.SetActive(false);
            towerDescription.SetActive(false);
        }
    }

    public void ExitDelete()
    {
        towerRemoval = null;
        showTowerSelection();
    }

    public void Build()
    {
        hideTowerSelection();
        buildingTower.Click();
        buildingTower = null;
        placeTower = null;
    }

    public void Ubgrade()
    {
        hideTowerSelection();
        towerUpgrade.Click();

        if (placeTower.Tower)
        {
            towerName.SetActive(false);
            towerDescription.SetActive(false);
        }

        buildingTower = null;
        placeTower = null;
    }

    public void Delete()
    {
        hideTowerSelection();
        towerRemoval.Click();
        towerRemoval = null;
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlaceTower temporaryPlaceTower = hit.collider.gameObject.GetComponent<PlaceTower>();
                if (placeTower == null && temporaryPlaceTower)
                {
                    placeTower = temporaryPlaceTower;
                    if (placeTower.Tower)
                    {
                        placeTower.Filling();
                        towerName.SetActive(true);
                        towerDescription.SetActive(true);
                    }
                    showTowerSelection();
                }
                else if (temporaryPlaceTower)
                {
                    if ((placeTower.Tower == null && gameMode.transform.Find("TowerBuild").gameObject.activeSelf == false) || (placeTower.Tower && gameMode.transform.Find("TowerUpgrade").gameObject.activeSelf == false && gameMode.transform.Find("TowerDelete").gameObject.activeSelf == false))
                    {
                        hideTowerSelection();
                        placeTower = temporaryPlaceTower;
                        showTowerSelection();
                    }
                    if (placeTower.Tower)
                    {
                        placeTower.Filling();
                        towerName.SetActive(true);
                        towerDescription.SetActive(true);
                    }
                    else
                    {
                        towerName.SetActive(false);
                        towerDescription.SetActive(false);
                    }
                }

                BuildingTower temporarybuildingTower = hit.collider.gameObject.GetComponent<BuildingTower>();
                if (temporarybuildingTower)
                {
                    buildingTower = temporarybuildingTower;
                    if (placeTower.Tower)
                    {
                        gameMode.transform.Find("TowerUpgrade").gameObject.SetActive(true);
                    }
                    else
                    {
                        gameMode.transform.Find("TowerBuild").gameObject.SetActive(true);
                    }
                    hideTowerSelection();
                    placeTower.FillingTowerBuild(buildingTower);
                }

                TowerUpgrade temporaryTowerUpgrade = hit.collider.gameObject.GetComponent<TowerUpgrade>();
                if (temporaryTowerUpgrade)
                {
                    towerUpgrade = temporaryTowerUpgrade;
                    if (placeTower.Tower)
                    {
                        gameMode.transform.Find("TowerUpgrade").gameObject.SetActive(true);
                    }
                    else
                    {
                        gameMode.transform.Find("TowerBuild").gameObject.SetActive(true);
                    }
                    hideTowerSelection();

                    placeTower.FillingTowerUpgrade();
                }

                TowerRemoval temporarytowerRemoval = hit.collider.gameObject.GetComponent<TowerRemoval>();
                if (temporarytowerRemoval)
                {
                    towerRemoval = temporarytowerRemoval;
                    if (placeTower.Tower)
                    {
                        gameMode.transform.Find("TowerDelete").gameObject.SetActive(true);
                    }
                    placeTower.FillingTowerDelete();
                    hideTowerSelection();
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && placeTower)
            {
                if ((placeTower.Tower == null && gameMode.transform.Find("TowerBuild").gameObject.activeSelf == false) || (placeTower.Tower && gameMode.transform.Find("TowerUpgrade").gameObject.activeSelf == false && gameMode.transform.Find("TowerDelete").gameObject.activeSelf == false))
                {
                    if (placeTower)
                    {
                        hideTowerSelection();
                    }
                    if (placeTower.Tower)
                    {
                        towerName.SetActive(false);
                        towerDescription.SetActive(false);
                    }
                    placeTower = null;
                    buildingTower = null;
                }
            }
        }
    }
}
