# LudareDesignTest
Design Test for a Position at Ludare

===========================================================
Build Prototype and Play Instructions
===========================================================
- using the latest version of Unity(LTS - 2020.3.14) open the Ludare Design Test Project
- go to File->Build Settings and click Build and Run
- select a folder for Unity to build the .exe in 

Controls:
- WA/Arrow Keys for movement
- Space to Jump
- Esc to exit


===========================================================
Project Overview
===========================================================

===========================================================
Abstract:
===========================================================
- decided to outline this as a game jam and an opportunity to learn 
      Unity's 2D toolset
- used Unity's tools to rapid prototype something fun that met
      all conditions while still looking good and having a small gameplay hook
- great opportunity for me as I haven't actually used Unity for 
      2D applications previously although I have a lot of 
      previous experience with sprite work
- all previous Unity experience was 3D
- simple game hook: 
      - lower visibility with point light attached to player
      - pickup batteries to increase range of lightsource
      - reach the end

===========================================================
Challenges
===========================================================
- creating custom sprite work and learning to integrate it into Unity2D
- learning 2D lighting in URP
- thinking of a small game hook that compliments the requirements for the project
- learning Unity2D tools like the Tilemap editor
    
===========================================================
Design Thoughts
===========================================================
- would be best to have a singleton Game Manager that has a template for managers
      this would allow for shorter load times by giving more control over what 
      managers exist in what scenes
- would be better to create a scene and prefab manager to handle loading assets
      and scenes for better control especially over UI
- audio manager could be heavily improved upon, would want to create better audio wrappers
      for sounds that would include more functionality and could hold lists as well
- separating AudioSources from the AudioManager and allowing an object to hold its
      own list of AudioWrapper objects would be better to allow for spatial audio
- URP 2D render asset does not support custom render features yet it seems?
- could create a collectible interface for different pickups that sets basic functionality
- could create character interface to derive from as well
- trigger win-level condition using UnityEvents
      typically using C# events would be better for behaviour that will be this generic like
	  completing a level but in this case UnityEvents provide a quick and easy way to set this up
      in a rapid-prototyping context
- small gameplay hook of collecting batteries to increase the brightness of the player's light was fun
- used coroutines in areas where update wasn't needed 

===========================================================
Programs Used
===========================================================
- sfxr.me (SFX)
- Audiotool (Music)
- Asesprite (Art)
- Unity 
- Visual Studio

===========================================================
Third-Party Assets
===========================================================
- Inconsoltas Font - Raph Levien
     OTF License (included in project files)




