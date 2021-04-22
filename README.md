# HSP-SoSe-2021

	TO-DO Liste
	https://hsp-teamh.atlassian.net/jira/software/projects/SCHRAUBE/boards/1

- Material als Klasse ( vielleicht im nächsten Testat)
- Kopfhöhe {get; set;} Kopfhöhe ist DIN, tabellenwerte zu der jeweiligen Schlüsselweite benutzen
- getVolumen
- getPreis

	Problem:

- Volumen ist schwerer als gedacht. Jeder Kopf hat ein anderes Volumen.

	Fragen an Kunde:
-Welches Spektrum der Schrauben,Materialien usw. (DIN?)
-Evtl. Festigkeitsberechnung
-Festigkeitsklassen ausgeben?
-Weitere Berechnungen?
-Vorstellung für GUI? (Interaktiv, Graphisch , Simpel, Bunt, weitumgreifend) 


	Verbesserungen für nächsten Sprint:
- Trim().ToLower(). --> Benutzerfreundlichkeit
- Material als Klasse
- Volumen fertigstellen
- Preis
- Exception (für Convert)


Hallo Leute,

schreibt einfach hier mal kurz rein was ihr geändert habt und wie man evtl. weiter machen könnte. (Mit Datum)
Bitte den Code immer mit Kommentaren versehen! :)

Note: Erste Woche wurde von jedem genutzt, um sich individuell mit C# vertraut zu machen

Daniel 08.04 
Ich habe eine Klasse "Schraubendefinition" erstellt.
Diese hat bisher die Eigenschaft Material, welches nur übergeben wird. 
Es gibt noch die Eigenschaft getDichte, da wird jedem Material eine jeweilige Dichte hinzugefügt.
Wenn jemand weiter machen will, kann er z.B mehr Materialien hinzufügen (Messing usw.), oder 
sonst kann man auch schon weitere Eigenschaften mitgeben (Länge, Gewinde,Nenndurchmesser usw.)

Marvin 09.04
Ich habe basierend auf Daniels Schraubendefinition einen weiteren Zweig eingefügt. Das metrische Gewinde M1 bis M42.
Bei Eingabe wird automatisch der Nenndurchmesser angegeben. Nächster Schritt, den ich noch nicht gemacht habe ist die Berechnungen von 
z.B. Flankendurchmesser, Kerndurchmesser usw.

Marvin 10.04
Lediglich Zeilen der Ausgabefunktion getauscht.

Marvin 11.04
Materialien Messing und Kupfer hinzugefügt. Steigung, Flankendurchmesser, Kerndurchmesser und so ergänzt. Ausgabe hat aber einen Defekt. 
Es werden nicht Steigung Flankendurchmesser oder so ausgegeben. Habe wohl etwas wichtiges übersehen, weiß nur nicht was

Daniel 11.04 
Ich hab Marvins Problem beseitig, und den Code etwas umgeformt. Ich hab ausßerdem noch ein paar Kommentare weggenommen, weil es so langsam unübersichtlich wurde.
Ich hab noch experimentell eine Methode "Ausgabe" geschrieben, welche die Main Methode etwas entlasten soll, weiß aber nicht ob wir da beibehalten sollten.

Marvin 11.04 Abends
Schraubenart eingefügt mit Daniel per Discord. Metrisch läuft, anderes kommt morgen

Edis 12.04
Sschraubenkopf eingeführt 

Daniel 13.4
Rekursion für Materialabfrage eingebaut.
Struktur geändert, Methode eingfügt ( MaterialAbfrage() ) 

Edis 13.04

Schlüsselweite bzw. Größe der Innensechskant hinzugefügt. Variable Durchmesser eingetragen.

Daniel 14.4

Ich habe ein Array eingefügt und werde das bei Zeit vervollständigen. Ich will nicht mehr switch Case benutzen, weil das nicht so schön ist. Am besten ist es einfach 
Arrays zu erstellen aus denen wir dann Werte entnehmen können, und damit weiter rechnen können.
Das Array könnt ihr noch ignorieren. Das wird erst wichtig wenn ich soweit bin.
Am besten wäre es, wenn ihr das versteht damit ihr da auch mit arbeiten könnt. Je schneller wir das Array fertig haben, umso besser :) 
(Edit 18.04 : Die Idee mit dem Array wurde wieder verworfen)

Marvin 15.04
Alle Gewinde mit Bemaßung erfolgreich eingeführt. Aber lokal, also habe ich alles gelöscht und mein lokales hochgeladen. Eures habe ich nicht geändert.....
glaube ich.
Daniels Rat mit Array gekonnt umgangen und nicht befolgt. Guten Tag!!!

Daniel 17.04
Ich hab die Ein-/ausgaben etwas umstrukturiert. Es gibt jetzt die Methode Abfrage(element,auswahl) ihr könnt es folgendermaßen benutzen:
tool.Abfrage(element,auswahl) für element müsst ihr dann das gefragte element angeben z.b  "Schraubenart" und für auswahl müsst ihr angeben 
welche auswahl der benutzer hat z.b "M1-M42". Wenn es keine auswahl gibt, einfach ---> "" <---  für auswahl eingeben.
Ich hab sonst noch volumen eingefügt, welches noch nicht auf die variablen zugreifen kann und sonst ein paar unnötige sachen gestrichen- :)

Daniel 18.04
Das Problem mit dem Volumen ist behoben + das Problem mit dem 2.ten Durchmesser.
Masse eingfügt und die Berechnungen stimmen alle
Vorlesung gemacht :)

Marvin 18.04
Mengeneingabe und Gesamtmasse erstellt

Daniel 19.04
Durchmesser wird abgefragt bis richtig angegeben

Daniel 20.04
Alle Wiederholungen sind fertig. Ein bisschen die Sechskantgrößen und die Metrischen größen sind angepasst.

Daniel 21.04
Ein paar kleine Änderungen gemacht

Marvin 21.04
Schraubenkopf Zoll ergänzt und teilweise Kopfhöhe hinzugefügt.

Daniel 22.04
Ein bisschen formatiert und Farben eingefügt