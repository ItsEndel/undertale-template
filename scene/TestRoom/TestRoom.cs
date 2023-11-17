using System.Diagnostics;
using Godot;



public partial class TestRoom : Room
{
    // 节点变量 //
    /// <summary>
    /// 玩家节点
    /// </summary>
    private Player _player;



    // 房间方法 //
    public override void Enter(ISceneData data)
    {
        if (data is RoomSceneData roomSceneData) {
            _player.Position = roomSceneData.PlayerPosition;
        }
    }


    // 节点方法 //
    public override void _Ready()
    {
        // 获取子节点
        _player = GetNode<Player>("Player");

        // 连接信号
        GetNode<Area2D>("DoorLeft").BodyEntered += (Node2D body) => {
            if (body is not Player) {
                return;
            }

            ((IScene)this).Switch(GD.Load<PackedScene>("res://scene/TestRoom/TestRoom.tscn").Instantiate<IScene>(), new RoomSceneData() {
                PlayerPosition = new Vector2(1200.0f, 120.0f)
            });
        };
    }
}
