using UnityEngine;
using System.Collections.Generic;


namespace ShootEmUp
{
    public sealed class EnemyMoveController: IGameFixedUpdateListener
    {
        private List<EnemyMoveAgent> enemyMoveAgent;

        public EnemyMoveController()
        {
            enemyMoveAgent = new List<EnemyMoveAgent>();
        }

        public void AddAgents(EnemyMoveAgent _enemyMoveAgent)
        {
            enemyMoveAgent.Add(_enemyMoveAgent);
        }

        public void RemoveAgents(EnemyMoveAgent _enemyMoveAgent)
        {
            enemyMoveAgent.Remove(_enemyMoveAgent);
        }
        
        public void OnFixedUpdate(float _deltaTime)
        {
            if (enemyMoveAgent.Count != 0)
            {
                for (int i = 0; i < enemyMoveAgent.Count; i++)
                {
                    enemyMoveAgent[i].Move();
                }
            }
        }
    }
}