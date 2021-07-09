using UnityEngine;

namespace Platformer
{
    public class Lessons : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SpriteRenderer _back;
        [SerializeField] private CharacterView _characterView;
        //[SerializeField]
        //private SomeView _someView;
        //add links to test views <1>

        //private SomeManager _someManager;
        //add links to some logic managers <2>
        private ParalaxManager _paralaxManager;
        private SpriteAnimator _spriteAnimator;

        private void Start()
        {
            _paralaxManager = new ParalaxManager(_camera.transform, _back.transform);

            SpriteAnimationsConfig config = Resources.Load<SpriteAnimationsConfig>("SpriteAnimationsConfig");

            _spriteAnimator = new SpriteAnimator(config);

            _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.sonic_walk, true, 10);

        }

        private void Update()
        {
            //_someManager.Update();
            //update logic managers here <5>
            _paralaxManager.Update();
            _spriteAnimator.Update();
        }

        private void FixedUpdate()
        {
            //_someManager.FixedUpdate();
            //update logic managers here <6>
        }

        private void OnDestroy()
        {
            //_someManager.Dispose();
            //dispose logic managers here <7>
        }
    }
}
