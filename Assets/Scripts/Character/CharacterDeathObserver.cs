using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class CharacterDeathObserver : MonoBehaviour
    {
        [SerializeField] private GameObject character;
        [Inject]private GameManager gameManager;
        
        private void OnEnable()
        {
            this.character.GetComponent<HitPointsComponent>().hpEmpty += CharacterDeath;
        }

        private void OnDisable()
        {
            this.character.GetComponent<HitPointsComponent>().hpEmpty -= CharacterDeath;
        }

        public void CharacterDeath(GameObject _)
        {
            gameManager.FinishGame();
        }
    }
}

