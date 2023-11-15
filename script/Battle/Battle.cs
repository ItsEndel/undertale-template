using Godot;
using System.Collections.Generic;



/// <summary>
/// 战斗场景
/// </summary>
[GlobalClass, Icon("res://icon/Battle.svg")]
public partial class Battle : Scene2D
{
    // 功能变量 //
    /// <summary>
    /// 回合数
    /// </summary>
    public int Round = 0;

    /// <summary>
    /// 敌人列表
    /// </summary>
    public List<Enemy> Enemies = new();



    // 场景方法 //
    public override void Enter(ISceneData data) { }

    public override ISceneData Exit() => null;



    // 功能方法 //
    /// <summary>
    /// 回合开始
    /// </summary>
    public void RoundStart() {
        // 增加回合数
        Round++;

        // TODO

        // 触发敌人的回合开始方法
        foreach (Enemy enemy in Enemies) {
            enemy.RoundStart(this, Round);
        }
    }
}
