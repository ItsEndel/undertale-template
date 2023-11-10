using Godot;



/// <summary>
/// 音效播放器，在播放完成后自动释放
/// </summary>
public partial class SoundPlayer : AudioStreamPlayer, ISoundPlayer {
    // 节点方法 //
    public override void _Ready()
    {
        Finished += () => {
            QueueFree();
        };
    }
}
