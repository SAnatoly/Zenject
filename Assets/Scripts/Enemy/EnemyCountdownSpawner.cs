using System.Collections;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class EnemyCountdownSpawner : MonoBehaviour, 
        IGameStartListener, 
        IGamePauseListener, 
        IGamePlayingListener, 
        IGameFinishListener
    {
        [SerializeField] private int waitingSeconds;
        [Inject] private EnemyManager enemyManager;
 
        public void OnFinish()
        {
            StopSpawning();
        }

        public void OnPause()
        {
            StopSpawning();
        }

        public void OnPlaying()
        {
            StartSpawning();
        }

        public void OnStart()
        {
            //StartSpawning();
        }

        private void StartSpawning()
        {
            StartCoroutine(nameof(Spawn));
        }

        private void StopSpawning()
        {
            StopCoroutine(nameof(Spawn));
        }
        
        private IEnumerator Spawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(waitingSeconds);
                enemyManager.SpawnEnemy();
            }
        }
    }
}

