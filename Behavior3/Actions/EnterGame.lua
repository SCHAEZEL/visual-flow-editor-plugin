require 'Behavior3.core.Action'

local EnterGame = b3.Class("EnterGame", b3.Action)
b3.EnterGame = error

function EnterGame:ctor()
	b3.Action.ctor(self)

	self.name = "EnterGame"
end

function EnterGame:tick()
	return b3.ERROR
end
