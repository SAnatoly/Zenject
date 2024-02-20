using System;
using ShootEmUp;
using UnityEngine;
using Zenject;

namespace GameInput
{
    public sealed class KeyboardInput:  IGameUpdateListener
    {
        public event Action fire;
        public event Action<Vector2> move;
        private Vector2 diraction;


        private Vector2 GetDiraction()
        {

            if (Input.GetKeyDown(KeyCode.LeftArrow))       
                diraction = Vector2.left;
            
            
            if (Input.GetKeyUp(KeyCode.LeftArrow) && diraction == Vector2.left)       
                diraction = Vector2.zero;

            if(Input.GetKeyDown(KeyCode.RightArrow))
                diraction = Vector2.right;
            
            if(Input.GetKeyUp(KeyCode.RightArrow) && diraction == Vector2.right)
                diraction = Vector2.zero;

           
            return diraction;
        }


        public void OnUpdate(float _deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
              
                fire?.Invoke();
                
            }
            
            move?.Invoke(GetDiraction());
        }
    }
}