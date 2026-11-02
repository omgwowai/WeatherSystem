// Copyright Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;

public class WeatherSystem : ModuleRules
{
	public WeatherSystem(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

		PublicDependencyModuleNames.AddRange(new string[] {
			"Core",
			"CoreUObject",
			"Engine",
			"InputCore",
			"EnhancedInput",
			"AIModule",
			"StateTreeModule",
			"GameplayStateTreeModule",
			"UMG",
			"Slate"
		});

		PrivateDependencyModuleNames.AddRange(new string[] { });

		PublicIncludePaths.AddRange(new string[] {
			"WeatherSystem",
			"WeatherSystem/Variant_Platforming",
			"WeatherSystem/Variant_Platforming/Animation",
			"WeatherSystem/Variant_Combat",
			"WeatherSystem/Variant_Combat/AI",
			"WeatherSystem/Variant_Combat/Animation",
			"WeatherSystem/Variant_Combat/Gameplay",
			"WeatherSystem/Variant_Combat/Interfaces",
			"WeatherSystem/Variant_Combat/UI",
			"WeatherSystem/Variant_SideScrolling",
			"WeatherSystem/Variant_SideScrolling/AI",
			"WeatherSystem/Variant_SideScrolling/Gameplay",
			"WeatherSystem/Variant_SideScrolling/Interfaces",
			"WeatherSystem/Variant_SideScrolling/UI"
		});

		// Uncomment if you are using Slate UI
		// PrivateDependencyModuleNames.AddRange(new string[] { "Slate", "SlateCore" });

		// Uncomment if you are using online features
		// PrivateDependencyModuleNames.Add("OnlineSubsystem");

		// To include OnlineSubsystemSteam, add it to the plugins section in your uproject file with the Enabled attribute set to true
	}
}
