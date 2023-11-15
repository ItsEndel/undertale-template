using Godot;



/// <summary>
/// 以 Node2D 为根类型的场景
/// </summary>
[GlobalClass, Icon("res://icon/Scene2D.svg")]
public abstract partial class Scene2D : Node2D, IScene {
    public IScene GetParentScene() {
        return IScene.GetParentScene(this);
    }

    public IScene GetParentSceneOrNull() {
        return GetParentScene() ?? this;
    }

    public abstract void Enter(ISceneData data);

    public abstract ISceneData Exit();
}
