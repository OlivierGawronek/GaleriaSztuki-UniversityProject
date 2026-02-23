BEGIN;

DROP TABLE IF EXISTS tranzakcja_karta CASCADE;
DROP TABLE IF EXISTS tranzakcja_gotowka CASCADE;
DROP TABLE IF EXISTS transakcja CASCADE;
DROP TABLE IF EXISTS wystawa_dzielo CASCADE;
DROP TABLE IF EXISTS klient_wystawa CASCADE;
DROP TABLE IF EXISTS artysta_magazyn CASCADE;
DROP TABLE IF EXISTS magazyn_dostawca CASCADE;
DROP TABLE IF EXISTS dzielo_sztuki CASCADE;
DROP TABLE IF EXISTS wystawa CASCADE;
DROP TABLE IF EXISTS pracownik CASCADE;
DROP TABLE IF EXISTS magazyn CASCADE;
DROP TABLE IF EXISTS dostawca_materialow CASCADE;
DROP TABLE IF EXISTS pseudonim CASCADE;
DROP TABLE IF EXISTS klient CASCADE;
DROP TABLE IF EXISTS artysta CASCADE;
DROP TABLE IF EXISTS galeria CASCADE;

CREATE TABLE galeria (
    id_galerii BIGSERIAL PRIMARY KEY,
    nazwa VARCHAR(100) NOT NULL,
    miasto VARCHAR(50) NOT NULL
);

CREATE TABLE artysta (
    id_artysty BIGSERIAL PRIMARY KEY,
    imie VARCHAR(50) NOT NULL,
    nazwisko VARCHAR(50) NOT NULL
);

CREATE TABLE pseudonim (
    id_pseudonimu SERIAL PRIMARY KEY,
    id_artysty BIGINT NOT NULL,
    nazwa VARCHAR(50) NOT NULL,
    rodzaj_sztuki VARCHAR(50),
    CONSTRAINT fk_artysta_pseudonim FOREIGN KEY (id_artysty)
        REFERENCES artysta(id_artysty) ON DELETE CASCADE
);

CREATE TABLE klient (
    id_klienta BIGSERIAL PRIMARY KEY,
    imie VARCHAR(50) NOT NULL,
    nazwisko VARCHAR(50) NOT NULL,
    portfel NUMERIC(12, 2) DEFAULT 0 CHECK (portfel >= 0)
);

CREATE TABLE dostawca_materialow (
    id_dostawcy BIGSERIAL PRIMARY KEY,
    nazwa VARCHAR(100) NOT NULL
);

CREATE TABLE pracownik (
    id_pracownika BIGSERIAL PRIMARY KEY,
    id_galerii BIGINT NOT NULL,
    id_przelozonego BIGINT,
    imie VARCHAR(50) NOT NULL,
    nazwisko VARCHAR(50) NOT NULL,
    wynagrodzenie NUMERIC(10, 2) CHECK (wynagrodzenie >= 0),
    CONSTRAINT fk_pracownik_galeria FOREIGN KEY (id_galerii)
        REFERENCES galeria(id_galerii),
    CONSTRAINT fk_pracownik_szef FOREIGN KEY (id_przelozonego)
        REFERENCES pracownik(id_pracownika)
);

CREATE TABLE wystawa (
    id_wystawy BIGSERIAL PRIMARY KEY,
    id_galerii BIGINT NOT NULL,
    nazwa VARCHAR(100) NOT NULL,
    miejsce_na_sali VARCHAR(100),
    CONSTRAINT fk_wystawa_galeria FOREIGN KEY (id_galerii)
        REFERENCES galeria(id_galerii)
);

CREATE TABLE dzielo_sztuki (
    id_dziela_sztuki BIGSERIAL PRIMARY KEY,
    id_pracownika BIGINT NOT NULL,
    id_artysty BIGINT NOT NULL,
    id_wystawy BIGINT,
    nazwa VARCHAR(100) NOT NULL,
    cena NUMERIC(10, 2) NOT NULL CHECK (cena >= 0),
    wymiary VARCHAR(50),
    CONSTRAINT fk_dzielo_artysta FOREIGN KEY (id_artysty)
        REFERENCES artysta(id_artysty),
    CONSTRAINT fk_dzielo_pracownik FOREIGN KEY (id_pracownika)
        REFERENCES pracownik(id_pracownika),
    CONSTRAINT fk_dzielo_wystawa FOREIGN KEY (id_wystawy)
        REFERENCES wystawa(id_wystawy) ON DELETE SET NULL
);

CREATE TABLE magazyn (
    id_przedmiotu BIGSERIAL PRIMARY KEY,
    id_galerii BIGINT NOT NULL,
    nazwa VARCHAR(100) NOT NULL,
    ilosc INTEGER DEFAULT 0 CHECK (ilosc >= 0),
    CONSTRAINT fk_magazyn_galeria FOREIGN KEY (id_galerii)
        REFERENCES galeria(id_galerii)
);

CREATE TABLE magazyn_dostawca (
    id_dostawcy BIGINT NOT NULL,
    id_przedmiotu BIGINT NOT NULL,
    PRIMARY KEY (id_dostawcy, id_przedmiotu),
    CONSTRAINT fk_md_dostawca FOREIGN KEY (id_dostawcy)
        REFERENCES dostawca_materialow(id_dostawcy),
    CONSTRAINT fk_md_przedmiot FOREIGN KEY (id_przedmiotu)
        REFERENCES magazyn(id_przedmiotu)
);

CREATE TABLE artysta_magazyn (
    id_artysty BIGINT NOT NULL,
    id_przedmiotu BIGINT NOT NULL,
    PRIMARY KEY (id_artysty, id_przedmiotu),
    CONSTRAINT fk_am_artysta FOREIGN KEY (id_artysty)
        REFERENCES artysta(id_artysty),
    CONSTRAINT fk_am_przedmiot FOREIGN KEY (id_przedmiotu)
        REFERENCES magazyn(id_przedmiotu)
);

CREATE TABLE klient_wystawa (
    id_klienta BIGINT NOT NULL,
    id_wystawy BIGINT NOT NULL,
    PRIMARY KEY (id_klienta, id_wystawy),
    CONSTRAINT fk_kw_klient FOREIGN KEY (id_klienta)
        REFERENCES klient(id_klienta),
    CONSTRAINT fk_kw_wystawa FOREIGN KEY (id_wystawy)
        REFERENCES wystawa(id_wystawy)
);

CREATE TABLE wystawa_dzielo (
    id_wystawy BIGINT NOT NULL,
    id_dziela_sztuki BIGINT NOT NULL,
    miejsce_na_sali VARCHAR(20),
    PRIMARY KEY (id_wystawy, id_dziela_sztuki),
    CONSTRAINT fk_wd_wystawa FOREIGN KEY (id_wystawy)
        REFERENCES wystawa(id_wystawy),
    CONSTRAINT fk_wd_dzielo FOREIGN KEY (id_dziela_sztuki)
        REFERENCES dzielo_sztuki(id_dziela_sztuki)
);

CREATE TABLE transakcja (
    id_transakcji BIGSERIAL PRIMARY KEY,
    id_dziela_sztuki BIGINT NOT NULL,
    id_klienta BIGINT NOT NULL,
    data_tranzakcji TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT fk_transakcja_klient FOREIGN KEY (id_klienta)
        REFERENCES klient(id_klienta),
    CONSTRAINT fk_transakcja_dzielo FOREIGN KEY (id_dziela_sztuki)
        REFERENCES dzielo_sztuki(id_dziela_sztuki)
);

CREATE TABLE tranzakcja_gotowka (
    id_transakcji BIGINT PRIMARY KEY,
    czy_reszta BOOLEAN DEFAULT FALSE,
    CONSTRAINT fk_gotowka_transakcja FOREIGN KEY (id_transakcji)
        REFERENCES transakcja(id_transakcji) ON DELETE CASCADE
);

CREATE TABLE tranzakcja_karta (
    id_transakcji BIGINT PRIMARY KEY,
    numer_karty VARCHAR(20) NOT NULL,
    CONSTRAINT fk_karta_transakcja FOREIGN KEY (id_transakcji)
        REFERENCES transakcja(id_transakcji) ON DELETE CASCADE
);

COMMIT;