# HSP-SoSe-2021

TO-DO Liste

- Material als Klasse
- Kopfhöhe {get; set;}
- Gewinde
- getVolumen
- getMasse
- laenge {get; set;} + abfrage
- getPreis




Hallo Leute,

schreibt einfach hier mal kurz rein was ihr geändert habt und wie man evtl. weiter machen könnte. (Mit Datum)
Bitte den Code immer mit Kommentaren versehen! :)

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



