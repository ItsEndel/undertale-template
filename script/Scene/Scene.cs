using Godot;



/// <summary>
/// 以 Node 为根类型的场景
/// </summary>
[GlobalClass]
public abstract partial class Scene : Node, IScene {
    public IScene GetParentScene() {
        return IScene.GetParentScene(this);
    }

    public abstract void Enter(ISceneData data);

    public abstract ISceneData Exit();
}
