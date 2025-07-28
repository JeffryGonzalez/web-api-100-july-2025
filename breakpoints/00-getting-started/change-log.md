# 00-getting-started - Change Log

Generated on: 7/28/2025

## Overview

This document summarizes the changes made in each step of the "00-getting-started" breakpoint.

## 01-initial

### Files Modified (42 files)

#### .vs\DotNetCatchUp\CopilotIndices\17.14.878.3237/
- CodeChunks.db
- SemanticSymbols.db

#### .vs\DotNetCatchUp\DesignTimeBuild/
- .dtbcache.v2

#### .vs\DotNetCatchUp\FileContentIndex/
- 2d1da116-1827-477a-a655-ac8b4256f834.vsidx

#### .vs\DotNetCatchUp\v17/
- .futdcache.v2
- .suo
- DocumentLayout.backup.json
- DocumentLayout.json

#### .vs\DotNetCatchUp\v17\TestStore\0/
- 000.testlog
- testlog.manifest

#### .vs\ProjectEvaluation/
- dotnetcatchup.metadata.v9.bin
- dotnetcatchup.projects.v9.bin
- dotnetcatchup.strings.v9.bin

#### DotNetCatchUp/
- DotNetCatchUp.csproj
- Program.cs

#### DotNetCatchUp\bin\Debug\net9.0/
- DotNetCatchUp.deps.json
- DotNetCatchUp.dll
- DotNetCatchUp.exe
- DotNetCatchUp.pdb
- DotNetCatchUp.runtimeconfig.json

#### DotNetCatchUp\obj/
- DotNetCatchUp.csproj.nuget.dgspec.json
- DotNetCatchUp.csproj.nuget.g.props
- DotNetCatchUp.csproj.nuget.g.targets
- project.assets.json
- project.nuget.cache

#### DotNetCatchUp\obj\Debug\net9.0/
- .NETCoreApp,Version=v9.0.AssemblyAttributes.cs
- DotNetCatchUp.AssemblyInfo.cs
- DotNetCatchUp.AssemblyInfoInputs.cache
- DotNetCatchUp.GeneratedMSBuildEditorConfig.editorconfig
- DotNetCatchUp.GlobalUsings.g.cs
- DotNetCatchUp.assets.cache
- DotNetCatchUp.csproj.BuildWithSkipAnalyzers
- DotNetCatchUp.csproj.CoreCompileInputs.cache
- DotNetCatchUp.csproj.FileListAbsolute.txt
- DotNetCatchUp.dll
- DotNetCatchUp.genruntimeconfig.cache
- DotNetCatchUp.pdb
- DotNetCatchUp.sourcelink.json
- apphost.exe

#### DotNetCatchUp\obj\Debug\net9.0\ref/
- DotNetCatchUp.dll

#### DotNetCatchUp\obj\Debug\net9.0\refint/
- DotNetCatchUp.dll

- DotNetCatchUp.sln

*This is the initial state of the project.*

## 02-converted-to-top-level

### Files Modified (1 files)

#### src\DotNetCatchUp\DotNetCatchUp/
- Program.cs

*This step contains the changes for: converted to top level*

### Git Changes

<details>
<summary>Show/Hide Diff for 02-converted-to-top-level</summary>

```diff
diff --git a/src/DotNetCatchUp/DotNetCatchUp/Program.cs b/src/DotNetCatchUp/DotNetCatchUp/Program.cs
index fb685c4..15ca0c9 100644
--- a/src/DotNetCatchUp/DotNetCatchUp/Program.cs
+++ b/src/DotNetCatchUp/DotNetCatchUp/Program.cs
@@ -1,10 +1,2 @@
-﻿namespace DotNetCatchUp
-{
-    internal class Program
-    {
-        static void Main(string[] args)
-        {
-            Console.WriteLine("Hello, World!");
-        }
-    }
-}
+﻿
+Console.WriteLine("Hello, World!");
```

</details>

## 03-moved-to-records

### Files Modified (3 files)

#### notes/
- runtime.excalidraw

#### src\DotNetCatchUp\DotNetCatchUp/
- Program.cs
- Types.cs

*This step contains the changes for: moved to records*

### Git Changes

<details>
<summary>Show/Hide Diff for 03-moved-to-records</summary>

```diff
diff --git a/notes/runtime.excalidraw b/notes/runtime.excalidraw
new file mode 100644
index 0000000..28e2f78
--- /dev/null
+++ b/notes/runtime.excalidraw
@@ -0,0 +1,318 @@
+{
+  "type": "excalidraw",
+  "version": 2,
+  "source": "https://marketplace.visualstudio.com/items?itemName=pomdtr.excalidraw-editor",
+  "elements": [
+    {
+      "id": "E4Z8btixqaJnSUqxkyxAj",
+      "type": "rectangle",
+      "x": 388,
+      "y": 152,
+      "width": 197,
+      "height": 438,
+      "angle": 0,
+      "strokeColor": "#1e1e1e",
+      "backgroundColor": "transparent",
+      "fillStyle": "solid",
+      "strokeWidth": 2,
+      "strokeStyle": "solid",
+      "roughness": 1,
+      "opacity": 100,
+      "groupIds": [],
+      "frameId": null,
+      "index": "a0",
+      "roundness": {
+        "type": 3
+      },
+      "seed": 958408538,
+      "version": 16,
+      "versionNonce": 2103422298,
+      "isDeleted": false,
+      "boundElements": null,
+      "updated": 1753719249098,
+      "link": null,
+      "locked": false
+    },
+    {
+      "id": "zVMtiQmcuIReayYAaWp2p",
+      "type": "rectangle",
+      "x": 595,
+      "y": 154,
+      "width": 516,
+      "height": 435,
+      "angle": 0,
+      "strokeColor": "#1e1e1e",
+      "backgroundColor": "transparent",
+      "fillStyle": "solid",
+      "strokeWidth": 2,
+      "strokeStyle": "solid",
+      "roughness": 1,
+      "opacity": 100,
+      "groupIds": [],
+      "frameId": null,
+      "index": "a1",
+      "roundness": {
+        "type": 3
+      },
+      "seed": 18764934,
+      "version": 30,
+      "versionNonce": 43622726,
+      "isDeleted": false,
+      "boundElements": null,
+      "updated": 1753719252952,
+      "link": null,
+      "locked": false
+    },
+    {
+      "id": "EK6hxTSk8PxWap33bZV9q",
+      "type": "rectangle",
+      "x": 880,
+      "y": 187,
+      "width": 85,
+      "height": 89,
+      "angle": 0,
+      "strokeColor": "#1e1e1e",
+      "backgroundColor": "transparent",
+      "fillStyle": "solid",
+      "strokeWidth": 2,
+      "strokeStyle": "solid",
+      "roughness": 1,
+      "opacity": 100,
+      "groupIds": [],
+      "frameId": null,
+      "index": "a2",
+      "roundness": {
+        "type": 3
+      },
+      "seed": 280968134,
+      "version": 13,
+      "versionNonce": 1490561222,
+      "isDeleted": false,
+      "boundElements": [
+        {
+          "id": "87r6Hf1UI_TtSFDcnc9Y4",
+          "type": "text"
+        }
+      ],
+      "updated": 1753719260916,
+      "link": null,
+      "locked": false
+    },
+    {
+      "id": "87r6Hf1UI_TtSFDcnc9Y4",
+      "type": "text",
+      "x": 905.3300170898438,
+      "y": 219,
+      "width": 34.3399658203125,
+      "height": 25,
+      "angle": 0,
+      "strokeColor": "#1e1e1e",
+      "backgroundColor": "transparent",
+      "fillStyle": "solid",
+      "strokeWidth": 2,
+      "strokeStyle": "solid",
+      "roughness": 1,
+      "opacity": 100,
+      "groupIds": [],
+      "frameId": null,
+      "index": "a3",
+      "roundness": null,
+      "seed": 909103878,
+      "version": 9,
+      "versionNonce": 1265138138,
+      "isDeleted": false,
+      "boundElements": null,
+      "updated": 1753719260916,
+      "link": null,
+      "locked": false,
+      "text": "carl",
+      "fontSize": 20,
+      "fontFamily": 5,
+      "textAlign": "center",
+      "verticalAlign": "middle",
+      "containerId": "EK6hxTSk8PxWap33bZV9q",
+      "originalText": "carl",
+      "autoResize": true,
+      "lineHeight": 1.25
+    },
+    {
+      "id": "VBfc9Ux59nuM9YzlDwzfN",
+      "type": "rectangle",
+      "x": 835,
+      "y": 307,
+      "width": 85,
+      "height": 89,
+      "angle": 0,
+      "strokeColor": "#1e1e1e",
+      "backgroundColor": "transparent",
+      "fillStyle": "solid",
+      "strokeWidth": 2,
+      "strokeStyle": "solid",
+      "roughness": 1,
+      "opacity": 100,
+      "groupIds": [],
+      "frameId": null,
+      "index": "a4",
+      "roundness": {
+        "type": 3
+      },
+      "seed": 8235738,
+      "version": 22,
+      "versionNonce": 30306138,
+      "isDeleted": false,
+      "boundElements": [
+        {
+          "type": "text",
+          "id": "RcmeaPciCOL8zR8JuE1QV"
+        },
+        {
+          "id": "luLM_DjjLLbAipB2ingeX",
+          "type": "arrow"
+        }
+      ],
+      "updated": 1753719272469,
+      "link": null,
+      "locked": false
+    },
+    {
+      "id": "RcmeaPciCOL8zR8JuE1QV",
+      "type": "text",
+      "x": 853.3300170898438,
+      "y": 339,
+      "width": 48.3399658203125,
+      "height": 25,
+      "angle": 0,
+      "strokeColor": "#1e1e1e",
+      "backgroundColor": "transparent",
+      "fillStyle": "solid",
+      "strokeWidth": 2,
+      "strokeStyle": "solid",
+      "roughness": 1,
+      "opacity": 100,
+      "groupIds": [],
+      "frameId": null,
+      "index": "a5",
+      "roundness": null,
+      "seed": 1251320474,
+      "version": 19,
+      "versionNonce": 912624602,
+      "isDeleted": false,
+      "boundElements": null,
+      "updated": 1753719264102,
+      "link": null,
+      "locked": false,
+      "text": "carl2",
+      "fontSize": 20,
+      "fontFamily": 5,
+      "textAlign": "center",
+      "verticalAlign": "middle",
+      "containerId": "VBfc9Ux59nuM9YzlDwzfN",
+      "originalText": "carl2",
+      "autoResize": true,
+      "lineHeight": 1.25
+    },
+    {
+      "id": "_862SpGGLZRXoUXorXXyi",
+      "type": "arrow",
+      "x": 526,
+      "y": 517,
+      "width": 332,
+      "height": 289,
+      "angle": 0,
+      "strokeColor": "#1e1e1e",
+      "backgroundColor": "transparent",
+      "fillStyle": "solid",
+      "strokeWidth": 2,
+      "strokeStyle": "solid",
+      "roughness": 1,
+      "opacity": 100,
+      "groupIds": [],
+      "frameId": null,
+      "index": "a6",
+      "roundness": {
+        "type": 2
+      },
+      "seed": 419683674,
+      "version": 21,
+      "versionNonce": 1226571206,
+      "isDeleted": false,
+      "boundElements": null,
+      "updated": 1753719269001,
+      "link": null,
+      "locked": false,
+      "points": [
+        [
+          0,
+          0
+        ],
+        [
+          332,
+          -289
+        ]
+      ],
+      "lastCommittedPoint": null,
+      "startBinding": null,
+      "endBinding": null,
+      "startArrowhead": null,
+      "endArrowhead": "arrow",
+      "elbowed": false
+    },
+    {
+      "id": "luLM_DjjLLbAipB2ingeX",
+      "type": "arrow",
+      "x": 546,
+      "y": 529,
+      "width": 278,
+      "height": 150,
+      "angle": 0,
+      "strokeColor": "#1e1e1e",
+      "backgroundColor": "transparent",
+      "fillStyle": "solid",
+      "strokeWidth": 2,
+      "strokeStyle": "solid",
+      "roughness": 1,
+      "opacity": 100,
+      "groupIds": [],
+      "frameId": null,
+      "index": "a7",
+      "roundness": {
+        "type": 2
+      },
+      "seed": 161764614,
+      "version": 23,
+      "versionNonce": 258986650,
+      "isDeleted": false,
+      "boundElements": null,
+      "updated": 1753719272469,
+      "link": null,
+      "locked": false,
+      "points": [
+        [
+          0,
+          0
+        ],
+        [
+          278,
+          -150
+        ]
+      ],
+      "lastCommittedPoint": null,
+      "startBinding": null,
+      "endBinding": {
+        "elementId": "VBfc9Ux59nuM9YzlDwzfN",
+        "focus": 0.020270991144778018,
+        "gap": 11.17956965970207
+      },
+      "startArrowhead": null,
+      "endArrowhead": "arrow",
+      "elbowed": false
+    }
+  ],
+  "appState": {
+    "gridSize": 20,
+    "gridStep": 5,
+    "gridModeEnabled": false,
+    "viewBackgroundColor": "#ffffff"
+  },
+  "files": {}
+}
\ No newline at end of file
diff --git a/src/DotNetCatchUp/DotNetCatchUp/Program.cs b/src/DotNetCatchUp/DotNetCatchUp/Program.cs
index 15ca0c9..f776e29 100644
--- a/src/DotNetCatchUp/DotNetCatchUp/Program.cs
+++ b/src/DotNetCatchUp/DotNetCatchUp/Program.cs
@@ -1,2 +1,46 @@
 ﻿
 Console.WriteLine("Hello, World!");
+
+
+var carl = new Employee();
+
+carl.Name = "Carl Smith";
+carl.Salary = 100_000M;
+
+Console.WriteLine($"Salary is {carl.Salary}");
+Console.WriteLine(carl.Name.ToUpper());
+
+
+var carl2 = new Employee();
+
+carl2.Name = "Carl Smith";
+carl2.Salary = 100_000;
+
+if(carl == carl2)
+{
+    Console.WriteLine("The carls are the same");
+
+}
+else
+{
+    Console.WriteLine("The carls are different");
+
+}
+Console.WriteLine(carl);
+Console.WriteLine(carl2);
+
+
+var bob = EmployeeRepository.GetById(13);
+
+Console.WriteLine(bob.Name);
+
+//bob.Salary = bob.Salary * 2;
+
+Console.WriteLine(bob.Salary);
+
+
+var bobUpdated = bob with { Salary = 8000 };
+
+Console.WriteLine("After the Update");
+Console.WriteLine(bob);
+Console.WriteLine(bobUpdated);
\ No newline at end of file
diff --git a/src/DotNetCatchUp/DotNetCatchUp/Types.cs b/src/DotNetCatchUp/DotNetCatchUp/Types.cs
new file mode 100644
index 0000000..efd41a8
--- /dev/null
+++ b/src/DotNetCatchUp/DotNetCatchUp/Types.cs
@@ -0,0 +1,20 @@
+﻿
+public record Employee
+{
+    public int Id { get; set; }
+    public string Name { get; set; } = string.Empty;
+    public decimal Salary { get; set; }
+
+
+}
+
+public record Employee2(int Id, string Name, decimal Salary);
+
+
+public class EmployeeRepository
+{
+    public static Employee2 GetById(int id)
+    {
+        return new Employee2(id, "Bob Smith", 32_000);
+    }
+}
\ No newline at end of file
```

</details>

## Summary

- **Total Steps**: 3
- **Breakpoint**: 00-getting-started
- **Git Integration**: Enabled
- **Includes Diffs**: Yes

---

*Generated by BreakPoint VS Code Extension*
