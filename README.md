# Unity Stadia Controller Input
## About
This package adds definition for the Google Stadia Controller to Unity's Input System allowing for the use of a Stadia Controller natively with Unity.

### Known Issues:
* Haptics can not be sent to the controllers.

## Installation
1. Open up Unity's Package Manager ( **Window > Package Manager** )
2. In the top left, hit the `+`(plus) button and select `Add package from git URL...`
3. In the box, paste the package's git repository, then hit Add

**Repo Link:**

`https://github.com/sim2kid/UnityStadiaController.git?path=Assets/Scripts/Package/StadiaInput`
To set a target version, use the release tag like `#1.0.0` at the end of the repo string.

## Required Packages
* Unity Input System >= 1.11.2

## Notes
- Each Stadia Controller must be flashed to Bluetooth Mode before this script will work. Visit [this page](https://stadia.google.com/controller/) to do so now.