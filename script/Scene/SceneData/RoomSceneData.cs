using Godot;



/// <summary>
/// 房间场景进入数据
/// </summary>
public record RoomSceneData : ISceneData {
    /// <summary>
    /// 玩家进入房间后的位置
    /// </summary>
    public Vector2 PlayerPosition = Vector2.Zero;
}
