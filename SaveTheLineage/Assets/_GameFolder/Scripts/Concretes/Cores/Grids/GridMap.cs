using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveTheLineage.Cores.Grids
{
    public class GridMap : MonoBehaviour
    {
        private int _width;
        private int _height;
        private float _cellSize;

        private Color gridColor = Color.white;
        //private float gridVisibleDuration = 100;

        private GridMapObject[,] gridMapObjects;

        public GridMap(int width, int height, float cellSize)
        {
            _height = height;
            _width = width;
            _cellSize = cellSize;

            gridMapObjects = new GridMapObject[_width, _height];
            for (int x = 0; x < _width; x++)
            {
                for (int z = 0; z < _height; z++)
                {
                    //Debug.DrawLine(GetWorldPosition(x,z), GetWorldPosition(x, z)+ Vector3.right *.2f, gridColor, gridVisibleDuration);

                    GridMapPosition gridMapPosition = new GridMapPosition(x, z);
                    gridMapObjects[x, z] = new GridMapObject(gridMap: this, gridMapPosition: gridMapPosition);
                }
            }
        }

        private Vector3 GetWorldPosition(GridMapPosition gridMapPosition)
        {
            return new Vector3(gridMapPosition._x, 0, gridMapPosition._z) * _cellSize;
        }
        public GridMapPosition GetGridMapPosition(Vector3 worldPosition)
        {
            return new GridMapPosition(
                x: Mathf.RoundToInt(worldPosition.x / _cellSize),
                z: Mathf.RoundToInt(worldPosition.z / _cellSize));
        }
        public void CreateDebugObjects(Transform debugPrefab)
        {
            for (int x = 0; x < _width; x++)
            {
                for (int z = 0; z < _height; z++)
                {
                    GridMapPosition gridMapPosition = new GridMapPosition(x, z);

                    Transform debugTransform = GameObject.Instantiate(original: debugPrefab, position: GetWorldPosition(gridMapPosition: gridMapPosition), rotation: Quaternion.identity/*no rotation*/);
                    GridDebugObject gridDebugObject = debugTransform.GetComponent<GridDebugObject>();
                    gridDebugObject.SetGridDebugObject(gridMapObject: GetGridMapObject(gridMapPosition: gridMapPosition));
                }
            }
        }
        public GridMapObject GetGridMapObject(GridMapPosition gridMapPosition)
        {
            return gridMapObjects[gridMapPosition._x, gridMapPosition._z];
        }
    }

}

