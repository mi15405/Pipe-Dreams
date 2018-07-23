# Pipe-Dreams
## Ideje:
* Y position Ball - mora da bude (-3 do -5) da bi mogao player sa manjim ekranom da je vidi na ekranu u svakom trenutku(makar polovicno)
broji pokupljene Spawner Pickupe
* Posle odredjenog broja izlaze veci obstacale(kao tezi nivoi).
* Trenutni swipe je prakticno "cheat" jer onda nema potrebe da se toliko koristi levo/desno kad mozes uvek da ih preskocis, zato predlazem sledece:

* Umesto Pickup prefaba, nakon odredjenog vremenskog intervala se pojavljuje life ball i vakum ball
* Life ball dodaje jedan zivot(imamo nekoliko- kraj igre kad nema vise zivota)
* Vakum ball kad se pokupi radi sledece: ulazi se u stanje vakuma(centralna pozicija i pomera se swipeom u vakum prostoru) traje nekoliko sekundi(10-30), sto znaci da za to vreme ne mogu da te udare prepreke(obstacles) koje su na cevi. U vakum prostoru se pojavljuju specijalni Pickupi(koji donose vise poena) ali i prepreke koje nisu preteske.
* U non-vakum modu(normalnom modu) umesto pickup i life spawnera, ponekad se pojavljuje i death spawner koji oduzima zivot.Takodje treba invincible spawner, u cijem modu u odredjenom vremenskom intervalu, player ne moze biti unisten preprekama(niti bilo kako).
------------------------------------------------------------
