# The Asteri Project 001

## Overview
The Asteri Project 001 is the foundation of an expansive narrative-driven experience, blending cutting-edge Unity development with immersive storytelling. This initial prototype sets the stage for a future VR adventure, showcasing key visual and technical elements that will evolve into a rich, interactive universe.

## Project Vision
At its core, The Asteri Project 001 is about pushing the boundaries of digital storytelling. While currently non-interactive, this prototype demonstrates the potential for a deeply engaging VR experience. Players will eventually embark on a high-stakes journey through a simulated reality, with the ultimate goal of awakening Asteri, the central figure in this unfolding drama.

## Key Features
- Dynamic terrain generation system
- Advanced flight path algorithms
- Realistic spacecraft physics and controls
- Immersive visual and audio effects
- Scalable framework for future VR implementation

## Technical Highlights
The project showcases several sophisticated Unity systems:
1. Procedural terrain generation with real-time analysis
2. Autonomous flight systems adapting to complex landscapes
3. Dynamic engine simulation with particle systems and audio
4. Customizable spacecraft control schemes

## Development Roadmap
- Enhance visual fidelity and environmental diversity
- Implement VR compatibility and interactions
- Develop narrative elements and character interactions
- Design and integrate challenge systems
- Expand world-building and lore elements

## Getting Started
1. Clone the repository
2. Open in Unity [version]
3. Load the main scene: [scene name]

## Viewing the Prototype
1. Launch the project in Unity
2. Enter Play mode
3. Observe the autonomous flight demonstration

## Scripts
The project includes the following key scripts:

1. `TerrainAnalysis.cs`: Analyzes the terrain and generates a flight path for the spaceship. It creates waypoints along the terrain surface, considering the desired height and terrain features.

2. `EngineAcceleration.cs`: Manages the spaceship's engine effects. It controls particle systems and engine sounds, creating a dynamic and realistic engine behavior by randomly toggling these effects within specified intervals.

3. `EllipseTerrainMovement.cs`: Controls the spaceship's movement along an elliptical path over the terrain. It adjusts the ship's altitude based on terrain height, implements periodic altitude changes, and applies roll based on terrain features for more dynamic flight behavior.

4. `SpaceshipController.cs`: Handles the player's input for controlling the spaceship. It manages throttle, pitch, roll, and yaw, allowing for full 3D movement. The script also adjusts control sensitivity based on whether the throttle is engaged.

## Contribution Guidelines
While The Asteri Project 001 is currently in its initial development phase, we value community input. Please use the Issues section for suggestions or feedback.

## Contact
Fotiosmpouris@gmail.com

## Acknowledgments
- Unity Technologies
