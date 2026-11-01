# Guide Utilisateur : Rapprocher les Saisies Manuelles

[← Précédent : 24 - Lanceur Windows Tray & Sauvegardes](24-backups-supervision.md) | [← Retour à l'Index Général](../README.md)

---

Une **saisie manuelle** est une opération que vous avez tapée vous-même, par exemple un paiement effectué avant la disponibilité du relevé bancaire. Une fois le relevé importé, la page **Rapprocher les saisies manuelles** associe chaque saisie à l'opération importée correspondante, afin qu'il ne reste que l'opération importée.

---

## 1. Vue d'Ensemble & Repères Visuels

![Rapprocher les saisies manuelles](../images/screens/25-manual-reconciliation-screen-annotated.png)

*Capture en anglais ; les libellés de l'interface suivent la langue choisie.*

---

## 2. Tableau de Référence des Actions

| Repère | Élément | Type d'action | Que faire |
| :---: | :--- | :---: | :--- |
| <kbd>1</kbd> | **Saisie manuelle** | **VÉRIFIER** | L'opération que vous avez saisie, avec sa date. |
| <kbd>2</kbd> | **Opération importée** | **VÉRIFIER** | L'opération importée proposée comme correspondance, avec sa date et son compte. |
| <kbd>3</kbd> | **Bouton « Fusionner »** | **CLIQUER ICI** | Fusionner la paire : l'opération importée est conservée et la saisie manuelle est supprimée. |

---

## 3. Comment les Paires sont Proposées

- Une paire exige le même compte, le même type (débit ou crédit) et le même montant.
- Les deux dates doivent être séparées d'au plus la tolérance de doublons configurée pour les imports.
- Chaque saisie est associée à une seule opération importée. Les libellés ne servent qu'à départager plusieurs candidates.

---

## 4. Ce que Fait une Fusion

- L'opération importée prévaut toujours. Elle reçoit la catégorie, le commerçant, la date budgétaire, le statut personnalisé et les notes de la saisie **seulement là où ses propres champs sont vides**.
- La ventilation de la saisie est reportée sur l'opération importée si celle-ci n'en a pas.
- La saisie manuelle est ensuite supprimée.

---

## 5. Instructions Pas à Pas

1. **Créez une saisie manuelle** avec le bouton **Nouvelle opération** du registre des transactions ; les saisies portent un badge *Manuelle* et s'isolent avec le filtre **Origine**.
2. **Importez votre relevé** (voir [20 - Import de Relevés](20-statement-imports.md)). Lorsque des saisies correspondent, un badge du résultat d'import renvoie vers cette page.
3. **Ouvrez la page** depuis le registre ou ce badge et comparez chaque paire (<kbd>1</kbd>, <kbd>2</kbd>).
4. **Fusionnez** les paires correctes (<kbd>3</kbd>).
