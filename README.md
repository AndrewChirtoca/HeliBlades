# HeliBlades

A small project exploring the benefits of scriptable objects in game architecture design.
Fly around and explore the level, watch out for air defenses.

## Game Controls
* W,A,S,D - movement
* E - enter combat if there are targets in range
* A,S - cycle through the targets that are in range if any
* Space - fire rocket at the selected target
* Q - quit combat

## Architecture Brief
* Cross object event based communication using scriptable objects(SO) as events to which listeners can register.
* Runtime referencing using shared SO variable containers.
* SO base runtime collections(sets) of entities that could substitute any required manager or singleton script.
* Features SO designed to be configuration holders (contain data on which other scripts act upon)
* Features SO designed to implement a certain behavior type/variation (contain logic & method implementation).
* Game entities assembled through composition.

## Built With

The project was build using the Unity3D game engine version 2017.1.1f1.
Unity3D download [page](https://unity3d.com/get-unity/download/archive?_ga=2.246469572.1577312522.1511479487-1175513642.1507589093)

## Authors

* **Andrei Chirtoca** - *Solo developer* - [GitHub Profile](https://github.com/AndrewChirtoca)

## Acknowledgments
* Inspired by **Ryan Hipple's** Unite 2017 [talk](https://youtu.be/raQ3iHhE_Kk)
    "Game Architecture with Scriptable Objects"
* Inspired by **Richard Fine's** Unite 2016 [talk](https://youtu.be/6vmRwLYWNRo)
    "Overthrowing the MonoBehaviour Tyranny in a Glorious Scriptable Object Revolution"
