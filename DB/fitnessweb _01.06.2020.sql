-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Czas generowania: 01 Cze 2020, 17:29
-- Wersja serwera: 10.4.11-MariaDB
-- Wersja PHP: 7.4.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `fitnessweb`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `Atliekamas_pratimas`
--

CREATE TABLE `Atliekamas_pratimas` (
  `kiekis` int(11) DEFAULT NULL,
  `ivertinimas` int(11) DEFAULT NULL,
  `vaizdo_irasas_URL` varchar(255) DEFAULT NULL,
  `ivertinimo_data` date DEFAULT NULL,
  `id_Atliekamas_pratimas` int(11) NOT NULL,
  `fk_Treneris_id` int(11) DEFAULT NULL,
  `fk_Sportininkas_id` int(11) NOT NULL,
  `fk_Pratimas_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `Atliekamas_pratimas`
--

INSERT INTO `Atliekamas_pratimas` (`kiekis`, `ivertinimas`, `vaizdo_irasas_URL`, `ivertinimo_data`, `id_Atliekamas_pratimas`, `fk_Treneris_id`, `fk_Sportininkas_id`, `fk_Pratimas_id`) VALUES
(123, 321, 'asd.asd', '2020-05-24', 2, 3, 1, 2),
(321, NULL, NULL, NULL, 3, 2, 3, 1),
(333, 1, 'qwe', '2020-05-01', 4, 2, 3, 2),
(123321, 12, '312123', NULL, 5, 2, 1, 2),
(1, NULL, 'qwe', NULL, 10, NULL, 1, 2),
(12, NULL, 'asd', NULL, 14, 2, 1, 2),
(12, NULL, 'dsa', NULL, 18, NULL, 1, 2),
(12, NULL, NULL, NULL, 19, 2, 1, 2),
(NULL, NULL, NULL, NULL, 26, NULL, 1, 2),
(12, NULL, NULL, NULL, 31, 2, 1, 2),
(12, NULL, NULL, NULL, 33, NULL, 1, 2),
(12, NULL, NULL, NULL, 34, NULL, 1, 2),
(123122, NULL, NULL, NULL, 35, NULL, 1, 2),
(123122, NULL, NULL, NULL, 36, NULL, 1, 1);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `Naudotojas`
--

CREATE TABLE `Naudotojas` (
  `pavarde` varchar(255) DEFAULT NULL,
  `vardas` varchar(255) DEFAULT NULL,
  `epastas` varchar(255) DEFAULT NULL,
  `slaptazodis` varchar(255) DEFAULT NULL,
  `registracijos_data` date DEFAULT NULL,
  `paskutinio_prisijungimo_data` date DEFAULT NULL,
  `lygis` int(11) DEFAULT NULL,
  `id_Naudotojas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `Naudotojas`
--

INSERT INTO `Naudotojas` (`pavarde`, `vardas`, `epastas`, `slaptazodis`, `registracijos_data`, `paskutinio_prisijungimo_data`, `lygis`, `id_Naudotojas`) VALUES
('Pavarde', 'Vardas', 'e.pastas@pastas.lt', '123', '2020-04-01', '2020-04-01', 1, 1),
('Pavarde12', 'Vardas12', 'e.pastas12@pastas.lt', '1234', '2020-04-01', '2020-04-01', 1, 2),
('Kitas', 'Kitas1', 'kitas@pastas.lt', 'kitas123', '2020-05-01', '2020-05-02', 0, 3);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `Pratimas`
--

CREATE TABLE `Pratimas` (
  `pavadinimas` varchar(255) DEFAULT NULL,
  `aprasymas` varchar(255) DEFAULT NULL,
  `nuotraukos_url` varchar(255) DEFAULT NULL,
  `verte` int(11) DEFAULT NULL,
  `id_Pratimas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `Pratimas`
--

INSERT INTO `Pratimas` (`pavadinimas`, `aprasymas`, `nuotraukos_url`, `verte`, `id_Pratimas`) VALUES
('pirmas pratimas', 'pirmo pratimo aprasymas', NULL, 1, 1),
('antras pratimas', 'antro pratimo aprasymas', NULL, 2, 2);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `Reitingas`
--

CREATE TABLE `Reitingas` (
  `ivertinimas` int(11) DEFAULT NULL,
  `ivertinimo_data` date DEFAULT NULL,
  `id_Reitingas` int(11) NOT NULL,
  `fk_Sportininkas_id` int(11) NOT NULL,
  `fk_Treneris_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `Reitingas`
--

INSERT INTO `Reitingas` (`ivertinimas`, `ivertinimo_data`, `id_Reitingas`, `fk_Sportininkas_id`, `fk_Treneris_id`) VALUES
(1, '2020-05-14', 1, 1, 2);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `Sportininkas`
--

CREATE TABLE `Sportininkas` (
  `atliktu_pratymu_skaicius` int(11) DEFAULT NULL,
  `taskai` int(11) DEFAULT NULL,
  `id_Naudotojas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `Sportininkas`
--

INSERT INTO `Sportininkas` (`atliktu_pratymu_skaicius`, `taskai`, `id_Naudotojas`) VALUES
(NULL, NULL, 1),
(NULL, NULL, 3);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `Sporto_programa`
--

CREATE TABLE `Sporto_programa` (
  `pavadinimas` varchar(255) DEFAULT NULL,
  `aprasas` varchar(255) DEFAULT NULL,
  `nuotraukos_url` varchar(255) DEFAULT NULL,
  `id_Sporto_programa` int(11) NOT NULL,
  `fk_Treneris_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `Sporto_programa`
--

INSERT INTO `Sporto_programa` (`pavadinimas`, `aprasas`, `nuotraukos_url`, `id_Sporto_programa`, `fk_Treneris_id`) VALUES
('1', 'aprasas123', 'yra nuotraukos', 11, 2),
('1', 'aprasas123', 'nera nuotraukos', 13, 2),
('1', 'aprasas123', 'nera nuotraukos', 14, 2),
('1', 'aprasas123', 'nera nuotraukos', 15, 2),
('1', 'aprasas123', 'nera nuotraukos', 16, 2),
('1', 'aprasas123', 'nera nuotraukos', 17, 2),
('1', 'aprasas123', 'nera nuotraukos', 18, 2);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `Sporto_programos_pratimas`
--

CREATE TABLE `Sporto_programos_pratimas` (
  `setai` int(11) DEFAULT NULL,
  `kartojimai` int(11) DEFAULT NULL,
  `id_Sporto_programos_pratimas` int(11) NOT NULL,
  `fk_Sporto_programa_id` int(11) NOT NULL,
  `fk_Pratimas_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `Sporto_programos_pratimas`
--

INSERT INTO `Sporto_programos_pratimas` (`setai`, `kartojimai`, `id_Sporto_programos_pratimas`, `fk_Sporto_programa_id`, `fk_Pratimas_id`) VALUES
(1123, 231212, 14, 18, 1),
(2321, 0, 15, 11, 2),
(1, 12, 17, 13, 1),
(1, 12, 18, 13, 1),
(1, 12, 19, 14, 1),
(2, 1, 20, 14, 2),
(2, 1, 21, 14, 2),
(1, 12, 22, 14, 1),
(1, 12, 23, 15, 1),
(2, 1, 24, 15, 2),
(2, 1, 25, 15, 2),
(1, 12, 26, 15, 1),
(1, 12, 27, 16, 1),
(1, 12, 28, 16, 1),
(1, 12, 29, 17, 1),
(1, 12, 30, 18, 1),
(2, 1, 31, 18, 2);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `Treneris`
--

CREATE TABLE `Treneris` (
  `id_Naudotojas` int(11) NOT NULL,
  `kaina` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `Treneris`
--

INSERT INTO `Treneris` (`id_Naudotojas`, `kaina`) VALUES
(2, 2),
(3, 3.2);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `Varzybos`
--

CREATE TABLE `Varzybos` (
  `prasidejimo_data` date DEFAULT NULL,
  `pavadinimas` varchar(255) DEFAULT NULL,
  `vieta` varchar(255) DEFAULT NULL,
  `aprasas` varchar(255) DEFAULT NULL,
  `pabaigos_data` date DEFAULT NULL,
  `id_Varzybos` int(11) NOT NULL,
  `fk_Naudotojas_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `Varzybos`
--

INSERT INTO `Varzybos` (`prasidejimo_data`, `pavadinimas`, `vieta`, `aprasas`, `pabaigos_data`, `id_Varzybos`, `fk_Naudotojas_id`) VALUES
('2020-04-30', '123456 Varzybos', 'Stadionas', 'naujas', '2020-04-30', 5, 1);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `Varzybu_dalyvis`
--

CREATE TABLE `Varzybu_dalyvis` (
  `fk_Naudotojas_id` int(11) NOT NULL,
  `fk_Varzybos_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `Varzybu_dalyvis`
--

INSERT INTO `Varzybu_dalyvis` (`fk_Naudotojas_id`, `fk_Varzybos_id`) VALUES
(2, 5);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `Zinute`
--

CREATE TABLE `Zinute` (
  `tekstas` varchar(255) DEFAULT NULL,
  `issiuntimo_laikas` date DEFAULT NULL,
  `id_Zinute` int(11) NOT NULL,
  `fk_Zinute_id` int(11) DEFAULT NULL,
  `fk_Siuntejas_id` int(11) NOT NULL,
  `fk_Gavejas_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `Atliekamas_pratimas`
--
ALTER TABLE `Atliekamas_pratimas`
  ADD PRIMARY KEY (`id_Atliekamas_pratimas`),
  ADD KEY `atlieka` (`fk_Sportininkas_id`),
  ADD KEY `turi` (`fk_Pratimas_id`),
  ADD KEY `vertina` (`fk_Treneris_id`);

--
-- Indeksy dla tabeli `Naudotojas`
--
ALTER TABLE `Naudotojas`
  ADD PRIMARY KEY (`id_Naudotojas`);

--
-- Indeksy dla tabeli `Pratimas`
--
ALTER TABLE `Pratimas`
  ADD PRIMARY KEY (`id_Pratimas`);

--
-- Indeksy dla tabeli `Reitingas`
--
ALTER TABLE `Reitingas`
  ADD PRIMARY KEY (`id_Reitingas`),
  ADD KEY `ivertina` (`fk_Sportininkas_id`),
  ADD KEY `priklauso1` (`fk_Treneris_id`);

--
-- Indeksy dla tabeli `Sportininkas`
--
ALTER TABLE `Sportininkas`
  ADD PRIMARY KEY (`id_Naudotojas`);

--
-- Indeksy dla tabeli `Sporto_programa`
--
ALTER TABLE `Sporto_programa`
  ADD PRIMARY KEY (`id_Sporto_programa`),
  ADD KEY `kuria2` (`fk_Treneris_id`);

--
-- Indeksy dla tabeli `Sporto_programos_pratimas`
--
ALTER TABLE `Sporto_programos_pratimas`
  ADD PRIMARY KEY (`id_Sporto_programos_pratimas`),
  ADD KEY `priklauso` (`fk_Pratimas_id`),
  ADD KEY `sudaro` (`fk_Sporto_programa_id`);

--
-- Indeksy dla tabeli `Treneris`
--
ALTER TABLE `Treneris`
  ADD PRIMARY KEY (`id_Naudotojas`);

--
-- Indeksy dla tabeli `Varzybos`
--
ALTER TABLE `Varzybos`
  ADD PRIMARY KEY (`id_Varzybos`),
  ADD KEY `kuria` (`fk_Naudotojas_id`);

--
-- Indeksy dla tabeli `Varzybu_dalyvis`
--
ALTER TABLE `Varzybu_dalyvis`
  ADD PRIMARY KEY (`fk_Naudotojas_id`,`fk_Varzybos_id`),
  ADD KEY `turi2` (`fk_Varzybos_id`);

--
-- Indeksy dla tabeli `Zinute`
--
ALTER TABLE `Zinute`
  ADD PRIMARY KEY (`id_Zinute`),
  ADD KEY `atsako` (`fk_Zinute_id`),
  ADD KEY `siuncia` (`fk_Siuntejas_id`),
  ADD KEY `gauna` (`fk_Gavejas_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT dla tabeli `Atliekamas_pratimas`
--
ALTER TABLE `Atliekamas_pratimas`
  MODIFY `id_Atliekamas_pratimas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- AUTO_INCREMENT dla tabeli `Naudotojas`
--
ALTER TABLE `Naudotojas`
  MODIFY `id_Naudotojas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT dla tabeli `Pratimas`
--
ALTER TABLE `Pratimas`
  MODIFY `id_Pratimas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT dla tabeli `Reitingas`
--
ALTER TABLE `Reitingas`
  MODIFY `id_Reitingas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `Sportininkas`
--
ALTER TABLE `Sportininkas`
  MODIFY `id_Naudotojas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT dla tabeli `Sporto_programa`
--
ALTER TABLE `Sporto_programa`
  MODIFY `id_Sporto_programa` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT dla tabeli `Sporto_programos_pratimas`
--
ALTER TABLE `Sporto_programos_pratimas`
  MODIFY `id_Sporto_programos_pratimas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;

--
-- AUTO_INCREMENT dla tabeli `Treneris`
--
ALTER TABLE `Treneris`
  MODIFY `id_Naudotojas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT dla tabeli `Varzybos`
--
ALTER TABLE `Varzybos`
  MODIFY `id_Varzybos` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT dla tabeli `Zinute`
--
ALTER TABLE `Zinute`
  MODIFY `id_Zinute` int(11) NOT NULL AUTO_INCREMENT;

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `Atliekamas_pratimas`
--
ALTER TABLE `Atliekamas_pratimas`
  ADD CONSTRAINT `atlieka` FOREIGN KEY (`fk_Sportininkas_id`) REFERENCES `Sportininkas` (`id_Naudotojas`),
  ADD CONSTRAINT `turi` FOREIGN KEY (`fk_Pratimas_id`) REFERENCES `Pratimas` (`id_Pratimas`),
  ADD CONSTRAINT `vertina` FOREIGN KEY (`fk_Treneris_id`) REFERENCES `Treneris` (`id_Naudotojas`) ON DELETE SET NULL ON UPDATE SET NULL;

--
-- Ograniczenia dla tabeli `Reitingas`
--
ALTER TABLE `Reitingas`
  ADD CONSTRAINT `ivertina` FOREIGN KEY (`fk_Sportininkas_id`) REFERENCES `Sportininkas` (`id_Naudotojas`),
  ADD CONSTRAINT `priklauso1` FOREIGN KEY (`fk_Treneris_id`) REFERENCES `Treneris` (`id_Naudotojas`);

--
-- Ograniczenia dla tabeli `Sportininkas`
--
ALTER TABLE `Sportininkas`
  ADD CONSTRAINT `Sportininkas_ibfk_1` FOREIGN KEY (`id_Naudotojas`) REFERENCES `Naudotojas` (`id_Naudotojas`);

--
-- Ograniczenia dla tabeli `Sporto_programa`
--
ALTER TABLE `Sporto_programa`
  ADD CONSTRAINT `kuria2` FOREIGN KEY (`fk_Treneris_id`) REFERENCES `Treneris` (`id_Naudotojas`);

--
-- Ograniczenia dla tabeli `Sporto_programos_pratimas`
--
ALTER TABLE `Sporto_programos_pratimas`
  ADD CONSTRAINT `priklauso` FOREIGN KEY (`fk_Pratimas_id`) REFERENCES `Pratimas` (`id_Pratimas`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `sudaro` FOREIGN KEY (`fk_Sporto_programa_id`) REFERENCES `Sporto_programa` (`id_Sporto_programa`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ograniczenia dla tabeli `Treneris`
--
ALTER TABLE `Treneris`
  ADD CONSTRAINT `Treneris_ibfk_1` FOREIGN KEY (`id_Naudotojas`) REFERENCES `Naudotojas` (`id_Naudotojas`);

--
-- Ograniczenia dla tabeli `Varzybos`
--
ALTER TABLE `Varzybos`
  ADD CONSTRAINT `kuria` FOREIGN KEY (`fk_Naudotojas_id`) REFERENCES `Naudotojas` (`id_Naudotojas`);

--
-- Ograniczenia dla tabeli `Varzybu_dalyvis`
--
ALTER TABLE `Varzybu_dalyvis`
  ADD CONSTRAINT `turi2` FOREIGN KEY (`fk_Varzybos_id`) REFERENCES `Varzybos` (`id_Varzybos`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `yra` FOREIGN KEY (`fk_Naudotojas_id`) REFERENCES `Naudotojas` (`id_Naudotojas`);

--
-- Ograniczenia dla tabeli `Zinute`
--
ALTER TABLE `Zinute`
  ADD CONSTRAINT `atsako` FOREIGN KEY (`fk_Zinute_id`) REFERENCES `Zinute` (`id_Zinute`),
  ADD CONSTRAINT `gauna` FOREIGN KEY (`fk_Gavejas_id`) REFERENCES `Naudotojas` (`id_Naudotojas`),
  ADD CONSTRAINT `siuncia` FOREIGN KEY (`fk_Siuntejas_id`) REFERENCES `Naudotojas` (`id_Naudotojas`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
