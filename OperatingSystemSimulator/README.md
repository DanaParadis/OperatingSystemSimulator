# Operating System Simulator

A graphical operating system simulator built with C# and Windows Forms.The
application simulates process scheduling and transitions between process states,
providing a visual representation of how an operating system manage CPU execution.

## Features

- **Process Generation**: Creates processes dynamically with randomized attributes.
- **Process State**: Tracks processes through the NEW, READY, RUNNING, BLOCKED and FINISHED states.
- **CPU Scheduling**: Assing ready processes to an available CPU.
- **Round-Robin-Style Scheduling**: Uses a configurable time quantum to determine when a runnong process must return to the ready queue.
- **Process Blocking**: Simulates processes becoming blocked for a randomized period before returning to the ready queue.
- **Graphical Interface**: Display process information and state transitions through Windows Form tables and CPU information fields.
- **Clock Tick Simulation**: Advances the simulation one cycle ata a time, allowing users to observe process scheduling behavior.

## Technologies Used
- C#
- Windows Forms
- Object-Oriented Programming
- Queues and Lists
- Process Scheduling Concepts

## Process Lifecycle

The simulator represents the following process states:

| State      | Description                                                           |
| ---------- | --------------------------------------------------------------------- |
| `NEW`      | The process has been created and is waiting to enter the ready queue. |
| `READY`    | The process is waiting for CPU time.                                  |
| `RUNNING`  | The process is currently executing on the CPU.                        |
| `BLOCKED`  | The process is temporarily unable to execute and must wait.           |
| `FINISHED` | The process has completed its instructions.                           |

Processes move between states as the simulation advances.

## How It Works

1. A process generator creates processes with randomized attributes.
2. Newly created processes enter the `NEW` state.
3. Processes move to the `READY` queue.
4. An available CPU selects a process from the ready queue.
5. The CPU executes instructions according to the configured time quantum.
6. A process may return to `READY`, enter `BLOCKED`, or move to `FINISHED`.
7. Blocked processes return to `READY` when their blocking time expires.

The simulation advances each time the user clicks the **Clock Tick** button.


## Future Improvements

- Support for multiple CPUs.
- Automatic simulation mode.
- Process statistics, including waiting time and execution time.
- Scheduling performance comparisons.
