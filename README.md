# 🛒 TechStore – C# OOP Online-Shop Checkout

Ein objektorientiertes Konsolenprojekt in **C# (.NET)**, das den Bestell- und Bezahlvorgang eines Online-Shops abbildet. Fokus dieses Projekts ist die saubere Anwendung der vier Grundprinzipien der Objektorientierten Programmierung (OOP) sowie eine erweiterbare Software-Architektur.

---

## ✨ Features

* **Produkthierarchie (Physisch & Digital):**
  * **Physische Produkte** verwalten ihren Lagerbestand, besitzen ein Gewicht und berechnen Versandkosten (kostenloser Versand ab 500 € Warenwert).
  * **Digitale Produkte** (z. B. Software-Lizenzen) sind unbegrenzt verfügbar, versandkostenfrei und liefern nach erfolgreichem Kauf direkt einen Download-Link aus.
* **Warenkorb-Verwaltung:** Prüft bereits beim Hinzufügen die Verfügbarkeit der Artikel und berechnet Zwischensumme sowie Gesamtversandkosten.
* **Flexibles Rabatt-System:** Unterstützt austauschbare Rabattstrategien (z. B. prozentuale Gutscheine).
* **Zahlungsabwicklung & Transaktionssicherheit:** Prüft Zahlungslimits vor Abschluss. Schlägt die Zahlung fehl, bleibt der Lagerbestand unverändert.

---

## 🏗️ Verwendete OOP-Konzepte

| Konzept | Umsetzung im Projekt |
| :--- | :--- |
| **Kapselung** | `Lagerbestand` und `Limit` sind über `private set` geschützt und nur über validierte Methoden (`BestandReduzieren`, `Bezahlen`) änderbar. |
| **Abstraktion & Vererbung** | `Produkt` ist eine `abstract class`, von der `PhysischesProdukt` und `DigitalesProdukt` erben. |
| **Polymorphie** | `Warenkorb` und `Kasse` rufen `IstVerfuegbar()`, `BerechneVersandkosten()` und `BestandReduzieren()` auf, ohne den konkreten Produkttyp zu kennen. |
| **Interfaces (Loose Coupling)** | `IRabatt` und `IZahlungsmethode` entkoppeln die `Kasse` von konkreten Gutschein- und Zahlungsarten. |
| **Komposition** | Ein `Warenkorb` verwaltet eine gekapselte Liste von `WarenkorbPosition`-Objekten. |

---

## 📂 Projektstruktur

* `Produkt.cs` – Abstrakte Basisklasse für alle Shop-Artikel
* `PhysischesProdukt.cs` – Artikel mit Lagerbestand, Gewicht und Versandlogik
* `DigitalesProdukt.cs` – Digitale Artikel mit Download-Link
* `Warenkorb.cs` & `WarenkorbPosition.cs` – Verwaltung der gewählten Artikel und Summenberechnung
* `IRabatt.cs` & `ProzentGutschein.cs` – Interface und Implementierung für Rabatte
* `IZahlungsmethode.cs` & `Kreditkarte.cs` – Interface und Implementierung für Zahlungen
* `Kasse.cs` – Steuert den gesamten Checkout-Prozess
* `Program.cs` – Einstiegspunkt mit Test-Szenarien (fehlgeschlagene & erfolgreiche Zahlung)

---

## 🚀 Projekt lokal starten

1. Repository klonen:
   ```bash
   git clone https://github.com
   ```
2. Projekt in **Visual Studio** öffnen (`Onlishop.slnx` / `.csproj`) und mit **`F5`** starten.

---

## 🖥️ Beispiel-Ausgabe

```text
Zwischensumme: 1.385,00 €
Warenwert: 1.385,00 € | Versand: 4,99 € | Gesamt (nach Rabatt): 1.251,49 €
Kreditkarte (1111-2222): Zahlung über 1.251,49 € abgelehnt (Limit: 800,00 €).
Bestellung abgebrochen: Zahlung fehlgeschlagen!

Laptop-Bestand nach Fehlversuch: 2
Warenwert: 1.385,00 € | Versand: 4,99 € | Gesamt (nach Rabatt): 1.251,49 €
Kreditkarte (3333-4444): 1.251,49 € bezahlt. Verbleibendes Limit: 248,51 €.
 -> Download bereit für 'Windows 11 Pro Lizenz': https://techstore.de
Bestellung erfolgreich!

Laptop-Bestand nach Kauf: 1
```

---

## 🔮 Geplante Erweiterungen

* [ ] Bestellhistorie mit automatischer Rechnungsnummer (`BestellBeleg`)
* [ ] Dauerhafte Speicherung von Produkten und Bestellungen als JSON-Datei
* [ ] Interaktives Konsolen-Menü für Benutzereingaben
