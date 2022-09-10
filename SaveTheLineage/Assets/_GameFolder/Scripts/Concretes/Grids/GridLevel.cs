using System.Collections;
using System.Collections.Generic;
using SaveTheLineage.Controllers;
using UnityEngine;
namespace SaveTheLineage.Grids
{
    public class GridLevel : MonoBehaviour
    {
        public static GridLevel Instance { get; private set; }

        [SerializeField] private Transform gridDebugPrefab;
        private GridMap gridMap;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("GridLevel Instance duplicated! => " + transform);
                Destroy(gameObject);
                return;
            }
            Instance = this;

            gridMap = new GridMap(10, 10, 2f);
            gridMap.CreateDebugObjects(debugPrefab: gridDebugPrefab);
        }

        public void AddUnitAtGridPosition(GridMapPosition gridMapPosition, UnitController unit)
        {
            GridMapObject gridMapObject = gridMap.GetGridMapObject(gridMapPosition: gridMapPosition);
            gridMapObject.AddUnit(unit: unit);
        }

        public List<UnitController> GetUnitsAtGridPosition(GridMapPosition gridMapPosition)
        {
            GridMapObject gridMapObject = gridMap.GetGridMapObject(gridMapPosition: gridMapPosition);
            return gridMapObject.GetUnits();
        }

        public void RemoveUnitAtGridPosition(GridMapPosition gridMapPosition, UnitController unit)
        {
            GridMapObject gridMapObject = gridMap.GetGridMapObject(gridMapPosition: gridMapPosition);
            gridMapObject.RemoveUnit(unit: unit);
        }

        public void UnitMovedGridMapPosition(UnitController unit, GridMapPosition fromGridMapPosition, GridMapPosition toGridMapPosition)
        {
            RemoveUnitAtGridPosition(gridMapPosition: fromGridMapPosition, unit: unit);
            AddUnitAtGridPosition(gridMapPosition: toGridMapPosition, unit: unit);
        }

        public GridMapPosition GetGridMapPosition(Vector3 worldPosition) => gridMap.GetGridMapPosition(worldPosition: worldPosition);
    }

}
