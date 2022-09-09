using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveTheLineage.Controllers
{
    public class MouseWorldController : MonoBehaviour
    {
        [SerializeField] private LayerMask mousePlaneLayerMask;

        private static MouseWorldController instance;

        Ray ray;
        float mouseRayCastMaxValue = float.MaxValue;

        private void Awake()
        {
            instance = this;
        }

        public static Vector3 GetPosition()
        {
            instance.ray = Camera.main.ScreenPointToRay(pos: Input.mousePosition);
            Physics.Raycast(ray: instance.ray, hitInfo: out RaycastHit raycastHit, maxDistance: instance.mouseRayCastMaxValue, layerMask: instance.mousePlaneLayerMask);
            return raycastHit.point;
        }
    }
}

