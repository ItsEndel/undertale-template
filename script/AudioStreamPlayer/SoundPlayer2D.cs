using Godot;



/// <summary>
/// 音效播放器，在播放完成后自动释放
/// </summary>
[GlobalClass]
public partial class SoundPlayer2D : AudioStreamPlayer2D, ISoundPlayer {
    // 节点方法 //
    public override void _Ready()
    {
        Finished += () => {
            QueueFree();
        };
    }
}
