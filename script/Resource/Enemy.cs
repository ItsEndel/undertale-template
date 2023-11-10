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
    public string Name;

    /// <summary>
    /// 敌人生命值
    /// </summary>
    [Export]
    public float Health;

    /// <summary>
    /// 敌人外观场景
    /// </summary>
    //[Export]
    //public Node Display;
}
