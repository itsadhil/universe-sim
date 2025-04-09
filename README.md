# 🌌 Universe Simulator VR

An immersive, single-player VR simulation game built in Unity, designed to replicate and interact with realistic cosmic systems in a virtual sandbox. Explore the solar system, control time, trigger cosmic events, and manipulate celestial bodies — all from your headset or PC.

---

## 🚀 Features

- 🌍 Grab, scale, and orbit planets in VR or PC mode.
- 🌀 Control time: slow down, pause, fast-forward, or rewind.
- 💥 Trigger supernovas, black holes, and cosmic events.
- 🧠 Learn real planetary data via floating info panels.
- 🔁 Procedural orbital physics with scalable systems.
- 🎓 Educational mode and real-time data (Firebase optional).
- 🛸 (Planned) Blockchain-based asset ownership (e.g., spaceships, discovered planets).

---

## 🧰 Tech Stack

- **Engine:** Unity 2022.3 LTS
- **Language:** C#
- **VR SDKs:** Unity XR Toolkit, Oculus Integration, OpenXR
- **Backend (Optional):** Firebase (Realtime Database)
- **Blockchain (Planned):** Ethereum / Polygon (ERC-721 NFTs)

---

## 💻 System Requirements

### ✅ PC Mode
- **CPU:** i3 / Ryzen 3+
- **RAM:** 8 GB
- **GPU:** GTX 960 / RX 560+
- **Input:** Keyboard + Mouse / Gamepad

### 🕶️ VR Mode
- **Headset:** Quest 2/3, Rift S, Vive, or Index
- **CPU:** i5 / Ryzen 5+
- **GPU:** GTX 1060 / RX 580+
- **RAM:** 8 GB+
- **Input:** 6DOF VR Controller

---

## 📦 Project Structure

```
/Assets
│
├── _Project
│   ├── Scripts
│   ├── Prefabs
│   ├── UI
│   └── Scenes
├── Resources
├── Plugins
└── XR (OpenXR / Oculus SDK)
```

---

## 🛠️ How to Run

1. Clone this repo  
   `git clone https://github.com/itsadhil/universe-sim.git`

2. Open in **Unity 2022.3 LTS**

3. Ensure **XR Plug-in Management** is installed:
   - Enable Oculus or OpenXR based on your device.

4. Build for:
   - PC: Standalone (Windows x64)
   - VR: XR-enabled build with headset connected

---

## 🔮 Future Enhancements

- Multiplayer sandbox mode
- Galaxy and universe-scale simulation
- Planet creator & editor
- Cross-platform deployment (Quest standalone build)
- Tokenized assets (NFTs for planets/ships)

---

## ⚠️ Known Issues

- UI overlap in VR mode
- Frame drops during heavy cosmic events
- Planet drift during time rewinds (rare)

---
