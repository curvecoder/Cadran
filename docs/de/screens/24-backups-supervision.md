# Benutzerhandbuch: Windows Tray Launcher & automatische Backups

[← Zurück: 23 - Erscheinungsbild & Designeinstellungen](23-appearance-settings.md) | [Zurück zum Hauptindex](../README.md) | [Weiter: 25 - Manuelle Buchungen abgleichen →](25-manual-reconciliation.md)

---

Der **Cadran Tray Launcher** verwaltet den Webserver im Hintergrund, überwacht den Zustand des Prozesses und automatisiert Datenbank-Backups und Aufbewahrungsrichtlinien ohne Datenverlust. Er läuft im Infobereich der Windows-Taskleiste neben der Uhr.

---

## 1. Visuelle Übersicht & Aktionsmarkierungen

![Windows Tray Launcher & Backup-Verwaltung](../../images/screens/24-backups-supervision-screen-annotated.png)

---

## 2. Referenztabelle der Aktionen

| Markierung | Bedienelement | Aktionstyp | Handlungsanweisung |
| :---: | :--- | :---: | :--- |
| <kbd>1</kbd> | **Hauptreiter der Überwachung** | **REITER KLICKEN** | Wechseln Sie zwischen Server-Dashboard, Backups & Wiederherstellung, Echtzeit-Konsolenprotokoll und Einstellungen. |
| <kbd>2</kbd> | **Schaltfläche „Backup jetzt erstellen"** | **HIER KLICKEN** | Löst sofort einen atomaren Schnappschuss Ihrer SQLite-/SQLCipher-Datenbank aus. |
| <kbd>3</kbd> | **Schaltfläche „Ausgewähltes Backup wiederherstellen"** | **HIER KLICKEN** | Setzt Ihre Finanzdatenbank auf den gewählten Sicherungsstand zurück. |
| <kbd>4</kbd> | **Backup-Verlauf** | **PRÜFEN / WÄHLEN** | Sehen Sie Datum, Dateiname, Dateigröße und Auslöser (Geplant, Vor Import, Manuell) der Schnappschüsse. |
| <kbd>5</kbd> | **Schaltfläche „Backup-Ordner öffnen"** | **HIER KLICKEN** | Öffnet den Backup-Ordner im Windows-Explorer, um ihn extern zu kopieren. |
| <kbd>6</kbd> | **Auswahl der Oberflächensprache** | **SPRACHE WÄHLEN** | Schalten Sie die Sprache des Launchers sofort zwischen Englisch, Französisch, Spanisch und Deutsch um. |

---

## 3. Automatische Backup-Strategien & Aufbewahrung

Cadran stellt sicher, dass Ihre Finanzdaten stets geschützt sind:
- **Schnappschüsse bei Start und Beendigung**: Bei jedem Start des Supervisors und vor dem Schließen wird automatisch ein Backup erstellt.
- **Sicherungspunkte vor dem Import**: Bevor ein externer OFX- oder CSV-Kontoauszug verarbeitet wird, wird automatisch ein Rücksetzpunkt gespeichert.
- **Aufbewahrungsrichtlinie**: Cadran löscht alte Schnappschüsse automatisch nach Ihren gewählten Grenzen (z. B. die letzten 30 Schnappschüsse oder die letzten 90 Tage) und verhindert so eine Überfüllung des Datenträgers.

---

## 4. Schritt-für-Schritt-Anleitung

1. **Supervisor öffnen**: Doppelklicken Sie auf das Cadran-Symbol im Infobereich der Windows-Taskleiste (neben der Uhr).
2. **Manuelles Backup erstellen**: Wechseln Sie zum Reiter **Backups** (<kbd>1</kbd>) und klicken Sie auf **Backup jetzt erstellen** (<kbd>2</kbd>).
3. **Früheren Stand wiederherstellen**: Wählen Sie eine Backup-Zeile in der Liste (<kbd>4</kbd>) und klicken Sie auf **Ausgewähltes Backup wiederherstellen** (<kbd>3</kbd>).
4. **Backups auf externen Speicher exportieren**: Klicken Sie auf **Backup-Ordner öffnen** (<kbd>5</kbd>) und kopieren Sie die Dateien auf Ihr externes Laufwerk oder NAS.
