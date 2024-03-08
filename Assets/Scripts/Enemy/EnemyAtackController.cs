using System;
using System.Collections.Generic;

namespace ShootEmUp
{
    public class EnemyAtackController: IGameFixedUpdateListener
    {
        private List<EnemyAttackAgent> attackAgents;

        public EnemyAtackController()
        {
            attackAgents = new();
        }

        public void AddAgents(EnemyAttackAgent _enemyAttackAgent)
        {
            attackAgents.Add(_enemyAttackAgent);
        }

        public void RemoveAgents(EnemyAttackAgent _enemyAttackAgent)
        {
            attackAgents.Remove(_enemyAttackAgent);
        }
        
        public void OnFixedUpdate(float _deltaTime)
        {
            for (int i = 0; i < attackAgents.Count; i++)
            {
                attackAgents[i].CanFire();
            }
        }
    }
}