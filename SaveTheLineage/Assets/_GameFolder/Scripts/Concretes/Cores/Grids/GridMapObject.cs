using System.Collections;
using System.Collections.Generic;
using SaveTheLineage.Units.Cores;
using UnityEngine;
namespace SaveTheLineage.Cores.Grids
{
    public class GridMapObject
    {
        private GridMap _gridMap;
        private GridMapPosition _gridMapPosition;
        private List<UnitController> _units;

        public GridMapObject(GridMap gridMap, GridMapPosition gridMapPosition)
        {
            _gridMap = gridMap;
            _gridMapPosition = gridMapPosition;
            _units = new List<UnitController>();

        }

        public override string ToString()
        {
            string unitNames = "";
            foreach (UnitController unit in _units)
            {
                unitNames += unit.gameObject.name + "\n";
            }
            return _gridMapPosition.ToString()+"\n"+ unitNames;
        }

        public void AddUnit(UnitController unit)
        {
            _units.Add(unit);
        }

        public void RemoveUnit(UnitController unit)
        {
            _units.Remove(unit);
        }

        public List<UnitController> GetUnits()
        {
            return _units;
        }

    }

}
