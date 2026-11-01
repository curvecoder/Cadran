# Benutzerhandbuch: Split-Buchungen mit mehreren Kategorien

[← Zurück: 13 - Buchung bearbeiten](13-edit-transaction.md) | [Zurück zum Hauptindex](../README.md) | [Weiter: 15 - Sammelabstimmung & Stapelaktionen →](15-batch-actions.md)

---

Mit dem **Split-Manager** teilen Sie einen einzelnen Beleg oder eine einzelne Belastung auf mehrere Kategorien und Händler auf (zum Beispiel ein Supermarktbeleg, der sowohl Lebensmittel als auch Haushaltsbedarf umfasst).

---

## 1. Visuelle Übersicht & Aktionsmarkierungen

![Modal zur Aufteilung einer Buchung](../../images/screens/14-split-transaction-screen-annotated.png)

---

## 2. Referenztabelle der Aktionen

| Markierung | Bedienelement | Aktionstyp | Handlungsanweisung |
| :---: | :--- | :---: | :--- |
| <kbd>1</kbd> | **Gesamtbetrag der Buchung** | **NUR ANZEIGE** | Zeigt den vollen Buchungsbetrag, den die Summe der Teilbeträge exakt erreichen muss. |
| <kbd>2</kbd> | **Badge für den Restbetrag** | **STATUSANZEIGE** | Zeigt den noch nicht zugeordneten Betrag. Es wird grün, sobald die Zuordnung bei null aufgeht. |
| <kbd>3</kbd> | **Eingabe des Teilbetrags** | **BETRAG EINGEBEN** | Geben Sie den genauen Betrag ein, der dieser Teilzeile zugeordnet wird. |
| <kbd>4</kbd> | **Kategorieauswahl der Teilzeile** | **OPTION WÄHLEN** | Wählen Sie die Zielkategorie für diesen Teil der Ausgabe. |
| <kbd>5</kbd> | **Schaltfläche „Teilzeile hinzufügen"** | **HIER KLICKEN** | Fügen Sie eine weitere Zeile hinzu, um die Ausgabe auf mehr Kategorien zu verteilen. |
| <kbd>6</kbd> | **Schaltfläche „Aufteilung speichern"** | **HIER KLICKEN** | Speichern Sie die Aufteilung. Aktiv nur, wenn der Restbetrag genau 0,00 beträgt. |

---

## 3. Finanzielle Integrität & Nullsummen-Invariante

Cadran erzwingt eine strenge buchhalterische Integrität:
- Eine Split-Buchung kann nicht gespeichert werden, solange ein Restbetrag offen ist.
- Die Summe aller Teilzeilen muss dem Betrag der ursprünglichen Bankbuchung entsprechen.
- In Berichten und Budgets wird die Hauptbuchung durch ihre Teilzeilen ersetzt, damit die Kategoriediagramme die tatsächlichen Ausgaben zeigen.

---

## 4. Schritt-für-Schritt-Anleitung

1. **Split-Manager öffnen**: Klicken Sie auf das Split-Symbol in der Buchungszeile oder wählen Sie *Aufteilen* in den Buchungsoptionen.
2. **Betrag der ersten Zeile festlegen**: Geben Sie den Betrag des ersten Postens ein (<kbd>3</kbd>) und wählen Sie seine Kategorie (<kbd>4</kbd>).
3. **Weitere Teile hinzufügen**: Klicken Sie auf **Teilzeile hinzufügen** (<kbd>5</kbd>), um einen weiteren Posten einzufügen.
4. **Rest ausgleichen**: Prüfen Sie, dass der Indikator **Restbetrag** (<kbd>2</kbd>) `0,00 €` in Grün anzeigt.
5. **Speichern**: Klicken Sie auf **Aufteilung speichern** (<kbd>6</kbd>), um abzuschließen.
