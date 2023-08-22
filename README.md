# EXAMPLES-CSharp-AWS-AltTrashCat

This repository contains the code needed to run C# test on an TrashCat build instrumented with AltUnity SDK v2.0.1 using AWS Device Farm. You can also find the YAML files needed to add in the Test Specification when configuring your run. 
More details about the setup can be found in this article. 

### You can run these tests on your local machine by having an open Appium Server.

## Executing tests using `AltTester Unity SDK 2.0.1` (locally, without AWS Device Farm).
### Prerequisite

1. Download and install [.NET SDK](https://dotnet.microsoft.com/en-us/download). Make sure you use .NET 6.0 as your Target Framework. 
2. Have a build instrumented with AltTester SDK 2.0.1.
3. Have [AltTester Desktop app, 2.0.1](https://alttester.com/alttester/#pricing) installed (to be able to inspect game).
- For SDK v2.0.1 => need to use AltTester Desktop 2.0.1
4. Add AltTester package:
```
dotnet add package AltTester-Driver --version 2.0.1
```
5. Add Appium Webdriver:
 ```
dotnet add package Appium.WebDriver --version 4.4.0
``` 
6. Add Selenium Webdriver 
```
dotnet add package Selenium.WebDriver --version 3.141.0
```

#### Specific for running on Android from Windows
7. Download and install [ADB for Windows](https://dl.google.com/android/repository/platform-tools-latest-windows.zip)
8. Enable Developers Options on mobile device [more instructions here](https://www.xda-developers.com/install-adb-windows-macos-linux/)

# Setup for running on mobile device
For Android, here is a [build instrumented with AltTester SDK 2.0.1](https://alttester.com/app/uploads/AltTester/TrashCat/TrashCatAndroid2.0.1.zip).

1. Make sure mobile device is connected via USB, execute:

```
adb devices
```

2. On mobile device: allow USB Debugging access (RSA key fingerprint from computer)

3. Uninstall the app from the device

```
adb uninstall com.Altom.TrashCat
```

4. Install the app on the device

```
adb install TrashCat.apk
```

# Run tests manually (with [dotnet CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-test))
! **When running v2.0.0 make sure to have the AltTester Desktop App running**

1. [Optional to do manually] Setup ADB reverse port forwarding (this can also be done in code in Setup and Teardown)

```
adb reverse remove tcp:13000
```

```
adb reverse tcp:13000 tcp:13000
```

2. Execute all tests:

```
dotnet test
```



### Run all tests from a specific class / file

```
dotnet test --filter <test_class_name>
```

### Run only one test from a class

```
dotnet test --filter <test_class_name>.<test_name>
```
