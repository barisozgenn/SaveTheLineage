using System.Collections;
using System.Collections.Generic;
using SaveTheLineage.Cores.Grids;
using SaveTheLineage.Units.Movements;
using UnityEngine;

namespace SaveTheLineage.Units.Cores
{
    public class UnitController : MonoBehaviour
    {

        private GridMapPosition gridMapPosition;
        private UnitMoveAction unitMoveAction;

        private void Awake()
        {
            unitMoveAction = GetComponent<UnitMoveAction>();
        }
        private void Start()
        {
            gridMapPosition = GridLevel.Instance.GetGridMapPosition(worldPosition: transform.position);

            GridLevel.Instance.AddUnitAtGridPosition(gridMapPosition: gridMapPosition, unit: this);
        }
        private void Update()
        {

            GridMapPosition newGridMapPosition = GridLevel.Instance.GetGridMapPosition(worldPosition: transform.position);
            if (newGridMapPosition != gridMapPosition)
            {
                GridLevel.Instance.UnitMovedGridMapPosition(unit: this, fromGridMapPosition: gridMapPosition, toGridMapPosition: newGridMapPosition);
                gridMapPosition = newGridMapPosition;
            }

        }

        public UnitMoveAction GetUnitMoveAction()
        {
            return unitMoveAction;
        }

        public GridMapPosition GetGripMapPosition()
        {
            return gridMapPosition;
        }

    }

}
