using System.Collections;
using System.Collections.Generic;
using SaveTheLineage.Cores.Inputs;
using SaveTheLineage.Units.Cores;
using UnityEngine;
namespace SaveTheLineage.Units.Selections
{
    public class UnitSelectionController : MonoBehaviour
    {
        public static UnitSelectionController Instance { get; private set; }

        public event System.EventHandler OnSelectedUnitChanged;
         
        [SerializeField]private UnitController selectedUnit;

        [SerializeField] private LayerMask mousePlaneLayerMask;


        Ray ray;
        float mouseRayCastMaxValue = float.MaxValue;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("UnitSelectionController Instance duplicated! => "+transform);
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (TryHandleUnitSelection()) return;

                selectedUnit.GetUnitMoveAction().Move(targetPosition: MouseWorldController.GetPosition());
            }
        }

        private bool TryHandleUnitSelection()
        {
            Instance.ray = Camera.main.ScreenPointToRay(pos: Input.mousePosition);

            if(Physics.Raycast(ray: Instance.ray, hitInfo: out RaycastHit raycastHit, maxDistance: Instance.mouseRayCastMaxValue, layerMask: Instance.mousePlaneLayerMask))
            {
                if(raycastHit.transform.TryGetComponent<UnitController>(out UnitController unit))
                {
                    SetSelectedUnit(unit: unit);
                    return true;
                }
            }
            return false;
        }

        private void SetSelectedUnit(UnitController unit)
        {
            selectedUnit = unit;
            OnSelectedUnitChanged?.Invoke(this, System.EventArgs.Empty);
        }

        public UnitController GetSelectedUnit()
        {
            return selectedUnit;
        }
    }

}
