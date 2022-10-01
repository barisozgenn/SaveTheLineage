using System.Collections;
using System.Collections.Generic;
using SaveTheLineage.Cores.Grids;
using SaveTheLineage.Units.Cores;
using UnityEngine;
namespace SaveTheLineage.Units.Movements
{
    public class UnitMoveAction : MonoBehaviour
    {
        [SerializeField] private Animator unitAnimator;

        [SerializeField] private float moveSpeed = 7f;
        [SerializeField] private float rorationSpeed = 29f;

        [SerializeField] private int maxMoveGridDistance = 4;

        private Vector3 _targetPosition;
        private float stoppingDistance = .1f;

        private UnitController unit;

        private void Awake()
        {
           unit= GetComponent<UnitController>();
            _targetPosition = transform.position;
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

        }
        public void Move(Vector3 targetPosition)
        {
            _targetPosition = targetPosition;
        }

        public List<GridMapPosition> GetValidActionGridMapPositions()
        {
            List<GridMapPosition> gridMapPositions = new List<GridMapPosition>();
            GridMapPosition unitGridMapPosition = unit.GetGripMapPosition();

            for (int x = -maxMoveGridDistance; x <= maxMoveGridDistance; x++)
            {
                for (int z = -maxMoveGridDistance; z <= maxMoveGridDistance; z++)
                {
                    GridMapPosition offsetGridMapPosition = new GridMapPosition(x: x, z: z);
                    GridMapPosition testGridMapPosition = unitGridMapPosition + offsetGridMapPosition;

                    Debug.Log(testGridMapPosition);
                }
            }
            return gridMapPositions;
        }
    }

}
