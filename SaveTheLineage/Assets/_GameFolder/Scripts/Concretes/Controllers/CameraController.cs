using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace SaveTheLineage.Controllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
        private CinemachineTransposer cinemachineTransposer;
        private Vector3 cinemachineFollowOffset;

        private const float cinemachineZoomAmount = 1f;

        private float cinemachineZoomSpeed = 2f;
        private const float cinemachineZoomSpeedWithKeyCode = 4f;
        private const float cinemachineZoomSpeedWithMouseWheel = 2f;

        private const float cinemachineZoomMinY = 2f;
        private const float cinemachineZoomMaxY = 29f;


        private const float movementSpeed = 10f;
        private Vector3 inputMoveDirection;

        private const float rotationSpeed = 90f;
        private Vector3 inputRotation;

        private void Start()
        {
            cinemachineTransposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
            cinemachineFollowOffset = cinemachineTransposer.m_FollowOffset;
        }
        void Update()
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                SetCameraMovement();
            if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.E))
                SetCameraRotation();
            if (Input.GetKey(KeyCode.O) || Input.GetKey(KeyCode.I) || Input.mouseScrollDelta.y != 0)
                SetCameraZoom();
        }

        private void SetCameraMovement()
        {
            inputMoveDirection = new Vector3(0, 0, 0);
            if (Input.GetKey(KeyCode.W))
            {
                inputMoveDirection.z = 1f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                inputMoveDirection.z = -1f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                inputMoveDirection.x = -1f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                inputMoveDirection.x = 1f;
            }

            Vector3 moveRotatedDirection = transform.forward * inputMoveDirection.z + transform.right * inputMoveDirection.x;
            transform.position += moveRotatedDirection * movementSpeed * Time.deltaTime;

        }
        private void SetCameraRotation()
        {
            inputRotation = new Vector3(0, 0, 0);

            if (Input.GetKey(KeyCode.Q))
            {
                inputRotation.y = 1f;
            }
            if (Input.GetKey(KeyCode.E))
            {
                inputRotation.y = -1f;
            }

            transform.eulerAngles += inputRotation * rotationSpeed * Time.deltaTime;
        }
        private void SetCameraZoom()
        {
            if (Input.GetKey(KeyCode.I))
            {
                cinemachineZoomSpeed = cinemachineZoomSpeedWithKeyCode;
                cinemachineFollowOffset.y -= cinemachineZoomAmount;
            }
            if (Input.GetKey(KeyCode.O))
            {
                cinemachineZoomSpeed = cinemachineZoomSpeedWithKeyCode;
                cinemachineFollowOffset.y += cinemachineZoomAmount;
            }
            if (Input.mouseScrollDelta.y > 0)
            {
                cinemachineZoomSpeed = cinemachineZoomSpeedWithMouseWheel;
                cinemachineFollowOffset.y -= cinemachineZoomAmount;
            }
            if (Input.mouseScrollDelta.y < 0)
            {
                cinemachineZoomSpeed = cinemachineZoomSpeedWithMouseWheel;
                cinemachineFollowOffset.y += cinemachineZoomAmount;
            }

            cinemachineFollowOffset.y = Mathf.Clamp(value: cinemachineFollowOffset.y, min: cinemachineZoomMinY, max: cinemachineZoomMaxY);

            cinemachineTransposer.m_FollowOffset = Vector3.Lerp(cinemachineTransposer.m_FollowOffset, cinemachineFollowOffset, Time.deltaTime * cinemachineZoomSpeed);
        }
    }
}

