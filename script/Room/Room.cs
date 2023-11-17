using Godot;



/// <summary>
/// 房间场景
/// </summary>
[GlobalClass]
public partial class Room : Node2D, IScene
{
    public virtual void Enter(ISceneData data) { }

    public virtual void Exit() { }
}
