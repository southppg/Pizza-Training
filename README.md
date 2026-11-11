# 🍕 Pizza Training (VR)

A simple VR pizza-making training prototype built in **Unity** with the **XR Interaction Toolkit**, made for a university assignment (Assignment 3, CD23036).

> **Note:** This is not a complete pizza-making training program. The project was built mainly to **show core VR and Unity features**, such as grab and snap interactions, socket placement, lighting, particle effects, spatial audio and in-world UI, using a pizza kitchen as the setting.

---

## What it demonstrates

| Feature | How it's used in the project |
|---|---|
| **Grab interactions** | Ingredients, tools (knife, rolling pin, pizza paddle) and dough can be picked up and moved with VR controllers or hand tracking (`XRGrabInteractable`). |
| **Snapping** | Objects released close to a target point snap into place and lock there (`SnapToSlot.cs`). |
| **Socket interactors** | The oven uses an `XRSocketInteractor`. When an uncooked pizza is placed inside, cooking starts automatically (`OvenCooking.cs`). |
| **Simple interactables** | Pressing/selecting a dispenser spawns fresh dough (`DoughSpawner.cs`). |
| **Collision-based state changes** | Rolling pin flattens dough, and sauce, cheese and pepperoni are added when they touch the base (`FlattenDough.cs`, `Sauce.cs`, `Cheese.cs`, `Pepperoni.cs`). |
| **Velocity-based cutting** | A knife cuts the meat only when swung fast enough, splitting it into pieces with physics forces (`MeatCutted.cs`). |
| **Lighting** | URP lighting setup for the kitchen, plus an oven light that turns on while the pizza is cooking. |
| **Particle effects** | Oven fire particles while cooking, and an effect when food is cut. |
| **Audio** | Sound effects for cutting, flattening, the oven and the "done" ting, plus toggleable ambient audio such as the exhaust fan (`AudioToggle.cs`, `ExhauseFan.cs`). |
| **World-space UI** | A step-by-step instruction panel ("Let's Go" → "Okay") guides the player (`InstructionManager.cs`), and a timer slider shows cooking progress (`TimedOvenEffect.cs`). |
| **Hand tracking** | Uses the XR Hands package alongside controller input. |

## Training flow

1. Read the welcome panel and follow the on-screen instructions.
2. Grab a dough ball from the dispenser.
3. Flatten it with the rolling pin.
4. Add sauce, cheese and pepperoni (and cut the toppings with the knife).
5. Place the pizza in the oven and wait for the timer.
6. Collect your cooked pizza. 🍕

## Built with

- **Unity 2022.3.61f1 (LTS)**
- Universal Render Pipeline (URP) 14
- XR Interaction Toolkit 2.5.4
- XR Hands 1.4.3
- OpenXR 1.14.3 / Oculus XR Plugin 4.5.2
- TextMesh Pro

## Getting started

1. Install **Git LFS** before cloning. Models and other large assets are stored with LFS.
   ```bash
   git lfs install
   git clone https://github.com/southppg/Pizza-Training.git
   ```
2. Open the project in **Unity Hub** using Unity **2022.3.61f1** (or a newer 2022.3 LTS version).
3. Open the main scene: `Assets/Scenes/Project_CD23036.unity`
4. Connect a VR headset (Meta Quest via Link/Air Link, or any OpenXR headset) and press **Play**.
   - No headset? Use the **XR Device Simulator** included in the XR Interaction Toolkit samples.

## Project structure

```
Assets/
├── Scenes/      # Project_CD23036 (main), CD23036_03, Module1
├── Scripts/     # Interaction, cooking, cutting, instructions and audio scripts
├── Prefab/      # Dough, pizza and ingredient prefabs
├── Audio/, SoundEffects/
├── Kitchen/     # Kitchen environment
└── XR/, XRI/    # XR and XR Interaction Toolkit settings
```

## Credits

Third-party assets used in this project belong to their respective creators:

- Free Hyper Casual Street Food Pack
- Kitchen Furniture Starter Pack (Mavi3D)
- Low Poly Kitchen Set
- Simple Garage
- Unity *Create with VR* course library
- Sketchfab for Unity

---

*Made as a student assignment. Feedback is welcome!*
