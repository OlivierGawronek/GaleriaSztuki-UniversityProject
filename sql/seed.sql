BEGIN;

INSERT INTO galeria (nazwa, miasto) VALUES
  ('Galeria Sztuki Nowoczesnej','Warszawa'),
  ('Atelier Pod Baranami','Kraków'),
  ('Galeria Nad Motławą','Gdańsk'),
  ('Fundacja Sztuk Wizualnych','Wrocław'),
  ('Centrum Ekspresji','Poznań'),
  ('Przestrzeń Łódzka','Łódź'),
  ('Galeria Portowa','Szczecin'),
  ('Dom Sztuki Lubelskiej','Lublin'),
  ('Katowicka Strefa Art','Katowice'),
  ('Bydgoskie Studio Form','Bydgoszcz'),
  ('Mazowiecka Pracownia','Płock'),
  ('Galeria Pod Żaglami','Gdynia'),
  ('Galeria Stara Fabryka','Bielsko-Biała'),
  ('Galeria Rynek 14','Toruń'),
  ('Pracownia Nad Wisłą','Warszawa');

INSERT INTO artysta (imie, nazwisko) VALUES
  ('Ewa','Michalska'),
  ('Piotr','Jasiński'),
  ('Katarzyna','Rybak'),
  ('Marek','Nowosielski'),
  ('Zofia','Lis'),
  ('Andrzej','Stankiewicz'),
  ('Ola','Król'),
  ('Tomasz','Biel'),
  ('Natalia','Ostrowska'),
  ('Jan','Grodecki'),
  ('Helena','Czerwińska'),
  ('Igor','Konieczny'),
  ('Lena','Szulc'),
  ('Barbara','Grabska'),
  ('Dominik','Kurek');

INSERT INTO pseudonim (id_artysty, nazwa, rodzaj_sztuki) VALUES
  (1, 'EMI', 'Malarstwo olejne'),
  (1, 'BlueArt', 'Ceramika'),
  (2, 'P-Jas', 'Akwarela'),
  (3, 'KatR', 'Szkic'),
  (3, 'K-Fish', 'Grafika warsztatowa'),
  (4, 'Maro', 'Pop-art'),
  (5, 'Zoli', 'Fotografia'),
  (6, 'AST', 'Rzeźba w drewnie'),
  (7, 'O-Krol', 'Instalacje'),
  (8, 'TBiel', 'Mural'),
  (8, 'WhiteTom', 'Performance'),
  (9, 'Nato', 'Collage'),
  (10, 'JGR', 'Grafika 3D'),
  (11, 'HelCz', 'Tkactwo artystyczne'),
  (12, 'Ikon', 'Street Art'),
  (13, 'LenS', 'Video Art'),
  (14, 'BGrab', 'Rysunek węglem'),
  (15, 'DomK', 'Digital Painting');

INSERT INTO klient (imie, nazwisko, portfel) VALUES
  ('Adam','Kowalski',55000),
  ('Maria','Zielińska',42000),
  ('Wojciech','Sikora',38000),
  ('Joanna','Borkowska',60000),
  ('Karol','Mazur',25000),
  ('Anna','Baran',30000),
  ('Michał','Pawlak',47000),
  ('Elżbieta','Duda',52000),
  ('Rafał','Wieczorek',33000),
  ('Paweł','Czarnecki',45000),
  ('Monika','Jankowska',62000),
  ('Sylwia','Stępień',29000),
  ('Kamil','Górski',51000),
  ('Justyna','Wrzesień',41000),
  ('Oliwia','Ratajczak',36000);

INSERT INTO dostawca_materialow (nazwa) VALUES
  ('Ramy Premium Polska'),
  ('Pigmenty Artystyczne'),
  ('Światło Ekspozycyjne'),
  ('Systemy Zawieszeń Pro'),
  ('Szkło Ochronne'),
  ('Media Druk & Katalog'),
  ('Farby Olejne Classic'),
  ('Panele LedVision'),
  ('Ramy Dębowe Styl'),
  ('Pędzle Maestro'),
  ('Blejtramy Tech'),
  ('Papier Archiwalny'),
  ('Chemia Konserwatorska'),
  ('Oprawa Obrazów Styl+'),
  ('Dekor Expo');

INSERT INTO magazyn (nazwa, ilosc, id_galerii) VALUES
  ('Zestaw farb olejnych 48 kolorów',25,1),
  ('Rama dębowa 50x70',40,2),
  ('Panel LED kierunkowy 30W',18,3),
  ('System zawieszeń stalowy 10m',12,4),
  ('Szyba antyrefleksyjna 60x80',22,5),
  ('Katalog wystawy "Światło i Forma"',300,6),
  ('Blejtram lniany 70x100',35,7),
  ('Pędzle precyzyjne zestaw 12',50,8),
  ('Papier bawełniany A2',100,9),
  ('Pigment kobaltowy 100g',27,10),
  ('Lakier zabezpieczający mat 1L',15,11),
  ('Rama aluminiowa 40x50',33,12),
  ('Taśma archiwalna 50m',45,13),
  ('Środek do czyszczenia ram',20,14),
  ('Oprawa punktowa LED 12W',26,15);

INSERT INTO pracownik (id_galerii, id_przelozonego, imie, nazwisko, wynagrodzenie) VALUES
  (1,NULL,'Agnieszka','Gaczyńska',9800),
  (2,NULL,'Radosław','Sierakowski',9600),
  (3,NULL,'Iwona','Wieloch',9500),
  (4,NULL,'Grzegorz','Staszak',9400),
  (5,NULL,'Elena','Wełna',9300);

INSERT INTO pracownik (id_galerii, id_przelozonego, imie, nazwisko, wynagrodzenie) VALUES
  (1,1,'Tomasz','Brylowski',6200),
  (1,1,'Marta','Kątna',6100),
  (2,2,'Jakub','Bugała',6000),
  (2,2,'Oliwia','Płoska',6000),
  (3,3,'Paula','Janik',6150),
  (3,3,'Sebastian','Holewa',6100),
  (4,4,'Filip','Kosicki',6050),
  (4,4,'Kamila','Kuśmirek',6000),
  (5,5,'Patryk','Strzałka',6300),
  (5,5,'Magdalena','Czerwińska',6250);

INSERT INTO wystawa (id_galerii, nazwa, miejsce_na_sali) VALUES
  (1, 'Perspektywy Światła', 'Sala Główna'),
  (2, 'Kontrasty Materii', 'Sala Kameralna'),
  (3, 'Miasto i Czas', 'Antresola'),
  (4, 'Przestrzeń Gestu', 'Foyer'),
  (5, 'Portrety Współczesne', 'Piwnica Artystyczna'),
  (6, 'Forma i Pamięć', 'Sala Główna'),
  (7, 'Ruch i Faktura', 'Sala Kameralna'),
  (8, 'Linia Emocji', 'Antresola'),
  (9, 'Zmierzch Struktur', 'Foyer'),
  (10, 'Energia Koloru', 'Piwnica Artystyczna'),
  (11, 'Szukanie Równowagi', 'Sala Główna'),
  (12, 'Architektura Ciszy', 'Sala Kameralna'),
  (13, 'Ciężar Symboli', 'Antresola'),
  (14, 'Gest i Tekstura', 'Foyer'),
  (15, 'Dziedzictwo Warstw', 'Piwnica Artystyczna');

INSERT INTO dzielo_sztuki (id_pracownika, id_artysty, nazwa, cena, wymiary, id_wystawy) VALUES
  (1, 1, 'Świt nad Wisłą', 7800, '60x80 cm', 1),
  (2, 2, 'Abstrakcja Chromatyczna', 9200, '70x90 cm', 2),
  (3, 3, 'Cisza Poranka', 6500, '50x70 cm', 3),
  (4, 4, 'Struktury Miasta', 11000, '90x120 cm', 4),
  (5, 5, 'Portret w Sepii', 8400, '55x75 cm', 5),
  (6, 6, 'Interferencje Linii', 9800, '80x100 cm', 6),
  (7, 7, 'Taniec Kolorów', 7600, '60x60 cm', 7),
  (8, 8, 'Ślady Na Płótnie', 7200, '50x60 cm', 8),
  (9, 9, 'Horyzont Zmierzchu', 10500, '80x110 cm', 9),
  (10, 10, 'Przepływ Energii', 11500, '100x140 cm', 10),
  (11, 11, 'Równowaga Form', 9000, '70x95 cm', 11),
  (12, 12, 'Granice Ciszy', 9500, '75x100 cm', 12),
  (13, 13, 'Punkt Ciężkości', 8700, '65x85 cm', 13),
  (14, 14, 'Kolekcja Gestów', 8900, '68x88 cm', 14),
  (15, 15, 'Echo Przeszłości', 12000, '110x150 cm', 15);

INSERT INTO magazyn_dostawca (id_dostawcy, id_przedmiotu) VALUES
  (1,2),(2,1),(3,3),(4,4),(5,5),
  (6,6),(7,7),(8,15),(9,11),(10,8),
  (11,13),(12,9),(13,10),(14,12),(15,14);

INSERT INTO artysta_magazyn (id_przedmiotu, id_artysty) VALUES
  (1,1),(2,2),(3,3),(4,4),(5,5),
  (6,6),(7,7),(8,8),(9,9),(10,10),
  (11,11),(12,12),(13,13),(14,14),(15,15);

INSERT INTO klient_wystawa (id_klienta, id_wystawy) VALUES
  (1,1),(2,2),(3,3),(4,4),(5,5),
  (6,6),(7,7),(8,8),(9,9),(10,10),
  (11,11),(12,12),(13,13),(14,14),(15,15);

INSERT INTO wystawa_dzielo (id_wystawy, id_dziela_sztuki, miejsce_na_sali) VALUES
  (1,1,'A1'),(2,2,'A2'),(3,3,'B1'),
  (4,4,'B2'),(5,5,'C1'),(6,6,'C2'),
  (7,7,'D1'),(8,8,'D2'),(9,9,'E1'),
  (10,10,'E2'),(11,11,'F1'),(12,12,'F2'),
  (13,13,'G1'),(14,14,'G2'),(15,15,'H1');

INSERT INTO transakcja (id_dziela_sztuki, id_klienta, data_tranzakcji) VALUES
  (1,1,'2025-02-01 11:05:00+01'),
  (2,2,'2025-02-02 12:10:00+01'),
  (3,3,'2025-02-03 13:15:00+01'),
  (4,4,'2025-02-04 14:20:00+01'),
  (5,5,'2025-02-05 15:00:00+01'),
  (6,6,'2025-02-06 16:30:00+01'),
  (7,7,'2025-02-07 11:45:00+01'),
  (8,8,'2025-02-08 12:50:00+01'),
  (9,9,'2025-02-09 13:40:00+01'),
  (10,10,'2025-02-10 14:25:00+01'),
  (11,11,'2025-02-11 15:55:00+01'),
  (12,12,'2025-02-12 16:05:00+01'),
  (13,13,'2025-02-13 17:10:00+01'),
  (14,14,'2025-02-14 18:15:00+01'),
  (15,15,'2025-02-15 11:20:00+01'),
  (1,2,'2025-03-01 12:05:00+01'),
  (2,3,'2025-03-02 12:10:00+01'),
  (3,4,'2025-03-03 13:15:00+01'),
  (4,5,'2025-03-04 14:20:00+01'),
  (5,6,'2025-03-05 15:00:00+01'),
  (6,7,'2025-03-06 16:30:00+01'),
  (7,8,'2025-03-07 11:45:00+01'),
  (8,9,'2025-03-08 12:50:00+01'),
  (9,10,'2025-03-09 13:40:00+01'),
  (10,11,'2025-03-10 14:25:00+01'),
  (11,12,'2025-03-11 15:55:00+01'),
  (12,13,'2025-03-12 16:05:00+01'),
  (13,14,'2025-03-13 17:10:00+01'),
  (14,15,'2025-03-14 18:15:00+01'),
  (15,1,'2025-03-15 11:20:00+01');

INSERT INTO tranzakcja_karta (id_transakcji, numer_karty) VALUES
  (1,'5450 01** **** 0001'),
  (2,'5450 01** **** 0002'),
  (3,'5450 01** **** 0003'),
  (4,'5450 01** **** 0004'),
  (5,'5450 01** **** 0005'),
  (6,'5450 01** **** 0006'),
  (7,'5450 01** **** 0007'),
  (8,'5450 01** **** 0008'),
  (9,'5450 01** **** 0009'),
  (10,'5450 01** **** 0010'),
  (11,'5450 01** **** 0011'),
  (12,'5450 01** **** 0012'),
  (13,'5450 01** **** 0013'),
  (14,'5450 01** **** 0014'),
  (15,'5450 01** **** 0015');

INSERT INTO tranzakcja_gotowka (id_transakcji, czy_reszta) VALUES
  (16,true),(17,false),(18,true),(19,false),(20,true),
  (21,false),(22,true),(23,false),(24,true),(25,false),
  (26,true),(27,false),(28,true),(29,false),(30,true);

COMMIT;