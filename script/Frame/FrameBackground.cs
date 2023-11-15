using Godot;



/// <summary>
/// 黑底白框的黑底
/// </summary>
[GlobalClass, Tool, Icon("res://icon/FrameBackground.svg")]
public partial class FrameBackground : Polygon2D {
    // 构造器 //
    public FrameBackground() {
        this.Texture = GD.Load<Texture2D>("res://resource/texture/color/black.tres");

        this.ShowBehindParent = true;
        this.ClipChildren = ClipChildrenMode.AndDraw;
    }
}
