# Benutzerhandbuch: Automatische Regel-Engine zur Kategorisierung

[← Zurück: 17 - Kategorien erstellen & bearbeiten](17-create-category.md) | [Zurück zum Hauptindex](../README.md) | [Weiter: 19 - Wiederkehrende Buchungen & Rechnungen →](19-recurring-transactions.md)

---

Die **Regel-Engine** automatisiert die Kategorisierung von Buchungen und die Verknüpfung mit Händlern. Beim Import von Kontoauszügen oder bei der Erfassung von Buchungen wertet Cadran Ihre aktiven Regeln in Prioritätsreihenfolge aus und weist Kategorien und Zahlungsempfänger automatisch zu.

---

## 1. Visuelle Übersicht & Aktionsmarkierungen

![Regel-Engine & Mustereditor](../../images/screens/18-rules-engine-screen-annotated.png)

---

## 2. Referenztabelle der Aktionen

| Markierung | Bedienelement | Aktionstyp | Handlungsanweisung |
| :---: | :--- | :---: | :--- |
| <kbd>1</kbd> | **Schalter „Regel hinzufügen"** | **HIER KLICKEN** | Blenden Sie das Formular ein, um eine neue Regel zur automatischen Kategorisierung zu konfigurieren. |
| <kbd>2</kbd> | **Schaltfläche „Auf bestehende anwenden"** | **HIER KLICKEN** | Wenden Sie alle aktiven Kategorisierungsregeln rückwirkend auf alle bisher unkategorisierten Buchungen an. |
| <kbd>3</kbd> | **Eingabe des Regelnamens** | **HIER EINGEBEN** | Geben Sie der Regel einen klaren Namen (z. B. *Supermarkt-Einkäufe*, *Stromrechnungen*). |
| <kbd>4</kbd> | **Auswahl der zugewiesenen Kategorie** | **OPTION WÄHLEN** | Wählen Sie die Zielkategorie, die automatisch angewendet wird, sobald die Regel zutrifft. |
| <kbd>5</kbd> | **Suchbegriffe & Platzhalter** | **HIER EINGEBEN** | Geben Sie den zu erkennenden Text ein (z. B. `CARREFOUR*` oder `EDF`). Die Platzhalter `*` und `%` werden unterstützt. |
| <kbd>6</kbd> | **Live-Test mit Kontoauszugstext** | **BEISPIEL TESTEN** | Fügen Sie eine Beispielbezeichnung aus Ihrem Kontoauszug ein, um zu prüfen, ob die Regel greift. |
| <kbd>7</kbd> | **Schaltfläche „Regel erstellen"** | **HIER KLICKEN** | Speichern Sie die Regel und fügen Sie sie der Liste der aktiven Regeln hinzu. |

---

## 3. Übereinstimmungsbedingungen & Regelpriorität

- **Enthält**: Trifft zu, wenn die Suchbegriffe irgendwo in der Roh-Beschreibung der Bank vorkommen.
- **Beginnt mit / Endet mit**: Trifft zu, wenn der Suchbegriff am Anfang oder am Ende des Auszugstextes steht.
- **Platzhalter**: `*` oder `%` ersetzt beliebigen Text (z. B. `AMAZON*PRIME`).
- **Priorität**: Regeln werden von der kleinsten Nummer (1 = höchste Priorität) bis zur größten ausgewertet. Sobald eine Regel mit höherer Priorität zutrifft, endet die Verarbeitung dieser Buchung.

---

## 4. Schritt-für-Schritt-Anleitung

1. **Regelersteller öffnen**: Klicken Sie auf **Regel hinzufügen** (<kbd>1</kbd>).
2. **Name und Zielkategorie festlegen**: Geben Sie eine Beschreibung ein (<kbd>3</kbd>) und wählen Sie die Zielkategorie (<kbd>4</kbd>).
3. **Suchbegriffe definieren**: Tragen Sie die Händlerkennung oder das Platzhaltermuster in Feld (<kbd>5</kbd>) ein.
4. **Muster testen**: Fügen Sie eine echte Auszugsbezeichnung in Feld (<kbd>6</kbd>) ein, um die sofortige Übereinstimmung zu bestätigen.
5. **Regel speichern**: Klicken Sie auf **Regel erstellen** (<kbd>7</kbd>).
6. **Rückwirkende Klassifizierung**: Klicken Sie auf **Regeln anwenden** (<kbd>2</kbd>), um alle bisherigen passenden Buchungen gesammelt zu kategorisieren.
