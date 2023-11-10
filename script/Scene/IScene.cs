using Godot;



/// <summary>
/// 场景接口
/// </summary>
public interface IScene {
    static IScene GetParentScene(Node node) {
        Node parent = node;
        while (true) {
            parent = parent.GetParent();

            if (parent is IScene scene) {
                return scene;
            }
        }
    }

    void Enter(ISceneData data);

    ISceneData Exit();
}
