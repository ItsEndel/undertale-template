using System;
using Godot;



/// <summary>
/// 游戏根节点
/// </summary>
public partial class Game : Node2D, IScene
{
    // 静态变量 //
    /// <summary>
    /// 根节点
    /// </summary>
    public static Game Root;

    /// <summary>
    /// 全局音乐播放器
    /// </summary>
    public static MusicPlayer Music;

    /// <summary>
    /// 主场景
    /// </summary>
    public static IScene Scene {
        get => scene;
        set {
            ISceneData data = null;
            if (scene != null && scene is Node lastSceneNode) {
                lastSceneNode.QueueFree();
                data = scene.Exit();
            }

            scene = null;

            if (value is Node sceneNode) {
                value.Enter(data);
                Game.Root.AddChild(sceneNode);

                scene = value;
            }
        }
    }

    private static IScene scene;



    // 场景方法 //
    void IScene.Enter(ISceneData data) { }

    ISceneData IScene.Exit() { return null; }



    // 节点方法 //
    public override void _Ready()
    {
        // 初始化静态变量
        Game.Root = this;
        Game.Music = new MusicPlayer();

        // 初始化根节点
        Game.Root.AddChild(Game.Music);

        // 加载初始场景
    }
}
