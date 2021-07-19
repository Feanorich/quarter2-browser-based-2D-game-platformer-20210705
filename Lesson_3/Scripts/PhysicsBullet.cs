﻿using UnityEngine;

namespace Platformer
{
    public class PhysicsBullet
    {
        private BallView _view;

        public PhysicsBullet(BallView view)
        {
            _view = view;
            _view.SetVisible(false);
        }

        public void Throw(Vector3 position, Vector3 velocity)
        {
            _view.SetVisible(false);
            _view.Transform.position = position;
            _view.Rigidbody2D.velocity = Vector2.zero;
            _view.Rigidbody2D.angularVelocity = 0;
            _view.Rigidbody2D.AddForce(velocity, ForceMode2D.Impulse);
            _view.SetVisible(true);
        }
    }

}
