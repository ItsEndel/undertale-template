using Godot;



/// <summary>
/// 游戏根节点
/// </summary>
[GlobalClass, Icon("res://script/Scene/Scene.svg")]
public partial class Game : Node2D, IScene
{
    // 静态变量 //
    /// <summary>
    /// 根节点
    /// </summary>
    public static Game Root { get; private set;}

    /// <summary>
    /// 全局音乐播放器
    /// </summary>
    public static MusicPlayer Music { get; private set; }

    /// <summary>
    /// 主场景
    /// </summary>
    public static IScene Scene {
        get => scene;
        set {
            if (scene != null && scene is Node lastSceneNode) {
                lastSceneNode.QueueFree();
            }

            scene = null;

            if (value is Node sceneNode) {
                Game.Root.AddChild(sceneNode);

                scene = value;
            }
        }
    }

    private static IScene scene;



    // 节点变量 //
    [Export]
    public MusicPlayer MusicPlayer = new();

    [Export]
    public PackedScene MainScene = GD.Load<PackedScene>("res://scene/Bootloader/Bootloader.tscn");



    // 场景方法 //
    void IScene.Enter(ISceneData data) { }

    void IScene.Exit() { }



    // 节点方法 //
    public override void _Ready()
    {
        // 初始化静态变量
        Game.Root = this;
        Game.Music = this.MusicPlayer;

        // 初始化根节点
        Game.Root.AddChild(Game.Music);

        // 加载初始场景
        Game.Scene = this.MainScene.Instantiate<IScene>();
    }
}
