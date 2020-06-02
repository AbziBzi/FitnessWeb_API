-- MySQL dump 10.13  Distrib 5.7.30, for Linux (x86_64)
--
-- Host: localhost    Database: fitnessweb
-- ------------------------------------------------------
-- Server version	5.7.30-0ubuntu0.18.04.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Atliekamas_pratimas`
--

DROP TABLE IF EXISTS `Atliekamas_pratimas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Atliekamas_pratimas` (
  `kiekis` int(11) DEFAULT NULL,
  `ivertinimas` int(11) DEFAULT NULL,
  `vaizdo_irasas_URL` varchar(255) DEFAULT NULL,
  `ivertinimo_data` date DEFAULT NULL,
  `id_Atliekamas_pratimas` int(11) NOT NULL AUTO_INCREMENT,
  `fk_Treneris_id` int(11) DEFAULT NULL,
  `fk_Sportininkas_id` int(11) NOT NULL,
  `fk_Pratimas_id` int(11) NOT NULL,
  PRIMARY KEY (`id_Atliekamas_pratimas`),
  KEY `atlieka` (`fk_Sportininkas_id`),
  KEY `turi` (`fk_Pratimas_id`),
  KEY `vertina` (`fk_Treneris_id`),
  CONSTRAINT `atlieka` FOREIGN KEY (`fk_Sportininkas_id`) REFERENCES `Sportininkas` (`id_Naudotojas`),
  CONSTRAINT `turi` FOREIGN KEY (`fk_Pratimas_id`) REFERENCES `Pratimas` (`id_Pratimas`),
  CONSTRAINT `vertina` FOREIGN KEY (`fk_Treneris_id`) REFERENCES `Treneris` (`id_Naudotojas`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Atliekamas_pratimas`
--

LOCK TABLES `Atliekamas_pratimas` WRITE;
/*!40000 ALTER TABLE `Atliekamas_pratimas` DISABLE KEYS */;
INSERT INTO `Atliekamas_pratimas` VALUES (123,321,'asd.asd','2020-05-24',2,3,1,2),(321,NULL,NULL,NULL,3,2,3,1),(333,1,'qwe','2020-05-01',4,2,3,2),(123321,12,'312123',NULL,5,2,1,2),(1,NULL,'qwe',NULL,10,NULL,1,2),(12,NULL,'asd',NULL,14,2,1,2),(12,NULL,'dsa',NULL,18,NULL,1,2),(12,NULL,NULL,NULL,19,2,1,2),(NULL,NULL,NULL,NULL,26,NULL,1,2),(12,NULL,NULL,NULL,31,2,1,2),(12,NULL,NULL,NULL,33,NULL,1,2),(12,NULL,NULL,NULL,34,NULL,1,2),(123122,NULL,NULL,NULL,35,NULL,1,2),(123122,NULL,NULL,NULL,36,NULL,1,1);
/*!40000 ALTER TABLE `Atliekamas_pratimas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Naudotojas`
--

DROP TABLE IF EXISTS `Naudotojas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Naudotojas` (
  `pavarde` varchar(255) DEFAULT NULL,
  `vardas` varchar(255) DEFAULT NULL,
  `epastas` varchar(255) DEFAULT NULL,
  `slaptazodis` varchar(255) DEFAULT NULL,
  `registracijos_data` date DEFAULT NULL,
  `paskutinio_prisijungimo_data` date DEFAULT NULL,
  `lygis` int(11) DEFAULT NULL,
  `id_Naudotojas` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id_Naudotojas`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Naudotojas`
--

LOCK TABLES `Naudotojas` WRITE;
/*!40000 ALTER TABLE `Naudotojas` DISABLE KEYS */;
INSERT INTO `Naudotojas` VALUES ('Pavarde','Vardas','e.pastas@pastas.lt','123','2020-04-01','2020-04-01',1,1),('Pavarde12','Vardas12','e.pastas12@pastas.lt','1234','2020-04-01','2020-04-01',1,2),('Kitas','Kitas1','kitas@pastas.lt','kitas123','2020-05-01','2020-05-02',0,3);
/*!40000 ALTER TABLE `Naudotojas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Pratimas`
--

DROP TABLE IF EXISTS `Pratimas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Pratimas` (
  `pavadinimas` varchar(255) DEFAULT NULL,
  `aprasymas` varchar(255) DEFAULT NULL,
  `nuotraukos_url` varchar(255) DEFAULT NULL,
  `verte` int(11) DEFAULT NULL,
  `id_Pratimas` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id_Pratimas`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Pratimas`
--

LOCK TABLES `Pratimas` WRITE;
/*!40000 ALTER TABLE `Pratimas` DISABLE KEYS */;
INSERT INTO `Pratimas` VALUES ('pirmas pratimas','pirmo pratimo aprasymas',NULL,1,1),('antras pratimas','antro pratimo aprasymas',NULL,2,2);
/*!40000 ALTER TABLE `Pratimas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Reitingas`
--

DROP TABLE IF EXISTS `Reitingas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Reitingas` (
  `ivertinimas` int(11) DEFAULT NULL,
  `ivertinimo_data` date DEFAULT NULL,
  `id_Reitingas` int(11) NOT NULL AUTO_INCREMENT,
  `fk_Sportininkas_id` int(11) NOT NULL,
  `fk_Treneris_id` int(11) NOT NULL,
  PRIMARY KEY (`id_Reitingas`),
  KEY `ivertina` (`fk_Sportininkas_id`),
  KEY `priklauso1` (`fk_Treneris_id`),
  CONSTRAINT `ivertina` FOREIGN KEY (`fk_Sportininkas_id`) REFERENCES `Sportininkas` (`id_Naudotojas`),
  CONSTRAINT `priklauso1` FOREIGN KEY (`fk_Treneris_id`) REFERENCES `Treneris` (`id_Naudotojas`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Reitingas`
--

LOCK TABLES `Reitingas` WRITE;
/*!40000 ALTER TABLE `Reitingas` DISABLE KEYS */;
INSERT INTO `Reitingas` VALUES (1,'2020-05-14',1,1,2);
/*!40000 ALTER TABLE `Reitingas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Sportininkas`
--

DROP TABLE IF EXISTS `Sportininkas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Sportininkas` (
  `atliktu_pratymu_skaicius` int(11) DEFAULT NULL,
  `taskai` int(11) DEFAULT NULL,
  `id_Naudotojas` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id_Naudotojas`),
  CONSTRAINT `Sportininkas_ibfk_1` FOREIGN KEY (`id_Naudotojas`) REFERENCES `Naudotojas` (`id_Naudotojas`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Sportininkas`
--

LOCK TABLES `Sportininkas` WRITE;
/*!40000 ALTER TABLE `Sportininkas` DISABLE KEYS */;
INSERT INTO `Sportininkas` VALUES (NULL,NULL,1),(NULL,NULL,3);
/*!40000 ALTER TABLE `Sportininkas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Sporto_programa`
--

DROP TABLE IF EXISTS `Sporto_programa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Sporto_programa` (
  `pavadinimas` varchar(255) DEFAULT NULL,
  `aprasas` varchar(255) DEFAULT NULL,
  `nuotraukos_url` varchar(255) DEFAULT NULL,
  `id_Sporto_programa` int(11) NOT NULL AUTO_INCREMENT,
  `fk_Treneris_id` int(11) NOT NULL,
  PRIMARY KEY (`id_Sporto_programa`),
  KEY `kuria2` (`fk_Treneris_id`),
  CONSTRAINT `kuria2` FOREIGN KEY (`fk_Treneris_id`) REFERENCES `Treneris` (`id_Naudotojas`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Sporto_programa`
--

LOCK TABLES `Sporto_programa` WRITE;
/*!40000 ALTER TABLE `Sporto_programa` DISABLE KEYS */;
INSERT INTO `Sporto_programa` VALUES ('1','aprasas123','yra nuotraukos',11,2),('1','aprasas123','nera nuotraukos',13,2),('1','aprasas123','nera nuotraukos',14,2),('1','aprasas123','nera nuotraukos',15,2),('1','aprasas123','nera nuotraukos',16,2),('1','aprasas123','nera nuotraukos',17,2),('','aprasas123','nera nuotraukos',18,2),('','','',19,2),('555','','',20,2),('rwerwer','','',21,2);
/*!40000 ALTER TABLE `Sporto_programa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Sporto_programos_pratimas`
--

DROP TABLE IF EXISTS `Sporto_programos_pratimas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Sporto_programos_pratimas` (
  `setai` int(11) DEFAULT NULL,
  `kartojimai` int(11) DEFAULT NULL,
  `id_Sporto_programos_pratimas` int(11) NOT NULL AUTO_INCREMENT,
  `fk_Sporto_programa_id` int(11) NOT NULL,
  `fk_Pratimas_id` int(11) NOT NULL,
  PRIMARY KEY (`id_Sporto_programos_pratimas`),
  KEY `priklauso` (`fk_Pratimas_id`),
  KEY `sudaro` (`fk_Sporto_programa_id`),
  CONSTRAINT `priklauso` FOREIGN KEY (`fk_Pratimas_id`) REFERENCES `Pratimas` (`id_Pratimas`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `sudaro` FOREIGN KEY (`fk_Sporto_programa_id`) REFERENCES `Sporto_programa` (`id_Sporto_programa`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Sporto_programos_pratimas`
--

LOCK TABLES `Sporto_programos_pratimas` WRITE;
/*!40000 ALTER TABLE `Sporto_programos_pratimas` DISABLE KEYS */;
INSERT INTO `Sporto_programos_pratimas` VALUES (1123,231212,14,18,1),(2321,0,15,11,2),(1,12,17,13,1),(1,12,18,13,1),(1,12,19,14,1),(2,1,20,14,2),(2,1,21,14,2),(1,12,22,14,1),(1,12,23,15,1),(2,1,24,15,2),(2,1,25,15,2),(1,12,26,15,1),(1,12,27,16,1),(1,12,28,16,1),(1,12,29,17,1),(1,12,30,18,1),(2,1,31,18,2);
/*!40000 ALTER TABLE `Sporto_programos_pratimas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Treneris`
--

DROP TABLE IF EXISTS `Treneris`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Treneris` (
  `id_Naudotojas` int(11) NOT NULL AUTO_INCREMENT,
  `kaina` double DEFAULT NULL,
  PRIMARY KEY (`id_Naudotojas`),
  CONSTRAINT `Treneris_ibfk_1` FOREIGN KEY (`id_Naudotojas`) REFERENCES `Naudotojas` (`id_Naudotojas`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Treneris`
--

LOCK TABLES `Treneris` WRITE;
/*!40000 ALTER TABLE `Treneris` DISABLE KEYS */;
INSERT INTO `Treneris` VALUES (2,2),(3,10);
/*!40000 ALTER TABLE `Treneris` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Varzybos`
--

DROP TABLE IF EXISTS `Varzybos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Varzybos` (
  `prasidejimo_data` date DEFAULT NULL,
  `pavadinimas` varchar(255) DEFAULT NULL,
  `vieta` varchar(255) DEFAULT NULL,
  `aprasas` varchar(255) DEFAULT NULL,
  `pabaigos_data` date DEFAULT NULL,
  `id_Varzybos` int(11) NOT NULL AUTO_INCREMENT,
  `fk_Naudotojas_id` int(11) NOT NULL,
  PRIMARY KEY (`id_Varzybos`),
  KEY `kuria` (`fk_Naudotojas_id`),
  CONSTRAINT `kuria` FOREIGN KEY (`fk_Naudotojas_id`) REFERENCES `Naudotojas` (`id_Naudotojas`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Varzybos`
--

LOCK TABLES `Varzybos` WRITE;
/*!40000 ALTER TABLE `Varzybos` DISABLE KEYS */;
INSERT INTO `Varzybos` VALUES ('2020-04-30','123456 Varzybos','Stadionas','naujas','2020-04-30',5,1);
/*!40000 ALTER TABLE `Varzybos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Varzybu_dalyvis`
--

DROP TABLE IF EXISTS `Varzybu_dalyvis`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Varzybu_dalyvis` (
  `fk_Naudotojas_id` int(11) NOT NULL,
  `fk_Varzybos_id` int(11) NOT NULL,
  PRIMARY KEY (`fk_Naudotojas_id`,`fk_Varzybos_id`),
  KEY `turi2` (`fk_Varzybos_id`),
  CONSTRAINT `turi2` FOREIGN KEY (`fk_Varzybos_id`) REFERENCES `Varzybos` (`id_Varzybos`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `yra` FOREIGN KEY (`fk_Naudotojas_id`) REFERENCES `Naudotojas` (`id_Naudotojas`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Varzybu_dalyvis`
--

LOCK TABLES `Varzybu_dalyvis` WRITE;
/*!40000 ALTER TABLE `Varzybu_dalyvis` DISABLE KEYS */;
INSERT INTO `Varzybu_dalyvis` VALUES (2,5);
/*!40000 ALTER TABLE `Varzybu_dalyvis` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Zinute`
--

DROP TABLE IF EXISTS `Zinute`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Zinute` (
  `tekstas` varchar(255) DEFAULT NULL,
  `issiuntimo_laikas` date DEFAULT NULL,
  `id_Zinute` int(11) NOT NULL AUTO_INCREMENT,
  `fk_Zinute_id` int(11) DEFAULT NULL,
  `fk_Siuntejas_id` int(11) NOT NULL,
  `fk_Gavejas_id` int(11) NOT NULL,
  PRIMARY KEY (`id_Zinute`),
  KEY `atsako` (`fk_Zinute_id`),
  KEY `siuncia` (`fk_Siuntejas_id`),
  KEY `gauna` (`fk_Gavejas_id`),
  CONSTRAINT `atsako` FOREIGN KEY (`fk_Zinute_id`) REFERENCES `Zinute` (`id_Zinute`),
  CONSTRAINT `gauna` FOREIGN KEY (`fk_Gavejas_id`) REFERENCES `Naudotojas` (`id_Naudotojas`),
  CONSTRAINT `siuncia` FOREIGN KEY (`fk_Siuntejas_id`) REFERENCES `Naudotojas` (`id_Naudotojas`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Zinute`
--

LOCK TABLES `Zinute` WRITE;
/*!40000 ALTER TABLE `Zinute` DISABLE KEYS */;
/*!40000 ALTER TABLE `Zinute` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'fitnessweb'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-02 10:57:50
