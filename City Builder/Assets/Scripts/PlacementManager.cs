using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    [SerializeField] GameObject buildingPrefab = null;
    [SerializeField] Transform ground = null;

    public void CreateBuilding(Vector3 gridPosition)
    {
        Instantiate(buildingPrefab, ground.position + gridPosition, Quaternion.identity);
    }

}
