using System;
using Godot;



/// <summary>
/// 黑底白框的白框
/// </summary>
[GlobalClass, Tool, Icon("res://icon/Frame.svg")]
public partial class Frame : Line2D {
    // 构造器 //
    public Frame() {
        // 设置节点数据
        this.Texture = FrameTexture;
        this.TextureMode = LineTextureMode.Tile;

        this.Width = 10.0f;

        this.EndCapMode = LineCapMode.Box;

        // 连接信号
        this.ChildEnteredTree += this.OnChildEnteredTree;
    }



    // 预载资源 //
    private static Texture2D FrameTexture = GD.Load<Texture2D>("res://resource/texture/frame.tres");



    // 节点变量 //
    /// <summary>
    /// 黑底背景
    /// </summary>
    [Export]
    public FrameBackground Background;



    // 功能变量 //
    /// <summary>
    /// 构成外框的点，最后一点需和第一点重合
    /// </summary>
    [Export]
    public Vector2[] FramePoints {
        get => Points;
        set {
            if (Background == null) {
                return;
            }
            
            Background.Polygon = value;
            this.Points = value;

            foreach (Node node in GetChildren()) {
                if (node is StaticBody2D body) {
                    if (body.GetChildOrNull<CollisionPolygon2D>(0) != null) {
                        CollisionPolygon2D polygon = body.GetChildOrNull<CollisionPolygon2D>(0);

                        if (polygon != null) {
                            polygon.Polygon = value;
                        }
                    }
                }
            }
        }
    }



    // 节点方法 //
    public override void _Ready()
    {
        // 初始化背景节点
        if (Background == null) {
            foreach (Node node in GetChildren()) {
                if (node is FrameBackground background) {
                    Background = background;
                    break;
                }
            }
        }
        
        if (Background == null) {
            Background = new FrameBackground();
            AddChild(Background);
        }
    }

    // 信号方法 //
    private void OnChildEnteredTree(Node node) {
        if (node is FrameBackground || node is CollisionObject2D) {
            return;
        }

        // 将子节点转移到背景节点下
        RemoveChild(node);
        Background.AddChild(node);
    }
}
