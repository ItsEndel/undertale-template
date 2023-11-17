using Godot;



/// <summary>
/// 房间内玩家
/// </summary>
[GlobalClass, Icon("res://icon/Player.svg")]
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
        // 移动并记录相关变量
        Vector2 last_position = Position;

        Velocity = Speed * Input.GetVector("movement_left", "movement_right", "movement_up", "movement_down");
        MoveAndSlide();

        Vector2 moved = Position - last_position;

        // 如果正在移动，调整并播放动画
        if (Velocity != Vector2.Zero && moved.Abs().Length() > SafeMargin) {
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

            // 若播放的动画改变，调整动画已播放时间
            if (_animation.CurrentAnimation != next_animation) {
                double animation_position = 0.0d;
                if (_animation.IsPlaying()) {
                    animation_position = _animation.CurrentAnimationPosition;
                } else  {
                    animation_position = 0.2d;
                }

                _animation.Play(next_animation);
                _animation.Seek(animation_position);
            }
        // 如果未移动，停止播放动画
        } else if (_animation.IsPlaying()) {
            _animation.Stop();
        }
    }
}
