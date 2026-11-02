# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project

- **WeatherSystem** — Unreal Engine 5.8 C++ project (third-person template plus the Combat,
  Platforming and SideScrolling variants). Game module: `WeatherSystem` (Runtime).
- Engine: `E:\UnrealEngine`, a source build; `EngineAssociation` is its registry GUID.
- Git remote: `https://github.com/omgwowai/WeatherSystem.git` (branch `main`).

## Driving the editor from Claude (MCP bridge)

`UnrealMcpBridge` (under `Plugins/`) hosts a localhost WebSocket server inside the running editor.
The Python MCP server at `mcp_server/` exposes it as one tool, `run_unreal_script`, which executes
a `.py` file from `Content/Python/` in the editor's embedded Python interpreter. Both were ported
from `E:\PCG_Claude`.

- **Port `8778`** (host `127.0.0.1`). Other projects on this machine already use 8000, 8765, 8766,
  8767 and 8777, so pick something else if this ever needs to change. The port lives in four
  places that must agree:
  - `Plugins/UnrealMcpBridge/Source/UnrealMcpBridge/Public/UnrealMcpBridgeSettings.h` (the `Port`
    default; also overridable per-user in `Saved/Config/WindowsEditor/Editor.ini` under
    `[/Script/UnrealMcpBridge.UnrealMcpBridgeSettings]`)
  - `.mcp.json` → `env.UE_MCP_PORT`
  - `mcp_server/mcp_server/server.py` (the `UE_MCP_PORT` default)
  - `.claude/skills/driving-unreal-via-mcp/SKILL.md` (the connection-error text it tells you to
    look for)
- **Workflow skill: `.claude/skills/driving-unreal-via-mcp/`** — read it before any editor task.
- Python env for the MCP server is `mcp_server/.venv` (Python 3.14), installed with
  `pip install -e "mcp_server[dev]"`. **`mcp` must stay below 2.0**: `server.py` imports
  `mcp.server.fastmcp.FastMCP`, which was renamed in the 2.x SDK.
- If a call returns `Unreal editor not connected on 127.0.0.1:8778`, the editor is not running with
  the plugin loaded — ask the user to launch it rather than retrying. Check the port with
  `netstat -ano | findstr 8778`.
