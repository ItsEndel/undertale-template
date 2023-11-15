using Godot;



/// <summary>
/// 以 Control 为根类型的场景
/// </summary>
[GlobalClass, Icon("res://icon/SceneUI.svg")]
public abstract partial class SceneUI : Control, IScene {
    public IScene GetParentScene() {
        return IScene.GetParentScene(this);
    }

    public IScene GetParentSceneOrNull() {
        return GetParentScene() ?? this;
    }
    
    public abstract void Enter(ISceneData data);

    public abstract ISceneData Exit();
}
