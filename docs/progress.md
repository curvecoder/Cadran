# Progression — Fluxa (Cadran)
Mis à jour : 11/11/2026. Note condensée : le détail des lots passés est dans `git log` (commits `1c88870` à `645f18b`).

## État
- `main` poussé jusqu'à `645f18b` ; dernier tag publié `v1.3.5`. Depuis : un `docs:` (guides allemands 12 à 25), un `perf:` (filtre SQL de `CategorySeedService.LoadCategoryTranslationsAsync`) et, **non poussé**, `0d68d8f` `fix:` (tolérance des charges récurrentes postée dans la culture du serveur : l'édition était invalide et rien n'était enregistré).
- `verify.ps1` : 38 + 784 + 59 E2E verts, QUALITY GATE PASSED. Aucune fiche de délégation ouverte.
- **Reste à faire** : la page `/Recurring` n'affiche aucune erreur de validation quand `ModelState` est invalide (ajouter un `ValidationSummary`, à valider avec l'utilisateur). Release 1.3.6 (PATCH) possible sur accord de l'utilisateur (`/github-release`) ; ni tag, ni push, ni publication sans accord.

## Acquis majeurs (résumé)
- Harnais qualité complet (lot 1) : SonarAnalyzer partout, règles de culture/comparaison, MA0004 (sauf `tests/**`), MA0051 (sauf `tests/**` ; `OnModelCreating` et les longues méthodes découpées en composants métier), scans masquage / `!` / recopies.
- Assainissement des règles d'or : constructeurs primaires, annulation et catch typés, `TimeProvider` injecté, E2E de chargement des pages (15 sur 17 ; `UnlockDatabase` et `LoginWith2fa` écartées et justifiées).
- Fonctionnalité saisie manuelle et rapprochement (lots 1 à 7) : `TransactionOrigin`, `ManualTransactionService`, `ManualEntryMatchFinder`/`Loader`, `ManualEntryMerger`, page `/Accounts/Reconcile`, badge à l'import, guide 25.
- Correctifs 1.3.x : verrou de migration orphelin, `--urls` prioritaire, cookie de langue en HTTP, déconnexion (POST seul, reverrouillage de la base), boucle d'URL sur base verrouillée (`/Error`, validation du cookie), fixture E2E qui écrivait dans `bin/.../data/cadran.db` (corrigée par `UseSetting`, gardée par `TestDatabaseIsolationTests` ; si un dossier `data/` réapparaît dans `bin`, la régression est là).
- Distribution : zip Windows et tar.gz Linux seulement (pas d'exe ni de binaire Linux autonomes).

## Décisions
- Aucun `git push`, tag ni publication GitHub sans accord explicite.
- MA0004 et MA0051 exclus pour `tests/**` (xUnit1030 interdit `ConfigureAwait(false)` dans les tests).
- Documentation : `docs/` en anglais avec `docs/fr/`, `docs/de/` (guides 1 à 25 complets), `README.*` en, fr, es, de.

## Points d'attention
- `./verify.ps1` : `powershell.exe -NoProfile -ExecutionPolicy Bypass -File ./verify.ps1` (pas de `pwsh`), ≈ 3 min ; ne pas modifier de fichier pendant son exécution.
- Sortie du build en français avec espaces insécables : en tenir compte dans les regex.
- Dépôt en LF (`core.autocrlf=true`) mais certains fichiers de test sont en CRLF : conserver la fin de ligne de chaque fichier ; pour un fichier CRLF, éviter `Edit` multi-lignes (préférer un nouveau fichier ou `sed`).
- Toujours lire un fichier de test avant de l'écrire (un `Write` a déjà écrasé des tests existants).
- Un champ d'une classe à constructeur primaire ne peut pas référencer un autre champ d'instance (CS0236) ; CS9107 interdit de capturer `timeProvider` dans une classe dérivée qui le passe à la base (utiliser `LocalToday` de `TransactionOperationsPageModelBase`).
- Le jeton Sonar est un jeton d'analyse : `measures/component_tree` est refusé, `issues/search` fonctionne.
- Aucun nom de domaine privé ni IP interne dans le dépôt (hook `pre-push`).
- Le tag `v1.3.0` pointe sur `bdcf930` : ne pas le déplacer.
- Guides allemands vérifiés pour les liens et images seulement, pas relus par un germanophone.
- Les formulaires qui postent un décimal avec un point (`<option value="0.05">`) sont rejetés par le binding en culture `fr` : écrire la valeur avec `CultureInfo.CurrentCulture`. Les `<input type="number">` ne sont pas concernés.
