using Godot;
using System.Collections.Generic;



/// <summary>
/// 战斗场景
/// </summary>
[GlobalClass, Icon("res://icon/Battle.svg")]
public partial class Battle : Node2D, IScene
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
    void IScene.Enter(ISceneData data) { }

    void IScene.Exit() { }



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
