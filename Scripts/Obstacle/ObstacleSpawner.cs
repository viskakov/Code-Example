using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GreenProject.Obstacle
{
   public class ObstacleSpawner : MonoBehaviour
   {
      [SerializeField] private GameObject[] _prefabArray;
      [SerializeField] private Transform[] _spawnPoints;
      [SerializeField] private float _timeBeforeFirstSpawn;
      [SerializeField] private float _timeBetweenSpawn;

      private WaitForSeconds _firstWait;
      private WaitForSeconds _waitBetweenSpawn;

      private void Awake()
      {
         _firstWait = new WaitForSeconds(_timeBeforeFirstSpawn);
         _waitBetweenSpawn = new WaitForSeconds(_timeBetweenSpawn);
      }

      private void Start()
      {
         StartCoroutine(Spawn());
      }

      private IEnumerator Spawn()
      {
         yield return _firstWait;
         while (true)
         {
            var randomIndex = Random.Range(0, _prefabArray.Length);
            var randomSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            Instantiate(_prefabArray[randomIndex], randomSpawnPoint.position, Quaternion.identity);
            yield return _waitBetweenSpawn;
         }
      }
   }
}