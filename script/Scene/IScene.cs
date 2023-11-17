using Godot;



/// <summary>
/// 场景接口
/// </summary>
public interface IScene {
    /// <summary>
    /// 获取在自己之上的 IScene 节点
    /// </summary>
    IScene GetParentScene() {
        if (this is not Node) {
            return null;
        }

        Node parent = (Node)this;
        while (true) {
            parent = parent.GetParent();

            if (parent == null) {
                return null;
            }

            if (parent is IScene scene) {
                return scene;
            }
        }
    }

    /// <summary>
    /// 进入场景时被调用的方法，不应手动调用
    /// </summary>
    void Enter(ISceneData data);

    /// <summary>
    /// 场景退出时被调用的方法，不应手动调用
    /// </summary>
    void Exit();

    void Switch(IScene scene) {
        if (this is not Node) {
            return;
        }

        Node _this = (Node)this;

        IScene parent = GetParentScene();

        if (parent == null) {
            return;
        }
    }
}
