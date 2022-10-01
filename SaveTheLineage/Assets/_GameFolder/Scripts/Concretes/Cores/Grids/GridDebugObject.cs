using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace SaveTheLineage.Cores.Grids
{
    public class GridDebugObject : MonoBehaviour
    {
        [SerializeField] private TextMeshPro textGridCoordinate;
        private GridMapObject _gridMapObject;

        public void SetGridDebugObject(GridMapObject gridMapObject)
        {
            _gridMapObject = gridMapObject;
        }

        private void Update()
        {
            textGridCoordinate.text = _gridMapObject.ToString();
        }
    }

}
