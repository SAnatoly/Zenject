using GameInput;
using ShootEmUp;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


    public sealed class LevelInstaller: MonoInstaller
    {
        [Header("Timer")]
        public CountdownTimer countdownTimer;
      
        [Space, Header("Level")]
        public LevelBackground levelBackground;
        public LevelBounds LevelBounds;

        [Space]
        [Header("Character objects")]
        public Transform worldTransform;
        public Transform container;
        public WeaponComponent weaponComponent;
        public MoveComponent character;
        public CharacterDeathObserver characterDeathObserver;

        [Space, Header("Enemy objects")]
        public EnemyCountdownSpawner enemyCountdownSpawner;
        public Transform enemyContainer;
        public GameObject enemyPrefab;
        public EnemyPositions enemyPositions;
        public Transform enemyWorldTransform;
        
        [Space, Header("Bullet")]
        public BulletConfig bulletConfig;
        public Bullet bullet;
        
        [Space, Header("UI")]
        public Button startButton;
        public Button resumeButton;
        public Button pauseButton; 
        public TMP_Text text;
        
        public override void InstallBindings()
        {
            BulletBind();
            CharacterBind();
            EnemyBind();
            UiBind();
            TimerBind();
            GameBind();
            
            Container.BindInterfacesAndSelfTo<KeyboardInput>().AsSingle().NonLazy();
            Container.Bind<GameCooldownLauncher>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LevelBackground>().FromInstance(levelBackground).AsSingle().NonLazy();
        }

        private void CharacterBind()
        {
            Container.BindInterfacesAndSelfTo<CharacterAttackController>().AsSingle().NonLazy();
            Container.Bind<MoveComponent>().FromInstance(character).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CharacterMoveAgent>().AsCached().NonLazy();
            Container.Bind<CharacterAttackAgent>().AsSingle().WithArguments(bulletConfig).NonLazy();
            Container.BindInterfacesAndSelfTo<CharacterMoveController>().AsSingle().NonLazy();
            Container.Bind<CharacterDeathObserver>().FromInstance(characterDeathObserver).AsSingle().NonLazy();
        }

        private void BulletBind()
        {
            Container.BindInterfacesAndSelfTo<Bullet>().FromInstance(bullet).AsCached().NonLazy();
            Container.BindInterfacesAndSelfTo<BulletSystem>().AsSingle().NonLazy();
            Container.Bind<BulletPool>().AsSingle().WithArguments(container, LevelBounds).NonLazy();
            Container.Bind<BulletSpawner>().AsSingle().WithArguments(worldTransform).NonLazy();
            Container.Bind<WeaponComponent>().FromInstance(weaponComponent).AsSingle().NonLazy();
        }
        
        private void EnemyBind()
        {
            Container.Bind<EnemyManager>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<EnemyCountdownSpawner>().FromInstance(enemyCountdownSpawner).AsSingle().NonLazy();
            Container.Bind<EnemyPool>().AsSingle().WithArguments(enemyContainer, enemyPrefab).NonLazy();
            Container.Bind<EnemySpawner>().AsSingle().WithArguments(character.gameObject, enemyPositions, enemyWorldTransform).NonLazy();
            Container.BindInterfacesAndSelfTo<EnemyMoveController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<EnemyAtackController>().AsSingle().NonLazy();
        }

        private void UiBind()
        {
            Container.Bind<StartButtonListener>().AsSingle().WithArguments(startButton).NonLazy();
            Container.Bind<PauseButtonListener>().AsSingle().WithArguments(pauseButton).NonLazy();
            Container.Bind<ResumButtonListener>().AsSingle().WithArguments(resumeButton).NonLazy();
        }

        private void TimerBind()
        {
            Container.BindInterfacesAndSelfTo<CountdownTimer>().FromInstance(countdownTimer).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<VisualisateCountdownTimer>().AsSingle().WithArguments(text).NonLazy();
        }

        private void GameBind()
        {
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().NonLazy();
            Container.Bind<GameManagerInstaller>().AsSingle().NonLazy();
        }
}
