require "Behavior3.core.Decorator"

local checkAttrib = b3.Class("CheckAttrib", b3.Decorator)
b3.CheckAttrib = checkAttrib

function checkAttrib:ctor(params)
    b3.Decorator.ctor(self)

    self.name = "CheckAttrib"
    self.title = "检查玩家属性"

    if not params then
        params = {}
    end

    self.param_op = params.op or "=="
    self.param_attrib_name = params.name or "level"
    self.param_attrib_value = params.value or "0"
end

function checkAttrib:tick(tick)
    if not self.child then
        return b3.ERROR
    end

    local myValue = Me:queryInt(self.param_attrib_name)
    if (self.param_op == "==" and myValue == self.param_attrib_value)
    or (self.param_op == ">"  and myValue > self.param_attrib_value)
    or (self.param_op == ">=" and myValue >= self.param_attrib_value)
    or (self.param_op == "<"  and myValue < self.param_attrib_value)
    or (self.param_op == "<=" and myValue <= self.param_attrib_value) then
        return self.child:_execute(tick)
    end

    return b3.FAILURE
end
