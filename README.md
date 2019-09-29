# Meltdown!
### SoftEng 306: Project 2
## Setting up Git with Unity for project development
1. Clone this repository to your local machine
2. Install Unity version 2019.2.6f1
3. Install [Blender](https://www.blender.org/download/)
4. Add Git Large File Storage support to your local repository. To do this:
    1. Download the [Git LFS command line extension](https://github.com/git-lfs/git-lfs/releases/download/v2.8.0/git-lfs-windows-v2.8.0.exe)
    2. Navigate to the repository location in Command Prompt and run `git lfs install`
5. Make sure the project settings are correct in Unity:
    1. Open Meltdown! in Unity
    2. Open the editor settings window: `Edit > Project Settings > Editor`
    3. Ensure `.meta` files are visible to avoid broken object references: `Version Control / Mode: “Visible Meta Files”`
    4. Ensure plain text serialization is used to avoid unresolvable merge conflicts: `Asset Serialization / Mode: “Force Text”`
    5. Save changes: `File > Save Project`
