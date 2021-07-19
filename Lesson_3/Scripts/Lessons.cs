using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class Lessons : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SpriteRenderer _back;
        [SerializeField] private LevelObjectView _characterView;
        [SerializeField] private CannonView _cannonView;
        [SerializeField] private List<BallView> _bulletViews;

        [SerializeField] private List<LevelObjectView> _coinViews;

        [SerializeField] private List<LevelObjectView> _deathZones;
        [SerializeField] private List<LevelObjectView> _winZones;
        //[SerializeField]
        //private SomeView _someView;
        //add links to test views <1>

        //private SomeManager _someManager;
        //add links to some logic managers <2>
        private ParalaxManager _paralaxManager;
        private SpriteAnimator _spriteAnimator;
        private MainHeroPhysicsWalker _mainHeroPhysicsWalker;
        private AimingMuzzle _aimingMuzzle;
        private BulletsEmitter _bulletsEmitter;

        private CoinsManager _coinsManager;
        private LevelCompleteManager _levelCompleteManager;

        private void Start()
        {
            _paralaxManager = new ParalaxManager(_camera.transform, _back.transform);

            SpriteAnimationsConfig config = Resources.Load<SpriteAnimationsConfig>("SpriteAnimationsConfig");

            _spriteAnimator = new SpriteAnimator(config);

            _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.sonic_walk, true, 10);

            _mainHeroPhysicsWalker = new MainHeroPhysicsWalker(_characterView, _spriteAnimator);

            _aimingMuzzle = new AimingMuzzle(_cannonView.MuzzleTransform, _characterView.Transform);

            _bulletsEmitter = new BulletsEmitter(_bulletViews, _cannonView.EmitterTransform);

            _coinsManager = new CoinsManager(_characterView, _coinViews, _spriteAnimator);

            _levelCompleteManager = new LevelCompleteManager(_characterView, _deathZones, _winZones);
        }

        private void Update()
        {
            //_someManager.Update();
            //update logic managers here <5>
            _paralaxManager.Update();
            _spriteAnimator.Update();
            
            _aimingMuzzle.Update();
            _bulletsEmitter.Update();
        }

        private void FixedUpdate()
        {
            //_someManager.FixedUpdate();
            //update logic managers here <6>
            _mainHeroPhysicsWalker.FixedUpdate();
        }

        private void OnDestroy()
        {
            //_someManager.Dispose();
            //dispose logic managers here <7>
        }
    }
}
