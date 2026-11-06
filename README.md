# Bewerbro - Dein smarter Bewerbungsassistent

## Projektbeschreibung

**Bewerbro** ist eine Desktop-Anwendung zur Verwaltung des gesamten Bewerbungsprozesses.

Die Anwendung unterstützt Benutzerinnen und Benutzer dabei,

- Unternehmen zu verwalten
- Bewerbungen zu dokumentieren
- Vorstellungsgespräche zu planen
- wichtige Informationen zentral zu speichern
- den aktuellen Status des Bewerbungsprozesses nachzuverfolgen

Das Projekt wurde mit **C#**, **WPF** und dem **MVVM-Pattern (Model-View-ViewModel)** entwickelt.

---

# Projektziel

Ziel der Anwendung ist die zentrale Verwaltung aller Informationen rund um den Bewerbungsprozess.

Anstatt Informationen in verschiedenen Excel-Dateien, E-Mails oder Notizen zu verwalten, werden sämtliche Daten in einer einzigen Anwendung gepflegt.

Die Software dient als persönlicher Bewerbungsassistent und ermöglicht eine strukturierte Übersicht über:

- Unternehmen
- Bewerbungen
- Vorstellungsgespräche
- Bewerbungsstatus

---

# Verwendete Technologien

## Programmiersprache

```text
C#
```

## Benutzeroberfläche

```text
WPF (Windows Presentation Foundation)
```

## Architektur

```text
MVVM (Model-View-ViewModel)
```

## Datenspeicherung

```text
JSON
```

## Framework

```text
.NET Framework 4.7.2
```

---

# Softwarearchitektur

Die Anwendung basiert auf dem **MVVM-Pattern**.

MVVM trennt die Anwendung in drei Bereiche:

## Model

Enthält die Geschäftsobjekte und Datenstrukturen.

Beispiele:

- Company
- Application
- Interview
- Document
- CareerNote

## View

Enthält ausschließlich die grafische Benutzeroberfläche.

Beispiele:

- DashboardView.xaml
- CompaniesView.xaml
- ApplicationsView.xaml
- InterviewsView.xaml

## ViewModel

Verbindet View und Model.

Aufgaben:

- Datenbereitstellung
- Datenbindung (Binding)
- Ausführung von Commands
- CRUD-Operationen
- Navigation zwischen den Modulen

---

# Projektstruktur

```text
Bewerbro
│
├── Commands
│   └── RelayCommand.cs
│
├── Enums
│   └── ApplicationStatus.cs
│
├── Models
│   ├── Ansprechpartner.cs
│   ├── Application.cs
│   ├── ApplicationItem.cs
│   ├── CareerNote.cs
│   ├── Company.cs
│   ├── CompanyItem.cs
│   ├── Document.cs
│   ├── Interview.cs
│   ├── InterviewItem.cs
│   ├── InterviewQuestion.cs
│   └── JobPosition.cs
│
├── Services
│   ├── ApplicationDataService.cs
│   ├── CompanyDataService.cs
│   └── InterviewDataService.cs
│
├── ViewModels
│   ├── ApplicationsViewModel.cs
│   ├── BaseViewModel.cs
│   ├── CompaniesViewModel.cs
│   ├── DashboardViewModel.cs
│   ├── InterviewsViewModel.cs
│   └── MainViewModel.cs
│
├── Views
│   ├── ApplicationsView.xaml
│   ├── ApplicationsView.xaml.cs
│   ├── CompaniesView.xaml
│   ├── DashboardView.xaml
│   ├── DashboardView.xaml.cs
│   └── InterviewsView.xaml
│
├── App.xaml
├── MainWindow.xaml
├── App.config
└── packages.config
```

---

# Beschreibung der Projektordner

## Commands

### RelayCommand.cs

Implementiert das Interface `ICommand`.

Die Klasse ermöglicht die Ausführung von Aktionen über Buttons innerhalb der Benutzeroberfläche.

Beispiele:

```csharp
AddCompanyCommand
UpdateCompanyCommand
DeleteCompanyCommand
```

---

## Enums

### ApplicationStatus.cs

Definiert mögliche Bewerbungsstatus.

Beispiele:

```text
Applied
Interview
Rejected
Offer
Accepted
```

---

# Models

Die Models repräsentieren die Datenobjekte der Anwendung.

---

## CompanyItem.cs

Speichert Informationen über Unternehmen.

Eigenschaften:

```csharp
Id
Name
City
Website
```

---

## ApplicationItem.cs

Speichert Informationen über Bewerbungen.

Eigenschaften:

```csharp
Id
CompanyId
Company
JobTitle
Status
ApplicationDate
```

---

## InterviewItem.cs

Speichert Informationen über Vorstellungsgespräche.

Eigenschaften:

```csharp
Id
ApplicationId
Company
Position
InterviewDate
InterviewTime
Location
ContactPerson
Status
Notes
```

---

## Company.cs

Domänenmodell für Unternehmensdaten.

---

## Application.cs

Domänenmodell für Bewerbungsdaten.

Enthält zusätzliche Felder wie:

```csharp
ApplyDate
Status
MatchScore
Notes
Documents
Interviews
CareerNotes
```

---

## Interview.cs

Domänenmodell für Interviewdaten.

---

## JobPosition.cs

Repräsentiert offene Stellen bzw. ausgeschriebene Positionen.

---

## Ansprechpartner.cs

Speichert Kontaktpersonen eines Unternehmens.

---

## InterviewQuestion.cs

Speichert Fragen zur Vorbereitung auf Vorstellungsgespräche.

---

## Document.cs

Verwaltet Dokumente wie Lebenslauf und Anschreiben.

---

## CareerNote.cs

Speichert persönliche Notizen zum Bewerbungsprozess.

---

# Services

Die Services übernehmen die Datenpersistenz der Anwendung.

---

## CompanyDataService.cs

Verantwortlich für:

```text
companies.json
```

Methoden:

```csharp
LoadCompanies()
SaveCompanies()
```

Aufgabe:

- Unternehmen laden
- Unternehmen speichern

---

## ApplicationDataService.cs

Verantwortlich für:

```text
applications.json
```

Methoden:

```csharp
LoadApplications()
SaveApplications()
```

Aufgabe:

- Bewerbungen laden
- Bewerbungen speichern

---

## InterviewDataService.cs

Verantwortlich für:

```text
interviews.json
```

Methoden:

```csharp
LoadInterviews()
SaveInterviews()
```

Aufgabe:

- Interviews laden
- Interviews speichern

---

# ViewModels

## BaseViewModel.cs

Basisklasse aller ViewModels.

Implementiert:

```csharp
INotifyPropertyChanged
```

Dadurch werden Änderungen automatisch in der Benutzeroberfläche aktualisiert.

---

## MainViewModel.cs

Zentrale Steuerung der Anwendung.

Aufgaben:

- Navigation
- Modulwechsel
- Verwaltung der aktiven Ansicht

Verwendete Module:

```text
Dashboard
Companies
Applications
Interviews
```

---

## DashboardViewModel.cs

Steuert die Dashboard-Seite.

Angezeigte Kennzahlen:

```text
Bewerbungen
Interviews
Zusagen
Absagen
```

Zusätzlich wurde eine Refresh-Funktion implementiert.

---

## CompaniesViewModel.cs

Verantwortlich für das Unternehmensmanagement.

Implementierte Funktionen:

### Create

Neue Unternehmen anlegen.

### Read

Unternehmen anzeigen.

### Update

Unternehmen bearbeiten.

### Delete

Unternehmen löschen.

### Weitere Funktionen

- automatische ID-Vergabe
- Laden aus JSON
- Speichern in JSON
- Startdaten beim ersten Programmstart

---

## ApplicationsViewModel.cs

Verantwortlich für das Bewerbungsmanagement.

Implementierte Funktionen:

### Create

Neue Bewerbung anlegen.

### Read

Bewerbungen anzeigen.

### Update

Bewerbungen bearbeiten.

### Delete

Bewerbungen löschen.

### Weitere Funktionen

- JSON-Persistenz
- automatische ID-Verwaltung
- Standardbewerbungen beim ersten Start

---

## InterviewsViewModel.cs

Verantwortlich für die Interviewverwaltung.

Implementierte Funktionen:

### Create

Interview anlegen.

### Read

Interview anzeigen.

### Update

Interview bearbeiten.

### Delete

Interview löschen.

### Weitere Funktionen

- Datum und Uhrzeit erfassen
- Ansprechpartner speichern
- Meeting-Link oder Adresse speichern
- Status verwalten
- Notizen speichern
- JSON-Persistenz
- Standardinterviews beim ersten Start

---

# Implementierte Module

## Dashboard

Funktionen:

- Übersicht aller Kennzahlen
- Anzeige von Bewerbungen
- Anzeige von Interviews
- Anzeige von Zusagen
- Anzeige von Absagen
- Refresh-Funktion

---

## Companies

Funktionen:

- Unternehmen anlegen
- Unternehmen bearbeiten
- Unternehmen löschen
- automatische Speicherung
- automatische Wiederherstellung
- Verwaltung von Firmeninformationen

---

## Applications

Funktionen:

- Bewerbungen erstellen
- Bewerbungen bearbeiten
- Bewerbungen löschen
- Bewerbungsstatus speichern
- Bewerbungsdatum verwalten
- JSON-Speicherung

---

## Interviews

Funktionen:

- Interviews verwalten
- Ansprechpartner erfassen
- Terminverwaltung
- Zeitverwaltung
- Meeting-Link speichern
- Notizen erfassen
- CRUD-Funktionalität
- JSON-Speicherung

---

# CRUD-Implementierung

Für die Module

- Companies
- Applications
- Interviews

wurden vollständige CRUD-Operationen umgesetzt.

## Create

Neue Datensätze erstellen.

## Read

Datensätze anzeigen.

## Update

Bestehende Datensätze bearbeiten.

## Delete

Datensätze löschen.

---

# Datenpersistenz

Alle Daten werden lokal als JSON-Dateien gespeichert.

Verwendete Dateien:

```text
companies.json
applications.json
interviews.json
```

Vorteile:

- keine Datenbank erforderlich
- einfache Wartung
- Portabilität
- Daten bleiben nach Programmneustart erhalten

---

# Datenbindung (Binding)

Das Projekt nutzt WPF Data Binding.

Beispiel:

```xml
Text="{Binding NewCompanyName}"
```

Vorteile:

- automatische Synchronisation
- weniger Code
- saubere Trennung von UI und Logik

---

# Command Pattern

Alle Benutzeraktionen werden über Commands ausgeführt.

Beispiele:

```csharp
AddCompanyCommand
UpdateCompanyCommand
DeleteCompanyCommand

AddApplicationCommand
UpdateApplicationCommand
DeleteApplicationCommand

AddInterviewCommand
UpdateInterviewCommand
DeleteInterviewCommand
```

Vorteile:

- keine Logik im Code-Behind
- bessere MVVM-Unterstützung
- höhere Wartbarkeit

---

# Besondere technische Merkmale

## MVVM

Klare Trennung von:

```text
View
ViewModel
Model
```

---

## JSON-Persistenz

Automatische Datenspeicherung bei Änderungen.

---

## Dynamische Datenbindung

Automatische Aktualisierung der Benutzeroberfläche durch PropertyChanged.

---

## Wiederverwendbare Commands

Zentrale Steuerung von Benutzeraktionen.

---

# Aktueller Projektstatus

## Abgeschlossen

✅ Dashboard-Modul

✅ Companies-Modul

✅ Applications-Modul

✅ Interviews-Modul

✅ MVVM-Architektur

✅ JSON-Persistenz

✅ Navigation

✅ CRUD-Funktionalität

✅ Data Binding

✅ Command Pattern

✅ Modernisiertes UI-Design

---

# Geplante Erweiterungen

- automatische Dashboard-Aktualisierung ohne Refresh
- vollständige Verknüpfung über IDs:
  - Company → Application → Interview
- Dokumentenmanagement
- Interview-Fragenverwaltung
- Karriere-Notizen
- Berichte und Statistiken
- Datenbankintegration

---

# Fazit

Bewerbro ist eine moderne WPF-Anwendung zur Verwaltung des gesamten Bewerbungsprozesses.

Durch die Verwendung von C#, WPF, MVVM, Commands, Data Binding und JSON-Persistenz wurde eine strukturierte und erweiterbare Softwarelösung entwickelt.

Die Anwendung ermöglicht die Verwaltung von Unternehmen, Bewerbungen und Vorstellungsgesprächen innerhalb einer zentralen Plattform und unterstützt Anwenderinnen und Anwender dabei, ihren Bewerbungsprozess effizient und übersichtlich zu organisieren.