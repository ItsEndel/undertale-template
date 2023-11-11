using Godot;



/// <summary>
/// 黑底白框的黑底
/// </summary>
[GlobalClass, Tool, Icon("res://script/Frame/FrameBackground.svg")]
public partial class FrameBackground : Polygon2D {
    // 构造器 //
    public FrameBackground() {
        this.Texture = GD.Load<Texture2D>("res://asset/texture/UI/colors/black.png");

        this.ShowBehindParent = true;
        this.ClipChildren = ClipChildrenMode.AndDraw;
    }
}
