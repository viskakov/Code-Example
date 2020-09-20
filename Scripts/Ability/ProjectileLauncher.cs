using UnityEngine;
using UnityEngine.UI;

namespace GreenProject.Ability
{
   public class ProjectileLauncher : MonoBehaviour
   {
      [SerializeField] private Rigidbody _projectilePrefab;
      [SerializeField] private Button _fireButton;

      private void OnEnable()
      {
         if (_fireButton)
         {
            _fireButton.onClick.AddListener(FireAction);
         }
      }

      private void OnDisable()
      {
         if (_fireButton)
         {
            _fireButton.onClick.RemoveListener(FireAction);
         }
      }

      private void FireAction()
      {
         Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
      }
   }
}