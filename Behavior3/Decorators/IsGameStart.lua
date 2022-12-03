require "Behavior3.core.Decorator"

local isGameStart = b3.Class("IsGameStart", b3.Decorator)
b3.IsGameStart = isGameStart

function isGameStart:ctor(params)
    b3.Decorator.ctor(self)

    self.name = "IsGameStart"
    self.title = "游戏是否开始"
end

function isGameStart:tick(tick)
    if not self.child then
        return b3.ERROR
    end

    local status = not table.isNullOrEmpty(AppConst.UserId)
    if status then
        return b3.FAILURE
    else
        return self.child:_execute(tick)
    end
end
