return [[{
  "version": "0.3.0",
  "scope": "tree",
  "id": "de9edce3-eec7-40f7-af3e-173f38b6164b",
  "title": "A behavior tree",
  "description": "",
  "root": "25bc055a-2361-43eb-8f47-a99582a9f729",
  "properties": {},
  "nodes": {
    "56fdc110-ea2d-4f20-8cbc-ba5224dec137": {
      "id": "56fdc110-ea2d-4f20-8cbc-ba5224dec137",
      "name": "Sequence",
      "title": "Sequence",
      "description": "",
      "properties": {},
      "display": {
        "x": -1092,
        "y": -396
      },
      "children": []
    },
    "7e84244a-9ff3-4a4f-9b87-a6b68a0c7481": {
      "id": "7e84244a-9ff3-4a4f-9b87-a6b68a0c7481",
      "name": "Inverter",
      "title": "Inverter",
      "description": "",
      "properties": {},
      "display": {
        "x": -1152,
        "y": -216
      }
    },
    "706408a4-fd53-4d06-af2d-c3f98701a30e": {
      "id": "706408a4-fd53-4d06-af2d-c3f98701a30e",
      "name": "Priority",
      "title": "Priority",
      "description": "",
      "properties": {},
      "display": {
        "x": -1164,
        "y": 276
      },
      "children": []
    },
    "4cee947a-10a1-4d18-bcc1-724096509784": {
      "id": "4cee947a-10a1-4d18-bcc1-724096509784",
      "name": "Print",
      "title": "打印",
      "description": "[BT] atk > 10",
      "properties": {
        "text": "[BT] atk > 10"
      },
      "display": {
        "x": -336,
        "y": -168
      }
    },
    "6e57791b-cb41-4040-897b-b1ae1088004c": {
      "id": "6e57791b-cb41-4040-897b-b1ae1088004c",
      "name": "Sequence",
      "title": "Sequence",
      "description": "",
      "properties": {},
      "display": {
        "x": -1128,
        "y": 120
      },
      "children": []
    },
    "25bc055a-2361-43eb-8f47-a99582a9f729": {
      "id": "25bc055a-2361-43eb-8f47-a99582a9f729",
      "name": "MemPriority",
      "title": "MemPriority",
      "description": "",
      "properties": {},
      "display": {
        "x": -540,
        "y": -204
      },
      "children": [
        "1d4a19eb-80ed-4479-a166-438801ac2ff6",
        "4cee947a-10a1-4d18-bcc1-724096509784"
      ]
    },
    "1444e8ff-98fb-431b-84fa-b0f2fc9fd3a7": {
      "id": "1444e8ff-98fb-431b-84fa-b0f2fc9fd3a7",
      "name": "Sequence",
      "title": "Sequence",
      "description": "",
      "properties": {},
      "display": {
        "x": -1080,
        "y": -156
      },
      "children": []
    },
    "1d4a19eb-80ed-4479-a166-438801ac2ff6": {
      "id": "1d4a19eb-80ed-4479-a166-438801ac2ff6",
      "name": "CheckAttrib",
      "title": "检查属性",
      "description": "检查属性",
      "properties": {
        "name": "atk",
        "op": ">=",
        "value": 10
      },
      "display": {
        "x": -336,
        "y": -252
      },
      "child": "54bf5692-6402-45f7-a925-edf4ce5e39e4"
    },
    "54bf5692-6402-45f7-a925-edf4ce5e39e4": {
      "id": "54bf5692-6402-45f7-a925-edf4ce5e39e4",
      "name": "Print",
      "title": "打印",
      "description": "",
      "properties": {
        "text": "[BT] atk >= 10"
      },
      "display": {
        "x": -120,
        "y": -252
      }
    }
  },
  "display": {
    "camera_x": 1280,
    "camera_y": 688.5,
    "camera_z": 1,
    "x": -744,
    "y": -204
  },
  "custom_nodes": [
    {
      "version": "0.3.0",
      "scope": "node",
      "name": "Print",
      "category": "action",
      "title": "打印",
      "description": null,
      "properties": {
        "text": "hello world"
      }
    },
    {
      "version": "0.3.0",
      "scope": "node",
      "name": "CheckLevel",
      "category": "decorator",
      "title": "检查等级",
      "description": null,
      "properties": {
        "op": ">",
        "level": 50
      }
    },
    {
      "version": "0.3.0",
      "scope": "node",
      "name": "CheckAttrib",
      "category": "decorator",
      "title": "检查玩家属性",
      "description": "检查属性",
      "properties": {}
    }
  ]
}]]