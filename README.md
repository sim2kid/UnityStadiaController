# Unity Stadia Controller Input
## About
This package adds definition for the Google Stadia Controller to Unity's Input System allowing for the use of a Stadia Controller natively with Unity.

### Known Issues:
* Haptics can not be sent to the controllers.

### Tested In:
* Unity 2022.3.50f1

> This will likely work in other versions of Unity. 
> If you have any problems, please open an [Issue](https://github.com/sim2kid/UnityStadiaController/issues/new?assignees=sim2kid&labels=bug&projects=&template=bug_report.md&title=Unity%20Version%20Incapability+%5BBUG%5D)

## Installation
1. Open up Unity's Package Manager ( **Window > Package Manager** )
2. In the top left, hit the `+`(plus) button and select `Add package from git URL...`
3. In the box, paste the package's git repository, then hit Add

**Repo Link:**

`https://github.com/sim2kid/UnityStadiaController.git?path=Assets/Scripts/Package/StadiaInput`
To set a target version, use the release tag like `#1.0.0` at the end of the repo string.

### Alternative Installation
If desired, you can instead install this package by copying the script files into your own repository.
All script files are at `Assets/Scripts/Package/StadiaInput`.

## Required Packages
* Unity Input System >= 1.11.2

## Notes
- Each Stadia Controller must be flashed to Bluetooth Mode before this script will work. Visit [this page](https://stadia.google.com/controller/) to do so now.