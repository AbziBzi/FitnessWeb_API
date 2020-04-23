-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Apr 23, 2020 at 09:31 PM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.4.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `fitnessweb`
--

-- --------------------------------------------------------

--
-- Table structure for table `Atliekamas_pratimas`
--

CREATE TABLE `Atliekamas_pratimas` (
  `kiekis` int(11) DEFAULT NULL,
  `ivertinimas` int(11) DEFAULT NULL,
  `vaizdo_irasas_URL` varchar(255) DEFAULT NULL,
  `ivertinimo_data` date DEFAULT NULL,
  `id_Atliekamas_pratimas` int(11) NOT NULL,
  `fk_Treneris_id` int(11) NOT NULL,
  `fk_Sportininkas_id` int(11) NOT NULL,
  `fk_Pratimas_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `Naudotojas`
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
-- Dumping data for table `Naudotojas`
--

INSERT INTO `Naudotojas` (`pavarde`, `vardas`, `epastas`, `slaptazodis`, `registracijos_data`, `paskutinio_prisijungimo_data`, `lygis`, `id_Naudotojas`) VALUES
('Pavarde', 'Vardas', 'e.pastas@pastas.lt', '123', '2020-04-01', '2020-04-01', 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `Pratimas`
--

CREATE TABLE `Pratimas` (
  `pavadinimas` varchar(255) DEFAULT NULL,
  `aprasymas` varchar(255) DEFAULT NULL,
  `nuotraukos_url` varchar(255) DEFAULT NULL,
  `verte` int(11) DEFAULT NULL,
  `id_Pratimas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `Reitingas`
--

CREATE TABLE `Reitingas` (
  `ivertinimas` int(11) DEFAULT NULL,
  `ivertinimo_data` date DEFAULT NULL,
  `id_Reitingas` int(11) NOT NULL,
  `fk_Sportininkas_id` int(11) NOT NULL,
  `fk_Treneris_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `Sportininkas`
--

CREATE TABLE `Sportininkas` (
  `atliktu_pratymu_skaicius` int(11) DEFAULT NULL,
  `taskai` int(11) DEFAULT NULL,
  `id_Naudotojas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `Sporto_programa`
--

CREATE TABLE `Sporto_programa` (
  `pavadinimas` varchar(255) DEFAULT NULL,
  `aprasas` varchar(255) DEFAULT NULL,
  `nuotraukos_url` varchar(255) DEFAULT NULL,
  `id_Sporto_programa` int(11) NOT NULL,
  `fk_Treneris_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `Sporto_programos_pratimas`
--

CREATE TABLE `Sporto_programos_pratimas` (
  `setai` int(11) DEFAULT NULL,
  `kartojimai` int(11) DEFAULT NULL,
  `id_Sporto_programos_pratimas` int(11) NOT NULL,
  `fk_Sporto_programa_id` int(11) NOT NULL,
  `fk_Pratimas_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `Treneris`
--

CREATE TABLE `Treneris` (
  `id_Naudotojas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `Varzybos`
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
-- Dumping data for table `Varzybos`
--

INSERT INTO `Varzybos` (`prasidejimo_data`, `pavadinimas`, `vieta`, `aprasas`, `pabaigos_data`, `id_Varzybos`, `fk_Naudotojas_id`) VALUES
('2020-04-30', '123456 Varzybos', 'Stadionas', 'AAA varzybos', '2020-04-30', 3, 1),
('2020-04-30', 'Antros Varzybos', 'Stadionas', 'AAA varzybos', '2020-04-30', 4, 1);

-- --------------------------------------------------------

--
-- Table structure for table `Varzybu_dalyvis`
--

CREATE TABLE `Varzybu_dalyvis` (
  `fk_Naudotojas_id` int(11) NOT NULL,
  `fk_Varzybos_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `Zinute`
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
-- Indexes for dumped tables
--

--
-- Indexes for table `Atliekamas_pratimas`
--
ALTER TABLE `Atliekamas_pratimas`
  ADD PRIMARY KEY (`id_Atliekamas_pratimas`),
  ADD KEY `vertina` (`fk_Treneris_id`),
  ADD KEY `atlieka` (`fk_Sportininkas_id`),
  ADD KEY `turi` (`fk_Pratimas_id`);

--
-- Indexes for table `Naudotojas`
--
ALTER TABLE `Naudotojas`
  ADD PRIMARY KEY (`id_Naudotojas`);

--
-- Indexes for table `Pratimas`
--
ALTER TABLE `Pratimas`
  ADD PRIMARY KEY (`id_Pratimas`);

--
-- Indexes for table `Reitingas`
--
ALTER TABLE `Reitingas`
  ADD PRIMARY KEY (`id_Reitingas`),
  ADD KEY `ivertina` (`fk_Sportininkas_id`),
  ADD KEY `priklauso1` (`fk_Treneris_id`);

--
-- Indexes for table `Sportininkas`
--
ALTER TABLE `Sportininkas`
  ADD PRIMARY KEY (`id_Naudotojas`);

--
-- Indexes for table `Sporto_programa`
--
ALTER TABLE `Sporto_programa`
  ADD PRIMARY KEY (`id_Sporto_programa`),
  ADD KEY `kuria2` (`fk_Treneris_id`);

--
-- Indexes for table `Sporto_programos_pratimas`
--
ALTER TABLE `Sporto_programos_pratimas`
  ADD PRIMARY KEY (`id_Sporto_programos_pratimas`),
  ADD KEY `sudaro` (`fk_Sporto_programa_id`),
  ADD KEY `priklauso` (`fk_Pratimas_id`);

--
-- Indexes for table `Treneris`
--
ALTER TABLE `Treneris`
  ADD PRIMARY KEY (`id_Naudotojas`);

--
-- Indexes for table `Varzybos`
--
ALTER TABLE `Varzybos`
  ADD PRIMARY KEY (`id_Varzybos`),
  ADD KEY `kuria` (`fk_Naudotojas_id`);

--
-- Indexes for table `Varzybu_dalyvis`
--
ALTER TABLE `Varzybu_dalyvis`
  ADD PRIMARY KEY (`fk_Naudotojas_id`,`fk_Varzybos_id`),
  ADD KEY `turi2` (`fk_Varzybos_id`);

--
-- Indexes for table `Zinute`
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
-- AUTO_INCREMENT for table `Atliekamas_pratimas`
--
ALTER TABLE `Atliekamas_pratimas`
  MODIFY `id_Atliekamas_pratimas` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Naudotojas`
--
ALTER TABLE `Naudotojas`
  MODIFY `id_Naudotojas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `Pratimas`
--
ALTER TABLE `Pratimas`
  MODIFY `id_Pratimas` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Reitingas`
--
ALTER TABLE `Reitingas`
  MODIFY `id_Reitingas` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Sportininkas`
--
ALTER TABLE `Sportininkas`
  MODIFY `id_Naudotojas` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Sporto_programa`
--
ALTER TABLE `Sporto_programa`
  MODIFY `id_Sporto_programa` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Sporto_programos_pratimas`
--
ALTER TABLE `Sporto_programos_pratimas`
  MODIFY `id_Sporto_programos_pratimas` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Treneris`
--
ALTER TABLE `Treneris`
  MODIFY `id_Naudotojas` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Varzybos`
--
ALTER TABLE `Varzybos`
  MODIFY `id_Varzybos` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `Zinute`
--
ALTER TABLE `Zinute`
  MODIFY `id_Zinute` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `Atliekamas_pratimas`
--
ALTER TABLE `Atliekamas_pratimas`
  ADD CONSTRAINT `atlieka` FOREIGN KEY (`fk_Sportininkas_id`) REFERENCES `Sportininkas` (`id_Naudotojas`),
  ADD CONSTRAINT `turi` FOREIGN KEY (`fk_Pratimas_id`) REFERENCES `Pratimas` (`id_Pratimas`),
  ADD CONSTRAINT `vertina` FOREIGN KEY (`fk_Treneris_id`) REFERENCES `Treneris` (`id_Naudotojas`);

--
-- Constraints for table `Reitingas`
--
ALTER TABLE `Reitingas`
  ADD CONSTRAINT `ivertina` FOREIGN KEY (`fk_Sportininkas_id`) REFERENCES `Sportininkas` (`id_Naudotojas`),
  ADD CONSTRAINT `priklauso1` FOREIGN KEY (`fk_Treneris_id`) REFERENCES `Treneris` (`id_Naudotojas`);

--
-- Constraints for table `Sportininkas`
--
ALTER TABLE `Sportininkas`
  ADD CONSTRAINT `Sportininkas_ibfk_1` FOREIGN KEY (`id_Naudotojas`) REFERENCES `Naudotojas` (`id_Naudotojas`);

--
-- Constraints for table `Sporto_programa`
--
ALTER TABLE `Sporto_programa`
  ADD CONSTRAINT `kuria2` FOREIGN KEY (`fk_Treneris_id`) REFERENCES `Treneris` (`id_Naudotojas`);

--
-- Constraints for table `Sporto_programos_pratimas`
--
ALTER TABLE `Sporto_programos_pratimas`
  ADD CONSTRAINT `priklauso` FOREIGN KEY (`fk_Pratimas_id`) REFERENCES `Pratimas` (`id_Pratimas`),
  ADD CONSTRAINT `sudaro` FOREIGN KEY (`fk_Sporto_programa_id`) REFERENCES `Sporto_programa` (`id_Sporto_programa`);

--
-- Constraints for table `Treneris`
--
ALTER TABLE `Treneris`
  ADD CONSTRAINT `Treneris_ibfk_1` FOREIGN KEY (`id_Naudotojas`) REFERENCES `Naudotojas` (`id_Naudotojas`);

--
-- Constraints for table `Varzybos`
--
ALTER TABLE `Varzybos`
  ADD CONSTRAINT `kuria` FOREIGN KEY (`fk_Naudotojas_id`) REFERENCES `Naudotojas` (`id_Naudotojas`);

--
-- Constraints for table `Varzybu_dalyvis`
--
ALTER TABLE `Varzybu_dalyvis`
  ADD CONSTRAINT `turi2` FOREIGN KEY (`fk_Varzybos_id`) REFERENCES `Varzybos` (`id_Varzybos`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `yra` FOREIGN KEY (`fk_Naudotojas_id`) REFERENCES `Naudotojas` (`id_Naudotojas`);

--
-- Constraints for table `Zinute`
--
ALTER TABLE `Zinute`
  ADD CONSTRAINT `atsako` FOREIGN KEY (`fk_Zinute_id`) REFERENCES `Zinute` (`id_Zinute`),
  ADD CONSTRAINT `gauna` FOREIGN KEY (`fk_Gavejas_id`) REFERENCES `Naudotojas` (`id_Naudotojas`),
  ADD CONSTRAINT `siuncia` FOREIGN KEY (`fk_Siuntejas_id`) REFERENCES `Naudotojas` (`id_Naudotojas`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
