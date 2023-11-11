using Godot;



/// <summary>
/// 音乐播放器，在根节点中有实例
/// </summary>
[GlobalClass]
public partial class MusicPlayer : AudioStreamPlayer {
    // 功能变量 //
    /// <summary>
    /// 是否在播放结束后停止音乐
    /// </summary>
    [Export]
    public bool StopOnFinish = false;



    // 节点方法 //
    public override void _Ready()
    {
        // 循环播放
        Finished += () => {
            if (!StopOnFinish) {
                Play();
            }
        };

    }
}
