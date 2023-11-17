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

    /// <summary>
    /// 将自己替换为其他场景
    /// </summary>
    /// <param name="scene">替换为的场景</param>
    /// <param name="data">向替换为的场景传输的数据</param>
    async void Switch(IScene scene, ISceneData data) {
        // 自己和替换为的场景必须均为节点类
        if (this is not Node || scene is not Node) {
            return;
        }

        // 获取节点类的两场景实例
        Node _this = (Node)this;
        Node _scene = (Node)scene;

        // 获取父场景
        IScene parent = GetParentScene();

        await _this.ToSignal(_this.GetTree().CreateTimer(0), SceneTreeTimer.SignalName.Timeout);

        if (parent is null) {
            foreach (Node child in _this.GetChildren()) {
                child.QueueFree();
            }
            _this.ReplaceBy(_scene);
            _this.QueueFree();  
        } else if (parent is Game) {
            Game.Scene = scene;
        } else if (parent is Node parentNode) {
            parentNode.RemoveChild(_this);
            parentNode.AddChild(_scene);
        }

        this.Exit();
        scene.Enter(data);
    }
}
