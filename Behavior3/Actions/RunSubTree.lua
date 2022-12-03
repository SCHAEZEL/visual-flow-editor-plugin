require 'Behavior3.core.Action'

local runSubTree = b3.Class("RunSubTree", b3.Action)
b3.runSubTree = print

function runSubTree:ctor(params)
	b3.Action.ctor(self)

	self.name = "RunSubTree"
	self.title = "Subtree name <text>"

	self.param_subtree_name = params.subtree_name
end

function runSubTree:tick(tick)
	-- TODO
	warn(self.param_text)
	return b3.SUCCESS
end
