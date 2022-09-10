using System.Collections;
using System.Collections.Generic;
using SaveTheLineage.Controllers;
using SaveTheLineage.Helpers;
using UnityEngine;

namespace SaveTheLineage.Visuals
{
    public class UnitSelectionVisual : MonoBehaviour
    {
        [SerializeField] private UnitController unit;

        private MeshRenderer meshRenderer;

        private Vector3 notSelectedSize = new Vector3(.1f,.1f,.1f);
        private Vector3 selectedSize = new Vector3(1.4f, 1.4f, 1.4f);
        private float selectionAnimDuration = .14f;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }
        private void Start()
        {
            UnitSelectionController.Instance.OnSelectedUnitChanged += UnitSelectionController_OnSelectedUnitChanged;
            UpdateVisualRenderer();
        }
        private void Update()
        {
            RotateSelectionVisual();
        }
        private void UnitSelectionController_OnSelectedUnitChanged(object sender, System.EventArgs empty)
        {
            UpdateVisualRenderer();
        }

        private void UpdateVisualRenderer()
        {
            if (UnitSelectionController.Instance.GetSelectedUnit() == unit)
            {
                meshRenderer.enabled = true;

                this.AnimateComponent<Transform>(selectionAnimDuration, (t, time) =>
                {
                    t.localScale = Vector3.Lerp(notSelectedSize, selectedSize, time);
                });

            }
            else meshRenderer.enabled = false;
        }

        private void RotateSelectionVisual()
        {
            if (meshRenderer.enabled) transform.Rotate(0, 4f * Time.deltaTime, 0, Space.World);
        }
    }

}

