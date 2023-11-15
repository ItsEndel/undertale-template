using Godot;



/// <summary>
/// 房间内玩家
/// </summary>
[GlobalClass]
public partial class Player : CharacterBody2D
{
    // 节点变量 //
    /// <summary>
    /// 动画播放器节点
    /// </summary>
    [Export]
    private AnimationPlayer _animation;

    /// <summary>
    /// 移动速度
    /// </summary>
    [Export]
	public float Speed = 150.0f;



    // 节点方法 //
    public override void _PhysicsProcess(double delta)
    {
        Vector2 last_velocity = Velocity;
        Velocity = Speed * Input.GetVector("movement_left", "movement_right", "movement_up", "movement_down");

        if (Velocity != Vector2.Zero) {
            string next_animation = _animation.CurrentAnimation;
            if (Velocity.X > 0) {
                next_animation = "right";
            }
            if (Velocity.X < 0) {
                next_animation = "left";
            }
            if (Velocity.Y > 0) {
                next_animation = "down";
            }
            if (Velocity.Y < 0) {
                next_animation = "up";
            }

            if (_animation.CurrentAnimation != next_animation) {
                double animation_position = 0.0d;
                if (last_velocity == Vector2.Zero) {
                    animation_position = 0.2d;
                }
                if (_animation.IsPlaying()) {
                    animation_position = _animation.CurrentAnimationPosition;
                }

                _animation.Play(next_animation);
                _animation.Seek(animation_position);
            }
        } else if (_animation.IsPlaying()) {
            _animation.Stop();
        }

        MoveAndSlide();
    }
}
