using UnityEngine;

namespace Platformer
{
    public class BallView : LevelObjectView
    {
        [SerializeField] private TrailRenderer _trail;

        public void SetVisible(bool visible)
        {
            if (_trail) _trail.enabled = visible;
            if (_trail) _trail.Clear();
            SpriteRenderer.enabled = visible;
        }
    }

}
