using GameInput;
using UnityEngine;

namespace ShootEmUp
{
    public class CharacterAttackController:  
        IGameStartListener, 
        IGameFinishListener, 
        IGamePauseListener, 
        IGamePlayingListener
    {
        private CharacterAttackAgent attackAgent;
        private KeyboardInput input;
        
        public CharacterAttackController(CharacterAttackAgent _attackAgent, KeyboardInput _input)
        {
            input = _input;
            attackAgent = _attackAgent;
        }
        
        public void OnStart()
        {
            input.fire += Attack;
        }
        
        public void OnPause()
        {
            input.fire -= Attack;
        }

        public void OnPlaying()
        {
            input.fire += Attack;
        }

        public void OnFinish()
        {
            input.fire -= Attack;
        }

        private void Attack()
        {
            attackAgent.Shoot();
        }
    }
}