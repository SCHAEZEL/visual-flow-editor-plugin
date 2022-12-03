require 'Behavior3.core.BaseNode'

local action = b3.Class("Action", b3.BaseNode)
b3.Action = action

function action:ctor()
	b3.BaseNode.ctor(self)

	self.category = b3.ACTION
end

function action:DumpNode()
	local data = {
		version = b3.VERSION,
		scope = "node",
		name = self.name,
		category = self.category,
		title = self.title,
		description = self.description,
		properties = self.properties,
	}
	return json.encode(data)
end