using GameInput;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterMoveController:  IGameStartListener,
        IGameFinishListener, 
        IGamePauseListener, 
        IGamePlayingListener
    {
        private CharacterMoveAgent moveAgent;
        private KeyboardInput input;
        
        public  CharacterMoveController(CharacterMoveAgent _moveAgent, KeyboardInput _input)
        {
            this.moveAgent = _moveAgent;
            this.input = _input;
            OnStart();
        }

        public void OnPause()
        {
            input.move -= Move;
        }

        public void OnPlaying()
        {
            input.move += Move;
        }
        
        public void OnFinish()
        {
            input.move -= Move;
        }

        private void Move(Vector2 _diraction)
        {
            moveAgent.horizontalDirection = _diraction.x;
        }

        public void OnStart()
        {
            input.move += Move;
        }
    }
    
}