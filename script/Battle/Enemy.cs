using System;
using System.Collections.Generic;
using Godot;



/// <summary>
/// 敌人
/// </summary>
[GlobalClass]
public partial class Enemy : Node2D, IComparer<Enemy> {
    // 构造器 //
    public Enemy() {}

    public Enemy(EnemyResource resource) {
        this.EnemyName = resource.Name;
        this.Health = resource.Health;

        this.AddChild(resource.Display.Instantiate());
        this.SetScript(resource.Script);

        this.Priority = resource.Priority;
    }



    // 功能变量 //
    /// <summary>
    /// 敌人名字
    /// </summary>
    [Export]
    public string EnemyName;

    /// <summary>
    /// 生命值
    /// </summary>
    public float Health;

    /// <summary>
    /// 排序优先级
    /// </summary>
    public int Priority;



    // 基类方法 //
    /// <summary>
    /// 敌人排序优先级比较
    /// </summary>
    public int Compare(Enemy x, Enemy y)
    {
        return x.Priority - y.Priority;
    }



    // 功能方法 //
    /// <summary>
    /// 回合开始
    /// </summary>
    /// <param name="battle">战斗场景实例</param>
    /// <param name="round">开始的回合数</param>
    public void RoundStart(Battle battle, int round) {

    }
}
