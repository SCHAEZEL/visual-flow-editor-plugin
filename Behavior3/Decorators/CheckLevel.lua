require 'Behavior3.core.Decorator'

local checkLevel = b3.Class("CheckLevel", b3.Decorator)
b3.CheckLevel = checkLevel

function checkLevel:ctor(params)
	b3.Decorator.ctor(self)

	self.name = "CheckLevel"
	self.title = "检查玩家等级"

	if not params then
		params = {}
	end

	self.param_op = params.op or "=="
	self.param_level = params.level or "0"
end

function checkLevel:tick(tick)
	if not self.child then
		return b3.ERROR
	end

	local level = Me:getLevel()
	if (self.param_op == "==" and level == self.param_level) or
	   (self.param_op == ">" and level > self.param_level) or
	   (self.param_op == ">=" and level >= self.param_level) or
	   (self.param_op == "<" and level < self.param_level) or
	   (self.param_op == "<=" and level <= self.param_level)
	   then
		return self.child:_execute(tick)
	end

	return b3.FAILURE
end
