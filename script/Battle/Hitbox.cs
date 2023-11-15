using System;
using Godot;



/// <summary>
/// 攻击碰撞箱
/// </summary>
[GlobalClass, Icon("res://icon/Hitbox.svg")]
public partial class Hitbox : Area2D {
    // 构造器 //
    public Hitbox() {
        AreaEntered += OnAreaEntered;
    }



    // 节点信号 //
    [Signal]
    public delegate void HitEventHandler(Hurtbox hurtbox);



    // 信号方法 //
    private void OnAreaEntered(Area2D area) {
        if (area is Hurtbox hurtbox) {
            EmitSignal(SignalName.Hit, hurtbox);
            hurtbox.EmitSignal(Hurtbox.SignalName.Hurt, this);
        }
    }
}
