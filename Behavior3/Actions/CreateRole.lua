require 'Behavior3.core.Action'

local CreateRole = b3.Class("CreateRole", b3.Action)
b3.CreateRole = CreateRole

function CreateRole:ctor(params)
	b3.Action.ctor(self)

	self.name = "CreateRole"
	self.title = "新建角色"

	self.param_account = params.name
	self.param_name = params.name
end

function CreateRole:tick(tick)
	-- TODO
	warn(self.param_text)
	return b3.SUCCESS
end
