# Revit WPF Import–Export Dashboard Add-in

A simple Autodesk Revit add-in that provides a WPF dashboard to **open (import)** and **save (export)** Revit files using a user-friendly interface.

This plugin adds a ribbon button inside Revit that launches a WPF window with two sections:

- Import Revit files (.RVT / .RFA)
- Export the currently open model using **Save As**

---

## ✨ Features

### Import Section
- Opens Windows File Explorer
- Lets the user select:
  - `.rvt` project files
  - `.rfa` family files
- Selected file opens directly in Revit
- Revit remains fully usable after opening

### Export Section
- Opens Save File dialog
- Lets user:
  - Choose folder
  - Enter new file name
  - Save current Revit model to chosen location

---

## 🧠 Revit-Safe Architecture

Revit does **not allow direct API calls from WPF UI threads**, so this add-in uses the proper Revit pattern:
WPF UI → ExternalEvent → IExternalEventHandler → Revit API


This ensures the add-in runs safely and does not crash Revit.

---

## 📂 Project Structure
RevitWpfDashboard
│
├── App.cs
├── Command.cs
├── DashboardUI.xaml
├── DashboardUI.xaml.cs
├── RevitRequestHandler.cs


### File Responsibilities

**App.cs**
- Creates Ribbon Tab → *Aditya Tools*
- Adds *Import / Export* button to Revit

**Command.cs**
- Entry point when ribbon button is clicked
- Launches the WPF Dashboard window
- Initializes ExternalEvent communication

**DashboardUI.xaml**
- WPF interface for Import & Export UI

**DashboardUI.xaml.cs**
- Handles button clicks
- Sends requests to Revit via ExternalEvent

**RevitRequestHandler.cs**
- Executes Revit API logic:
  - Open selected Revit file
  - Save current document using Save As

---

## ⚙️ How It Works

### Import Workflow
1. User clicks **Import**
2. File dialog opens
3. User selects `.rvt` or `.rfa`
4. Revit opens the selected file using:

   Revit API used:
   UIApplication.OpenAndActivateDocument(filePath)


---

### 3️⃣ Export Workflow (Save Current Model)

1. User clicks **Browse & Export**
2. Save File dialog opens
3. User chooses location + filename
4. Current model is saved using Save As

Revit API used:
Document.SaveAs(path, SaveAsOptions)
UI


<img width="372" height="297" alt="image" src="https://github.com/user-attachments/assets/8bd4a802-2972-4efc-8acf-fb8add0c41bd" />
<img width="662" height="421" alt="image" src="https://github.com/user-attachments/assets/32e73db2-1bc9-4062-ae03-85c311385085" />


### Create Add-in Manifest

Create file:

```xml
<?xml version="1.0" encoding="utf-8" standalone="no"?>
<RevitAddIns>
  <AddIn Type="Application">
    <Name>RevitWpfDashboard</Name>
    <Assembly>FULL_PATH_TO_DLL\RevitWpfDashboard.dll</Assembly>
    <AddInId>Your Addin ID</AddInId>
    <FullClassName>RevitWpfDashboard.App</FullClassName>
    <VendorId>ADSK</VendorId>
    <VendorDescription>Revit Import Export Dashboard</VendorDescription>
  </AddIn>
</RevitAddIns>
