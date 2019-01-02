﻿

[![version](https://img.shields.io/badge/version-1.0.0-green.svg)](https://semver.org)


# Motivation
Goal: Get rid of complexe instable softwares and voodoo configurations, and do it yourself straight with a few lines of code with as many hardware plugged as you would like.

note: this is early, but it works.

### advantages
- full liberty of in-game behaviour (as complexe as you wish)
- no hardware-maker software, SupervJoy can cover all you need, one tool is enough
- no configuration, you implement what you need
- no gui
- no scripting environment
- light and fast
- you can have 5 T16000m usable at the same time if you want, no usb order is needed, neither obscure software configuration to do
- compatible with a wide range of hardware (joysticks, 3D mouse, xbox controllers ...)
- it's free, crafted with love with the intention of helping everyone to have a better in-game experiences. Also it my main tool for my Star Citizen adventures, so it is daily improved and I'll do my best to make it awsome.

### drawbacks
- no gui
- you need to code, `you lazy bastard`. but you will learn stuff and makes you independant ! also SuperJoy will make it easy for you.

### How it works

![Alt text](doc/super_vJoy.png?raw=true "Principe schema")


# Prerequisite
- Basic Visual Studio handling (open project, edit code, start/stop program, read log)
- Basic c# programming

# Initial setup
- install vjoy(free) [here](https://sourceforge.net/projects/vjoystick/files/latest/download)
- Launch "Configure vJoy" program and Add device 7 and 8. then close it.
- install Visual Studio Community(free) [here](https://visualstudio.microsoft.com/vs/community/). And setup for c# with .net framework 4.6.1
- Open SupervJoy projet with `SupervJoy.sln`

# Documentation

## Don't panic, here is a tour

Using Visual Studio, you job will be to modify/configure in folder `userland` :

- `userland/UserMain.cs:Init()` : this is where you configure, here is mine:

```
public static void Init()
{
	// general configuration
	SuperVJoy.maxOutputAxisCountIWantToUse = 7;
	SuperVJoy.debugOutputRawInputInLog = true;

	// hardware input I want to use
	SuperVJoy.AddHardware("MFG Crosswind V2[bcf78370]");
	SuperVJoy.AddHardware("T.16000M[644e5d30]");

	// custom triggers
	SuperVJoy.AddInputValueChangeTrigger("AutoForward", "MFG Crosswind V2[bcf78370]:RotationZ",  50000, TriggerWay.Up);
}
```

- `userland/Curve.cs:CurveConfigure()` : this is where you configure your output curvres, here is mine (@see `Curves configuration` for details):

```
public static void CurveConfigure()
{
    // strafe left/right
    CurveTool.SetValue(OutAxis.X, 40, 60, 50);
    CurveTool.SetLinear(OutAxis.X, 0, 0, 40, 50);
    CurveTool.SetLinear(OutAxis.X, 60, 50, 100, 100);

    // strafe forward/backward
    CurveTool.SetValue(OutAxis.Y, 85, 100, 100);
    CurveTool.SetValue(OutAxis.Y, 0, 15, 0);
    CurveTool.SetLinear(OutAxis.Y, 15, 0, 85, 100);

    // strafe up/down
    CurveTool.SetValue(OutAxis.Z, 35, 65, 50);
    CurveTool.SetLinear(OutAxis.Z, 0, 0, 35, 50);
    CurveTool.SetLinear(OutAxis.Z, 65, 50, 100, 100);
    CurveTool.Invert(OutAxis.Z);

    // roll
    CurveTool.SetValue(OutAxis.RY, 48, 52, 50);
    CurveTool.SetLinear(OutAxis.RY, 0, 0, 48, 50);
    CurveTool.SetLinear(OutAxis.RY, 52, 50, 100, 100);
}
```

- `userland/UserMain.cs:Init()` : this is where you program the runtime behvior (the method will be called at each refresh, ie a LOT of time), here is a sample:

```
public static void Process() // data routing, behaviour etc
{
	// X (strafe left right)
	SuperVJoy.SetOutputValue(OutAxis.X, "T.16000M[644e5d30]:X");

	// Y (strafe up down)
	SuperVJoy.SetOutputValue(OutAxis.Z, "T.16000M[644e5d30]:Y");
            
	// RY (roll)
	SuperVJoy.SetOutputValue(OutAxis.RY, "T.16000M[644e5d30]:RotationZ");

	// straight keybind
	if (SuperVJoy.OnInputValueChange("T.16000M[644e5d30]:Buttons2:128")) SuperVJoy.AsyncKeyPress(Keys.N); // landing gear
	if (SuperVJoy.OnInputValueChange("T.16000M[644e5d30]:Buttons0:128")) SuperVJoy.AsyncKeyDown(Keys.LShiftKey); // AB
	if (SuperVJoy.OnInputValueChange("T.16000M[644e5d30]:Buttons0:0")) SuperVJoy.AsyncKeyUp(Keys.LShiftKey);
	if (SuperVJoy.OnInputValueChange("T.16000M[644e5d30]:Buttons0:128")) SuperVJoy.AsyncKeyDown(Keys.NumPad3); // boost
	if (SuperVJoy.OnInputValueChange("T.16000M[644e5d30]:Buttons0:0")) SuperVJoy.AsyncKeyUp(Keys.NumPad3);

	if (SuperVJoy.OnInputValueChange("T.16000M[644e5d30]:Buttons1:128")) SuperVJoy.AsyncKeyPress(Keys.F4); // out cam
}
```

Of course examples above are very basic, they are about routing axis, making curves etc. Feel free to implement whatever you want.


## First step: Add an hardware as input

Launch the program (F5, or start play button on top bar) will print you list of hardware like this:

```
[2018-12-31T13:37:00.481298+01:00]Engine: Available devices (14):

Mouse[6f1d2b60]
Keyboard[6f1d2b61]
G19s Gaming Keyboard (Macro interface)[644e3620]
MFG Crosswind V2[bcf78370]
BIRD UM1[5a617130]
G19s Gaming Keyboard[644de800]
G19s Gaming Keyboard[644e5d30]
Gaming Mouse G502[644d72d0]
Gaming Mouse G502[644dc0f0]
Gaming Mouse G502[644de800]
Gaming Mouse G502[644e0f10]
vJoy Device[db79c0e0]
vJoy Device[90b97bc0]
T.16000M[644e5d30]
```

pick and use string code, stop the programm and in code in `userland/UserMain.cs:Init()`, for instance to add 2 hardwares (the 16000 and MFG Crosswind V2):
```
SuperVJoy.AddHardware("T.16000M[644e5d30]")
SuperVJoy.AddHardware(MFG Crosswind V2[bcf78370]")
```

When you restart the program you should see:

```
[2018-12-31T13:37:00.480258+01:00]Engine: Linking hardware devices:

Acquiring hardware MFG Crosswind V2[bcf78370] ...
   success !!

Acquiring hardware T.16000M[644e5d30] ...
   success !!
```


## print hardware input values (for debugging, picking value, axis names ...)

In `userland/UserMain.cs:Init()` , set `debugOutputRawInputInLog` to `true` the start the program, you will see spam in log for every input value update like:

```
T.16000M[644e5d30]:Y:32443
MFG Crosswind V2[bcf78370]:Y:28079
MFG Crosswind V2[bcf78370]:Y:27535
T.16000M[644e5d30]:Y:32667
MFG Crosswind V2[bcf78370]:Y:26831
MFG Crosswind V2[bcf78370]:Y:25967
T.16000M[644e5d30]:Y:32767
MFG Crosswind V2[bcf78370]:Y:24959
MFG Crosswind V2[bcf78370]:Y:23839
MFG Crosswind V2[bcf78370]:Y:22607
MFG Crosswind V2[bcf78370]:Y:21279
T.16000M[644e5d30]:Buttons7:128
T.16000M[644e5d30]:Buttons7:0
```

- `MFG Crosswind V2[bcf78370]:Y` is called a `code` input for my `MFG Crosswind V2` on `Y` axis.
- `T.16000M[644e5d30]:Buttons7:128` is called a `intputActionCode` input for my `T16000` on button `Buttons7` where the value is `128` (pressed).

Don't forget  to put it back to false when your complete all your configurations, print log cost ressources.

## Curves configuration (and debug them)

In `userland/Curves.cs:CurveConfigure()`

use CurveTool to alter a curve for a specific output, for instance:

```
// strafe left/right
CurveTool.SetValue(OutAxis.X, 40, 60, 50); // from 40% to 60% keep output to 50% (deadzone)
CurveTool.SetLinear(OutAxis.X, 0, 0, 40, 50); // draw the curve from point(0 %,0 %) to point(40 %,50 %)
CurveTool.SetLinear(OutAxis.X, 60, 50, 100, 100); // draw the curve from point(60 %, 50 %) to point(100 %, 100 %)
```
note: curves configuration works in percentage (from 0 to 100), unlike elsewhere where it is with absolute value (from 0 to 65535)

To see the result, start program and in tray icon clic on `Show debug dashboard` you will see your curve and can test them live.

![Alt text](doc/curve_output.png?raw=true "curve debugging")

## In `userland/Curves.cs:Process()`, what feature I have?

bind action from my t16000 on X axis to output X of vJoy (a onliner)
```
SuperVJoy.SetOutputValue(OutAxis.X, "T.16000M[644e5d30]:X");
```

Or you can do it manually with the following steps:
Read value from "T.16000M[644e5d30]:X"

```
int strafe = SuperVJoy.GetInputValue("T.16000M[644e5d30]:X");
```

Apply a value to vJoy on X axis:
```
SuperVJoy.SetOutputValue(OutAxis.X, strafe);
```


note: a value goes from `0` to `MAX_RANGE - 1` (ie 65535)

When I press a button (`T.16000M[644e5d30]:Buttons2`) on my T16000, press N button:
```
if (SuperVJoy.OnInputValueChange("T.16000M[644e5d30]:Buttons2:128")) SuperVJoy.AsyncKeyPress(Keys.N);
```

note you also have `SuperVJoy.AsyncKeyUp` and `SuperVJoy.AsyncKeyDown`, very usefull to program "hold button" features. For instance:
```
if (SuperVJoy.OnInputValueChange("T.16000M[644e5d30]:Buttons0:128")) SuperVJoy.AsyncKeyDown(Keys.LShiftKey); // Hold left shift key when pressing Button0
if (SuperVJoy.OnInputValueChange("T.16000M[644e5d30]:Buttons0:0")) SuperVJoy.AsyncKeyUp(Keys.LShiftKey); // Release left shift key when releasing Button0
```

Those feature are here to save you some time, but the core of this project is that you do them yourself, over the time more and more helpers will be available.

## Triggers

configuration: for instance I want an event when on Z rotation axis of my MFG Crosswind V2 the value pass 50000.

In `userland/UserMain.cs:Init()`, declare:
```
SuperVJoy.AddInputValueChangeTrigger("AutoForward", "MFG Crosswind V2[bcf78370]:RotationZ",  50000, TriggerWay.Up);
```

In `userland/UserMain.cs:Process()`, do:
```
if (SuperVJoy.OnTrigger("AutoForward"))
{
	// do what you what, will happend only one time when the trigger ... triggers.
}
```

note: you can see triggers occurence in `Show debug dashboard` panel in event log.

## configure with game

/!\ Don't use your hardware to bind axis, it's the vJoy joytick that have to be used by the game.

Open `Show debug dashboard` from tray icon, and you have a dropdown menu that will simulate output, this is useful to configure your game:
- simulate an axis from `Show debug dashboard`.
- start binding in game.
- voila

note: don't forget to disable ouput simulation when finished


# Credits

Credit to vJoy and it's SDK that works like a charm. You gave me wheel, I built the engine and make it open to everyone.


Tested with (sorry this is all the hardware I have):
- T16000M
- 3D SpaceNavigator
- X52pro
- MFG Crosswind V2
- Xbox 360 controller
- 3 mouses at the same time
- keyboard

If you are an hardware maker and you want to test it or adding compatiblity, I'm available on the discord server (@see contact).

# contact

- discord: https://discord.gg/72T5VMv
- twitch: https://www.twitch.tv/k_galli
