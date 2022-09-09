using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveTheLineage.Controllers
{
    public class UnitController : MonoBehaviour
    {
        private Vector3 _targetPosition;

        private float stoppingDistance = .1f;
        float moveSpeed = 4f;

        private void Update()
        {

            if (Vector3.Distance(transform.position, _targetPosition) > stoppingDistance)
            {
                Vector3 moveDirection = (_targetPosition - transform.position).normalized;

                transform.position += moveDirection * moveSpeed * Time.deltaTime;

            }


            if (Input.GetMouseButtonDown(0))
            {
                Move(targetPosition: MouseWorldController.GetPosition());
            }
        }
        private void Move(Vector3 targetPosition)
        {
            _targetPosition = targetPosition;
        }
    }

}
