using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class GameManagerInstaller
    {
        private GameManagerInstaller(IGameListener[] _gameListeners, GameManager _manager)
        {
           _manager.AddListeners(_gameListeners);
        }
    }
}

