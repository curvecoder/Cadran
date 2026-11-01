# Benutzerhandbuch: Kontoauszug-Import (OFX & CSV)

[← Zurück: 19 - Wiederkehrende Buchungen & Rechnungen](19-recurring-transactions.md) | [Zurück zum Hauptindex](../README.md) | [Weiter: 21 - CSV-Importprofil-Generator →](21-import-mapping.md)

---

Mit dem **Kontoauszug-Import** laden Sie Buchungsverläufe, die Sie aus Ihrem Online-Banking exportiert haben, im Format Open Financial Exchange (`.ofx`, `.qfx`) oder als Textdatei mit Trennzeichen (`.csv`, `.tsv`, `.txt`). Er verhindert Duplikate automatisch und löst Ihre Kategorisierungsregeln aus.

---

## 1. Visuelle Übersicht & Aktionsmarkierungen

![Kontoauszug-Import & Upload](../../images/screens/20-statement-imports-screen-annotated.png)

---

## 2. Referenztabelle der Aktionen

| Markierung | Bedienelement | Aktionstyp | Handlungsanweisung |
| :---: | :--- | :---: | :--- |
| <kbd>1</kbd> | **Link „CSV-Profile konfigurieren"** | **HIER KLICKEN** | Öffnen Sie die Profilverwaltung, um die Spaltenzuordnung für Banken mit nicht standardisiertem Export anzupassen. |
| <kbd>2</kbd> | **Zielkonto** | **KONTO WÄHLEN** | Wählen Sie das Zielkonto (bei OFX-Dateien mit `<ACCTID>` erkennt Cadran es automatisch). |
| <kbd>3</kbd> | **Schaltfläche „Datei auswählen"** | **DATEI WÄHLEN** | Durchsuchen Sie Ihren Rechner und wählen Sie Ihre `.csv`- oder `.ofx`-Kontoauszugsdatei. |
| <kbd>4</kbd> | **CSV-Zuordnungsprofil** | **PROFIL WÄHLEN** | Wählen Sie ein gespeichertes Spaltenprofil (wird beim Hochladen von Standard-OFX/QFX-Dateien automatisch ignoriert). |
| <kbd>5</kbd> | **Schaltfläche „Import starten"** | **HIER KLICKEN** | Liest die hochgeladene Datei, prüft auf Duplikate, wendet Regeln an und importiert die Buchungen ins Journal. |
| <kbd>6</kbd> | **Protokoll der letzten Importe** | **VERLAUF PRÜFEN** | Sehen Sie frühere Importe mit Zeitstempel, Anzahl importierter Buchungen, Anzahl Duplikate und Quote der automatischen Kategorisierung. |

---

## 3. Duplikaterkennung & finanzielle Integrität

- **Eindeutige OFX-Kennungen**: OFX/QFX-Dateien enthalten native `<FITID>`-Kennungen. Cadran stellt sicher, dass identische Buchungen nie zweimal importiert werden.
- **CSV-Prüfsummen**: Bei CSV-Importen berechnet Cadran einen unveränderlichen Hash aus Datum, Betrag, Roh-Bezeichnung und Konto und filtert so bereits importierte Buchungen zuverlässig heraus.
- **Automatische Regelanwendung**: Sobald neue Buchungen gelesen werden, laufen die aktiven Kategorisierungsregeln sofort und ordnen die Ausgaben ein, noch bevor Sie das Journal öffnen.

---

## 4. Schritt-für-Schritt-Anleitung

1. **Zielkonto wählen**: Wählen Sie Ihr Giro- oder Sparkonto in der Auswahl (<kbd>2</kbd>).
2. **Kontoauszugsdatei wählen**: Klicken Sie auf **Datei auswählen** (<kbd>3</kbd>) und wählen Sie den exportierten Auszug.
3. **CSV-Zuordnung wählen (bei CSV)**: Wählen Sie das passende Bankprofil (<kbd>4</kbd>) oder belassen Sie die Vorgabe bei OFX.
4. **Import ausführen**: Klicken Sie auf **Import starten** (<kbd>5</kbd>).
5. **Ergebnis prüfen**: Sehen Sie sich das Zusammenfassungsbanner und den Protokolleintrag (<kbd>6</kbd>) an.
