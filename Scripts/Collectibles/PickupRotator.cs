using UnityEngine;

namespace GreenProject.Collectibles
{
   public class PickupRotator : MonoBehaviour
   {
      [SerializeField] private bool _isBounce = true;
      [SerializeField] private bool _isRotate = true;

      [Header("Rotate settings")]
      [SerializeField] private Vector3 _axisRotate;
      [SerializeField] private float _degreeRotate;

      [Header("Bounce settings")]
      [SerializeField] private float _ampl;
      [SerializeField] private float _freq;

      private Transform _transform;

      private void Awake()
      {
         _transform = transform;
      }

      private void Update()
      {
         if (_isBounce)
         {
            _transform.Translate(new Vector3(0f, Mathf.Sin(Time.time * _freq) * _ampl * Time.unscaledDeltaTime, 0f),
               Space.Self);
         }

         if (_isRotate)
         {
            _transform.Rotate(_degreeRotate * Time.unscaledDeltaTime * _axisRotate, Space.Self);
         }
      }
   }
}