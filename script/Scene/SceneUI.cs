using Godot;



/// <summary>
/// 以 Control 为根类型的场景
/// </summary>
[GlobalClass, Icon("res://script/Scene/SceneUI.svg")]
public abstract partial class SceneUI : Control, IScene {
    public IScene GetParentScene() {
        return IScene.GetParentScene(this);
    }
    
    public abstract void Enter(ISceneData data);

    public abstract ISceneData Exit();
}
