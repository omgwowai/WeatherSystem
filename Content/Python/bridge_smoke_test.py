import unreal

# READ-ONLY bridge smoke test: report engine, project, current level and its actors.
world = unreal.get_editor_subsystem(unreal.UnrealEditorSubsystem).get_editor_world()
actors = unreal.get_editor_subsystem(unreal.EditorActorSubsystem).get_all_level_actors()

by_class = {}
for actor in actors:
    cls = actor.get_class().get_name()
    by_class[cls] = by_class.get(cls, 0) + 1

engine = unreal.SystemLibrary.get_engine_version()
project = unreal.SystemLibrary.get_project_directory()
level = world.get_path_name() if world else None
print(f"engine:  {engine}")
print(f"project: {project}")
print(f"level:   {level}")
print(f"actors:  {len(actors)}")

mcp_result = {
    "engine_version": engine,
    "project_dir": project,
    "level": level,
    "actor_count": len(actors),
    "actors_by_class": dict(sorted(by_class.items(), key=lambda kv: -kv[1])[:10]),
}
