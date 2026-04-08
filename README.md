# 🛡️ Unity-Stalker-NPC (Gag Character)

This repository contains a custom script for a random Non-Player Character (NPC) that just aggressively follows the player around for the gag effect. It uses Unity's NavMesh system, has a hard-coded 3-minute timer, and is completely invincible just to be annoying.

---

### 👋 The Story Behind This (Why I made it)
A friend of mine texted me, *"I'm building a game lol, can u give me ideas?"* he was mostly just joking around, but I had some free time so I was just like, *"ok."* I opened up Unity and wrote this quick C# script for a random NPC that just stalks the player for absolutely no reason. I wanted to give him a small joke detail he could drop straight into his project to mess with his players without breaking his actual game.

### ⚙️ What it actually does
Ngl, it’s a pretty simple script, but it gets the joke across perfectly:
* **The Stalker Mechanic:** It uses Unity's `NavMeshAgent` to follow the player around, but it stops at a set distance so it doesn't phase into your character model it just stands there staring at you. 
* **The Lazy Timer:** I hard-coded a 3-minute timer (180 seconds). Once the time is up, the NPC just gives up, stops following you, and stands still or disappears  
* **God Mode:** I know my friend's game has actual enemies, so I made this random dude completely invincible. It changes its own tag to "Untagged" so enemies ignore it, and I put a fake `TakeDamage` function in there that just prints a joke to the console instead of letting the NPC die.

He actually ended up throwing it into his build just for the laughs. It was a super fun to do from my normal coursework and honestly, coding stupid stuff like this is pretty satisfying.
