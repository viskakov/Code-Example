using UnityEngine;

namespace GreenProject.CameraController
{
   public class OrthographicZooming : MonoBehaviour
   {
      [SerializeField] private float _orthoZoomSpeed;
      [SerializeField] private float _movementTime;
      [SerializeField] private float _minOrthoSize;
      [SerializeField] private float _maxOrthoSize;

      private Camera _camera;
      private float _orthoZoom;

      private void Awake()
      {
         _camera = GetComponentInChildren<Camera>();

         _camera.orthographicSize = _maxOrthoSize;
         _orthoZoom = _camera.orthographicSize;
      }

      private void Start()
      {
         CameraSetup();
      }

      private void CameraSetup()
      {
         if (_camera)
         {
            _camera.orthographic = true;
         }
      }

      private void Update()
      {
         HandleMouseInput();
      }

      private void HandleMouseInput()
      {
         var scrollData = Input.GetAxis("Mouse ScrollWheel");
         _orthoZoom -= scrollData * _orthoZoomSpeed;
         _orthoZoom = Mathf.Clamp(_orthoZoom, _minOrthoSize, _maxOrthoSize);
      }

      private void LateUpdate()
      {
         if (_camera)
         {
            var velocity = 0f;
            _camera.orthographicSize = Mathf.SmoothDamp(_camera.orthographicSize, _orthoZoom, ref velocity,
               _movementTime * Time.deltaTime);
         }
      }
   }
}