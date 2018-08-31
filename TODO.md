# TODO:
Kada uzmete da odradite neki zadatak, dodajte svoje ime na kraju zadatka kako biste obelezili da je u izradi, da ne bismo radili iste zadatke. 
Odradjeni zadatak prebaciti u DONE sekciju na dnu fajla!
---------------------------------------------------
## Mehanika:
### Karakter:
* Zivot i gubitak zivota pri sudaru sa preprekom
* Skok (igrac skace do centra cevi i pada nazad na tacku sa koje je skocio)
* Neunistivi mod
### Pickup:
* Dodatni zivot
* Poeni, sakupljanje i brojanje
* Generisanje pickup-ova
### Prepreke:
* Oduzimaju zivot
* Generisanje prepreka
---------------------------------------------------
## UI:
* Prikaz trenutnog broja zivota
* Animacija gubitka zivota
* Animacija dobitka zivota
* Prikaz broja sakupljenih poena
* Animacija sakupljanja poena
---------------------------------------------------
## Modeli:
### Karakter:
* Kornjaca 
* Zec
* Ptica
### Pickup:
* Dodatni zivot (hrana za zivotinju)
### Prepreke:
* Panj
* Zbun
* Kamen
* Oboreno stablo
---------------------------------------------------
## Animacija:
* Kretanje zeca (trcanje)
---------------------------------------------------
---------------------------------------------------
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
* Igrac je zivotinja koja menja oblik u zavisonsti od trenutnog nivoa. Promenom oblika zivotinja se drugacije krece: 
1. Jaje, kornjaca - ide levo-desno
2. Zec - ide levo-desno i moze da skoci na swipe
3. Ptica se krece gore-dole-levo-desno kroz vazduh, nevezano od cevi(okruzenja)

* Kretanje kornjace
---------------------------------------------------
## Osvetljenje:
* Uskladjeno sa temom i dizajnom nivoa (ovo uraditi kada budemo imali ceo nivo)
---------------------------------------------------
## Muzika:
* Neka muzika za opustanje, uskladjena sa dizajnom nivoa (ovo uraditi kada budemo imali ceo nivo)
---------------------------------------------------
---------------------------------------------------
# DONE:
---------------------------------------------------
## Mehanika:
* Kruzno kretanje oko ivice cevi
* Skok na drugu stranu cevi
* Generisanje krivudave cevi
---------------------------------------------------
## Modeli:

---------------------------------------------------
## Animacija:

---------------------------------------------------
## Muzika:

---------------------------------------------------
