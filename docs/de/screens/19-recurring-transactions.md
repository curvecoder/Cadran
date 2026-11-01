# Benutzerhandbuch: Wiederkehrende Buchungen & Rechnungsplan

[← Zurück: 18 - Automatische Regel-Engine](18-rules-engine.md) | [Zurück zum Hauptindex](../README.md) | [Weiter: 20 - Kontoauszug-Import (OFX / CSV) →](20-statement-imports.md)

---

Der **Plan der wiederkehrenden Ausgaben** erfasst Ihre festen Monatsbelastungen, Abonnements, Nebenkostenrechnungen und Kreditraten. Er zeigt in Echtzeit, was im laufenden Monat bereits beglichen ist und was noch aussteht, und berechnet Ihr tatsächlich frei verfügbares Budget („reste à vivre").

---

## 1. Visuelle Übersicht & Aktionsmarkierungen

![Wiederkehrende Ausgaben & frei verfügbares Budget](../../images/screens/19-recurring-transactions-screen-annotated.png)

---

## 2. Referenztabelle der Aktionen

| Markierung | Bedienelement | Aktionstyp | Handlungsanweisung |
| :---: | :--- | :---: | :--- |
| <kbd>1</kbd> | **Monatsnavigation** | **PFEILE KLICKEN** | Wechseln Sie zwischen vergangenen, aktuellen und kommenden Kalendermonaten. |
| <kbd>2</kbd> | **Schaltfläche „Neue Ausgabe"** | **HIER KLICKEN** | Öffnen Sie den Dialog, um ein wiederkehrendes Abonnement, eine Miete oder eine geplante Rechnung anzulegen. |
| <kbd>3</kbd> | **KPI-Karte „Gesamt erwartet"** | **FINANZÜBERSICHT** | Gesamtes budgetiertes Volumen aller wiederkehrenden Verpflichtungen des gewählten Monats. |
| <kbd>4</kbd> | **Karte „Gesamt abgebucht" mit Fortschritt** | **FORTSCHRITTSANZEIGE** | Zeigt den beglichenen Betrag und den prozentualen Fortschritt der bisher abgebuchten wiederkehrenden Rechnungen. |
| <kbd>5</kbd> | **KPI-Karte „Gesamt ausstehend"** | **FINANZÜBERSICHT** | Summe der Verpflichtungen, die bis Monatsende noch beglichen werden müssen. |
| <kbd>6</kbd> | **KPI-Karte „Noch verfügbar"** | **FREI VERFÜGBARES BUDGET** | Verbleibende Mittel nach Abzug aller festen Monatsverpflichtungen von Ihrem Einkommen. |
| <kbd>7</kbd> | **Zeile einer wiederkehrenden Ausgabe** | **PRÜFEN / BEARBEITEN** | Zeigt Rechnungsname, erwarteten Betrag, Zahlungsdatum, Abgleichstatus und Bearbeitungssteuerung. |

---

## 3. Automatischer Abgleich & Erkennung

- **Mustererkennung**: Jede wiederkehrende Belastung enthält ein Stichwortmuster (etwa `IMMOBILIER PARIS` oder `EDF`). Beim Import von Kontoauszügen ordnet Cadran passende Bankbelastungen automatisch zu und setzt den Status von *Ausstehend* auf *Abgebucht*.
- **Kandidatenvorschläge**: Cadran durchsucht Ihren Buchungsverlauf nach regelmäßigen Rechnungen und schlägt vor, sie mit einem Klick als wiederkehrende Ausgaben zu übernehmen.

---

## 4. Schritt-für-Schritt-Anleitung

1. **Verpflichtungen des aktuellen Monats prüfen**: Sehen Sie sich die KPI-Karten (<kbd>3</kbd>, <kbd>4</kbd>, <kbd>5</kbd>) an, um beglichene und ausstehende Abbuchungen zu vergleichen.
2. **Neues Abonnement hinzufügen**: Klicken Sie auf **Neue Ausgabe** (<kbd>2</kbd>) und legen Sie Tag im Monat, Betrag und Kategorie fest.
3. **Monate wechseln**: Nutzen Sie die Kalenderpfeile (<kbd>1</kbd>), um künftige Monatsbudgets zu planen oder vergangene Monate einzusehen.
4. **Verfügbares Budget im Blick behalten**: Die Karte **Noch verfügbar** (<kbd>6</kbd>) zeigt Ihnen Ihre sichere Ausgabengrenze.
