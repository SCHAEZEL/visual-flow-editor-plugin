require 'Behavior3.core.Action'

local print = b3.Class("Print", b3.Action)
b3.Print = print

function print:ctor(params)
	b3.Action.ctor(self)

	self.name = "Print"
	self.title = "Print <text>"

	self.param_text = params.text
end

function print:tick(tick)
	-- TODO
	warn(self.param_text)
	return b3.SUCCESS
end
