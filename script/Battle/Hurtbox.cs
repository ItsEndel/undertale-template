using Godot;



/// <summary>
/// 受击碰撞箱
/// </summary>
[GlobalClass, Icon("res://icon/Hurtbox.svg")]
public partial class Hurtbox : Area2D {
    // 节点信号 //
    [Signal]
    public delegate void HurtEventHandler(Hitbox hitbox);
}
