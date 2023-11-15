using Godot;



/// <summary>
/// 房间场景进入数据
/// </summary>
public record RoomSceneData : ISceneData {
    public Vector2 PlayerPosition = Vector2.Zero;
}
