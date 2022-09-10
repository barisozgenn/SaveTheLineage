using System.Collections;
using System.Collections.Generic;
using SaveTheLineage.Grids;
using UnityEngine;

namespace SaveTheLineage.Controllers
{
    public class UnitController : MonoBehaviour
    {
        [SerializeField] private Animator unitAnimator;
        [SerializeField] private float moveSpeed = 7f;
        [SerializeField] private float rorationSpeed = 29f;

        private Vector3 _targetPosition;
        private GridMapPosition gridMapPosition;

        private float stoppingDistance = .1f;

        private void Awake()
        {
            _targetPosition = transform.position;
        }
        private void Start()
        {
            gridMapPosition = GridLevel.Instance.GetGridMapPosition(worldPosition: transform.position);

            GridLevel.Instance.AddUnitAtGridPosition(gridMapPosition: gridMapPosition , unit: this);
        }
        private void Update()
        {
          

            if (Vector3.Distance(transform.position, _targetPosition) > stoppingDistance)
            {
                Vector3 moveDirection = (_targetPosition - transform.position).normalized;

                transform.forward = Vector3.Lerp(transform.forward, moveDirection, rorationSpeed * Time.deltaTime);//for character rotation automatically according to forward rotation values

                transform.position += moveDirection * moveSpeed * Time.deltaTime;

                unitAnimator.SetBool("IsWalking", true);
            }
            else
            {
                unitAnimator.SetBool("IsWalking", false);
            }

           GridMapPosition newGridMapPosition = GridLevel.Instance.GetGridMapPosition(worldPosition: transform.position);
            if (newGridMapPosition!=gridMapPosition)
            {
                //Unit moved another grid map position

                GridLevel.Instance.UnitMovedGridMapPosition(unit: this, fromGridMapPosition: gridMapPosition, toGridMapPosition: newGridMapPosition);
                gridMapPosition = newGridMapPosition;
            }

        }
        public void Move(Vector3 targetPosition)
        {
            _targetPosition = targetPosition;
        }
    }

}
