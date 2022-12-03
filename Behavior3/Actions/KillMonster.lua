require 'Behavior3.core.Action'

local KillMonster = b3.Class("KillMonster", b3.Action)
b3.KillMonster = KillMonster

function KillMonster:ctor(params)
	b3.Action.ctor(self)

	self.name = "KillMonster"
	self.title = "KillMonster"

	self.param_amount = params.amount
end

function KillMonster:tick(tick)
	-- TODO
	warn(self.param_text)
	return b3.SUCCESS
end
