require "Behavior3.core.Decorator"

local checkPosition = b3.Class("CheckPosition", b3.Decorator)
--------------------------------
--- 节点说明: 检查房间类型
--------------------------------
b3.CheckPosition = checkPosition

function CheckPosition:ctor(params)
    b3.Decorator.ctor(self)

    self.name = "CheckPosition"
    self.title = "检查位置"

    if not params then
        params = {}
    end

    self.param_room_type = params.room_type or "normal"
    self.param_room_id = params.room_id
    self.param_dungeon_id = params.dungeon_id
end

function CheckPosition:tick(tick)
    if not self.child then
        return b3.ERROR
    end

    if self.param_room_type ~= SceneManager.roomType then
        return b3.FAILURE
    elseif self.param_room_type == "normal" then
        local roomId = SceneManager.roomID
        if self.param_room_id ~= roomId then
            return b3.FAILURE
        end
    elseif self.param_room_type == "dungeon" then
        local dungeonId = SceneManager:GetRoomExtraDataValue("dungeon_id")
        if dungeonId ~= self.param_room_id then
            return b3.FAILURE
        end
    else
        return self.child:_execute(tick)
    end
end
