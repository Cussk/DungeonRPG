using Godot;
using System;

public partial class Player : CharacterBody3D
{
    Vector2 _playerDirection;
    float _playerSpeed = 5;
    
    public override void _PhysicsProcess(double delta)
    {
        Velocity = new Vector3(_playerDirection.X, 0 , _playerDirection.Y);
        Velocity *= _playerSpeed;

        MoveAndSlide();
    }

    public override void _Input(InputEvent @event)
    {
        _playerDirection = Input.GetVector("MoveLeft", "MoveRight", "MoveBackward", "MoveForward");
    }
}
