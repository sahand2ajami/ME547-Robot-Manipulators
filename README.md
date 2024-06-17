# ME547-Robot-Manipulators

This repository contains the lab content for MTE/ME360-Automatic Control (taught in University of Waterloo), focusing on different manipulators (Fanuc, QArm and Franka Emika). The labs are designed to provide hands-on experience with forward and inverse kinematics as well as dynamics and controls using Visual Basic, MATLAB and Simulink.
Prerequisites

## Prerequisites
Before you begin, ensure you have the following installed:
- MATLAB (R2021a or later)
- Simulink
- Control System Toolbox
- Quanser Hardware Support Package (for real-time implementation)
- Quanser linear flexible joint [[https://www.quanser.com/products/linear-flexible-joint/](https://www.quanser.com/products/linear-flexible-joint/)]

## Lab Content
The repository is structured as follows:
- `Lab1/`: Forward Kinematics and Vision
  - **Fanuc Robot:**
    - Derive the forward kinematics equations.
    - Calculate coordinates for a shape-drawing task.
  - **QArm Robot:**
    - Apply coordinate transformations from an overhead camera to the robot frame.
    - Perform a pick-and-place operation.
    - Use image processing to determine object location for robotic manipulation.
- `Lab2/`: Inverse Kinematics:
  - **Fanuc Robot:**
    - Derive the inverse kinematics equations for pick-and-place tasks.
    - Calculate joint angles for given poses.
    - Perform pick-and-place tasks with objects having specific orientations.
  - **QArm Robot:**
    - Solve inverse kinematics for joint commands to reach given positions.
    - Calculate object and box locations using vision system.
    - Execute pick-and-place operations, ensuring the robot returns to the home position.
- `Lab3/`: Dynamics and Controls:
  - Implement and tune PD controllers, add feedforward control, and include Coriolis effect compensation on joints 2 and 4 of the Franka Emika Panda robot.
  - Perform experiments with and without disturbances and record data for analysis.
  - Compare trajectory-tracking accuracy and robustness of different controllers (PD, PD + Feedforward, PD + Feedforward + Coriolis Compensation).
  - Design a PI controller for the end-effector force control on the Franka Emika Panda robot.
  - Execute force control tasks under different conditions: stationary, moving on a path, and moving on a path with a bump.
  - Record and analyze force and torque data to evaluate controller performance.
