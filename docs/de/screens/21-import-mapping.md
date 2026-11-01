# Benutzerhandbuch: CSV-Importprofil-Generator

[← Zurück: 20 - Kontoauszug-Import (OFX / CSV)](20-statement-imports.md) | [Zurück zum Hauptindex](../README.md) | [Weiter: 22 - Finanzberichte & Diagramme →](22-financial-reports.md)

---

Mit dem **CSV-Profil-Generator** ordnen Sie beliebige CSV-Spalten eines beliebigen Kreditinstituts (z. B. BNP Paribas, Crédit Agricole, Revolut, Chase) den zentralen Buchhaltungsfeldern von Cadran zu.

---

## 1. Visuelle Übersicht & Aktionsmarkierungen

![Generator für CSV-Zuordnungsprofile](../../images/screens/21-import-mapping-screen-annotated.png)

---

## 2. Referenztabelle der Aktionen

| Markierung | Bedienelement | Aktionstyp | Handlungsanweisung |
| :---: | :--- | :---: | :--- |
| <kbd>1</kbd> | **Schalter „Neues Profil"** | **HIER KLICKEN** | Blenden Sie das Formular ein, um ein neues CSV-Format zu konfigurieren. |
| <kbd>2</kbd> | **Eingabe des Profilnamens** | **HIER EINGEBEN** | Geben Sie dem Format einen erkennbaren Banknamen (z. B. *BoursoBank Standardexport*, *N26 Kontoauszug*). |
| <kbd>3</kbd> | **Spaltentrennzeichen** | **ZEICHEN EINGEBEN** | Geben Sie das Trennzeichen zwischen den Spalten an (meist `;`, `,` oder `\t`). |
| <kbd>4</kbd> | **Datumsformat** | **FORMAT EINGEBEN** | Geben Sie das in der CSV verwendete Datumsformat ein (z. B. `dd/MM/yyyy`, `yyyy-MM-dd` oder `MM/dd/yyyy`). |
| <kbd>5</kbd> | **Kontrollkästchen „Mit Kopfzeile"** | **KONTROLLKÄSTCHEN UMSCHALTEN** | Aktivieren Sie es, wenn die erste Zeile Spaltenüberschriften enthält, damit Cadran sie beim Lesen überspringt. |
| <kbd>6</kbd> | **Spaltenindizes** | **SPALTENNUMMERN FESTLEGEN** | Geben Sie die 0-basierten Spaltenindizes für Datum (0), Bezeichnung (1) und Betrag (2) ein. |
| <kbd>7</kbd> | **Schaltfläche „Profil speichern"** | **HIER KLICKEN** | Speichern Sie das Profil. Es erscheint anschließend in der Auswahl des Kontoauszug-Imports. |

---

## 3. 0-basierte Spaltenindizes verstehen

In einer Tabellenkalkulation oder CSV-Datei gilt:
- Spalte A = Index **0**
- Spalte B = Index **1**
- Spalte C = Index **2**
- Spalte D = Index **3**

Verwendet Ihre Bank getrennte Spalten für Soll und Haben statt einer einzigen Betragsspalte mit Vorzeichen, lassen Sie das Betragsfeld leer und geben Sie die Indizes der Soll- und Haben-Spalte an.

---

## 4. Schritt-für-Schritt-Anleitung

1. **Generator öffnen**: Klicken Sie auf **Neues Profil** (<kbd>1</kbd>).
2. **Bankprofil benennen**: Tragen Sie den Namen des Instituts in Feld (<kbd>2</kbd>) ein.
3. **Trennzeichen und Datumsformat festlegen**: Geben Sie das Trennzeichen (<kbd>3</kbd>) und die passende Datumssyntax (<kbd>4</kbd>) ein.
4. **Spalten zuordnen**: Öffnen Sie Ihre Bank-CSV in Excel oder im Editor und tragen Sie die Spaltenindizes (<kbd>6</kbd>) ein.
5. **Speichern**: Klicken Sie auf **Profil speichern** (<kbd>7</kbd>).
