using System;
using Godot;



/// <summary>
/// 存储敌人信息的资源
/// </summary>
[GlobalClass]
public partial class EnemyResource : Resource {
    /// <summary>
    /// 敌人名称
    /// </summary>
    [Export]
    public string Name { get; set; }

    /// <summary>
    /// 敌人生命值
    /// </summary>
    [Export]
    public float Health { get; set; }

    /// <summary>
    /// 敌人外观场景
    /// </summary>
    [Export]
    public PackedScene Display { get; set; }

    /// <summary>
    /// 敌人战斗脚本
    /// </summary>
    [Export]
    public Script Script { get; set; }

    /// <summary>
    /// 敌人排序优先级
    /// </summary>
    [Export]
    public int Priority { get; set; } = 0;
}
