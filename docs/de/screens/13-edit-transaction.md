# Benutzerhandbuch: Buchung bearbeiten & Klassifizierungsdetails

[← Zurück: 12 - Einheitliches Buchungsjournal](12-transactions-ledger.md) | [Zurück zum Hauptindex](../README.md) | [Weiter: 14 - Split-Buchungen →](14-split-transaction.md)

---

Im **Modal zum Bearbeiten einer Buchung** verfeinern Sie die Metadaten einer Buchung, verknüpfen erkannte Händler, hinterlegen eigene Buchhaltungsnotizen und ordnen Ausgaben individuellen Budgetzeiträumen zu.

---

## 1. Visuelle Übersicht & Aktionsmarkierungen

![Modal zum Bearbeiten einer Buchung](../../images/screens/13-edit-transaction-screen-annotated.png)

---

## 2. Referenztabelle der Aktionen

| Markierung | Bedienelement | Aktionstyp | Handlungsanweisung |
| :---: | :--- | :---: | :--- |
| <kbd>1</kbd> | **Händlersuche / -eingabe** | **EINGEBEN / WÄHLEN** | Suchen Sie einen vorhandenen Händler oder geben Sie einen neuen Firmennamen ein, um ihn mit der Buchung zu verknüpfen. |
| <kbd>2</kbd> | **Persönliche Notizen & Memo** | **HIER EINGEBEN** | Fügen Sie Freitext, Belegreferenzen oder interne Notizen zum Kauf hinzu. |
| <kbd>3</kbd> | **Kategoriebaum** | **ZUM AUFKLAPPEN KLICKEN** | Durchsuchen Sie den hierarchischen Kategoriebaum oder suchen Sie per Stichwort, um die genaue Kategorie zu wählen. |
| <kbd>4</kbd> | **Abweichendes Budgetdatum** | **DATUM WÄHLEN** | Überschreiben Sie das wirksame Budgetdatum, wenn eine spät im Monat bezahlte Ausgabe zum nächsten Budget gehört. |
| <kbd>5</kbd> | **Auswahl eines benutzerdefinierten Status** | **STATUS WÄHLEN** | Wählen Sie einen benutzerdefinierten Abstimmungsstatus, falls in Ihren Einstellungen konfiguriert. |
| <kbd>6</kbd> | **Kontrollkästchen „Auf ähnliche anwenden"** | **KONTROLLKÄSTCHEN UMSCHALTEN** | Aktivieren Sie es, um Kategorie und Händler automatisch bei allen ähnlichen vergangenen und künftigen Buchungen zu übernehmen. |
| <kbd>7</kbd> | **Schaltfläche „Änderungen speichern"** | **HIER KLICKEN** | Speichern Sie die Änderungen und aktualisieren Sie das Journal sofort. |

---

## 3. Übernahme & automatische Kategorisierung

Wenn Sie **Auf ähnliche anwenden** (<kbd>6</kbd>) aktivieren:
- Die Anwendung erkennt alle weiteren unkategorisierten Buchungen mit derselben normalisierten Händlerbezeichnung.
- Die gewählte Kategorie und die Händlerverknüpfung werden rückwirkend und künftig angewendet. Das spart Zeit bei wiederkehrenden Ausgaben wie Abonnements, Nebenkosten und Supermärkten.

---

## 4. Schritt-für-Schritt-Anleitung

1. **Editor öffnen**: Klicken Sie im Journal auf die Kategoriespalte einer beliebigen Buchung.
2. **Händler zuweisen**: Geben Sie den Namen des Geschäfts oder Anbieters in Feld (<kbd>1</kbd>) ein.
3. **Kategorie wählen**: Filtern Sie im Baum (<kbd>3</kbd>) und wählen Sie die Zielkategorie.
4. **Notizen & Budgetdatum ergänzen**: Passen Sie optional das Budgetdatum (<kbd>4</kbd>) an oder fügen Sie Notizen hinzu (<kbd>2</kbd>).
5. **Auf ähnliche anwenden**: Aktivieren Sie (<kbd>6</kbd>), um die Einordnung auf alle identischen Buchungen zu übertragen.
6. **Speichern**: Klicken Sie auf **Änderungen speichern** (<kbd>7</kbd>).
