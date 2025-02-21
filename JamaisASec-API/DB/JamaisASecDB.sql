-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 19, 2025 at 09:57 AM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `jamaisasecdb`
--
CREATE DATABASE IF NOT EXISTS `jamaisasecdb` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `jamaisasecdb`;

-- --------------------------------------------------------

--
-- Table structure for table `articles`
--

DROP TABLE IF EXISTS `articles`;
CREATE TABLE `articles` (
  `id` int(10) UNSIGNED NOT NULL,
  `nom` varchar(200) NOT NULL,
  `quantite` int(10) UNSIGNED NOT NULL,
  `image` varchar(400) DEFAULT NULL,
  `prix_unitaire` int(10) UNSIGNED NOT NULL,
  `colisage` int(10) UNSIGNED NOT NULL,
  `quantite_min` int(10) UNSIGNED NOT NULL,
  `annee` int(10) UNSIGNED NOT NULL,
  `description` text DEFAULT NULL,
  `familles_id` int(10) UNSIGNED DEFAULT NULL,
  `maisons_id` int(10) UNSIGNED DEFAULT NULL,
  `fournisseurs_id` int(11) UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `articles`
--

INSERT INTO `articles` (`id`, `nom`, `quantite`, `image`, `prix_unitaire`, `colisage`, `quantite_min`, `annee`, `description`, `familles_id`, `maisons_id`, `fournisseurs_id`) VALUES
(1, 'Bordeaux Rouge Prestige', 50, 'bordeaux_rouge.jpg', 25.50, 6, 1, 2018, 'Un Bordeaux rouge aux arômes fruités.', 1, 1, 1),
(2, 'Bordeaux Blanc Excellence', 40, 'bordeaux_blanc.jpg', 22.00, 6, 1, 2020, 'Un blanc sec et équilibré.', 2, 7, 1),
(3, 'Champagne Brut Millésimé', 60, 'champagne_brut.jpg', 45.90, 3, 1, 2015, 'Un champagne raffiné et festif.', 4, 3, 2),
(4, 'Champagne Rosé Élite', 55, 'champagne_rose.jpg', 50.00, 3, 1, 2017, 'Un rosé pétillant et délicat.', 3, 9, 2),
(5, 'Rosé de Provence Prestige', 70, 'rose_provence.jpg', 18.75, 6, 1, 2021, 'Un rosé léger et fruité.', 3, 5, 3),
(6, 'Blanc de Provence Fraîcheur', 45, 'blanc_provence.jpg', 20.30, 6, 1, 2019, 'Un blanc minéral et rafraîchissant.', 2, 7, 3),
(7, 'Languedoc Rouge Tradition', 80, 'rouge_languedoc.jpg', 17.50, 6, 1, 2020, 'Un rouge corsé et équilibré.', 1, 6, 4),
(8, 'Blanc du Languedoc Sélection', 65, 'blanc_languedoc.jpg', 19.90, 6, 1, 2019, 'Un blanc floral et fruité.', 2, 8, 4),
(9, 'Vin Bio Naturel Rouge', 50, 'bio_rouge.jpg', 28.00, 6, 1, 2022, 'Un rouge bio naturel aux arômes intenses.', 7, 2, 5),
(10, 'Vin Bio Blanc Harmonie', 40, 'bio_blanc.jpg', 26.50, 6, 1, 2021, 'Un blanc bio aux notes subtiles.', 7, 7, 5),
(11, 'Bourgogne Chardonnay Élégance', 55, 'bourgogne_blanc.jpg', 35.00, 6, 1, 2018, 'Un chardonnay aux notes beurrées et fruitées.', 2, 10, 6),
(12, 'Bourgogne Pinot Noir Intense', 60, 'bourgogne_rouge.jpg', 38.50, 6, 1, 2017, 'Un rouge puissant et équilibré.', 1, 6, 6),
(13, 'Champagne Extra Brut Réserve', 70, 'champagne_extra.jpg', 55.00, 3, 1, 2014, 'Un extra brut d’exception.', 4, 3, 7),
(14, 'Champagne Blanc de Blancs Grand Cru', 50, 'blanc_de_blancs.jpg', 60.00, 3, 1, 2016, 'Un blanc de blancs raffiné et complexe.', 6, 9, 7),
(15, 'Riesling Grand Cru Alsace', 40, 'riesling.jpg', 29.50, 6, 1, 2020, 'Un riesling minéral et aromatique.', 2, 5, 8),
(16, 'Gewurztraminer Sélection', 45, 'gewurztraminer.jpg', 32.00, 6, 1, 2019, 'Un blanc épicé et floral.', 2, 10, 8),
(17, 'Côte du Rhône Syrah Prestige', 50, 'rhone_rouge.jpg', 22.75, 6, 1, 2019, 'Un rouge puissant et épicé.', 1, 8, 9),
(18, 'Viognier Blanc du Rhône', 55, 'viognier.jpg', 24.90, 6, 1, 2020, 'Un blanc riche et fruité.', 2, 7, 9),
(19, 'Corse Rouge Terroir', 60, 'corse_rouge.jpg', 20.50, 6, 1, 2021, 'Un rouge corsé et généreux.', 1, 6, 10),
(20, 'Corse Blanc Fraîcheur', 50, 'corse_blanc.jpg', 22.00, 6, 1, 2020, 'Un blanc frais et expressif.', 2, 5, 10),
(21, 'Bordeaux Supérieur Tradition', 55, 'bordeaux_superieur.jpg', 23.50, 6, 1, 2018, 'Un Bordeaux rouge profond et structuré.', 1, 1, 1),
(22, 'Rosé Plaisir', 65, 'rose_plaisir.jpg', 19.90, 6, 1, 2021, 'Un rosé idéal.', 3, 5, 3),
(23, 'Vin Doux Naturel Muscat', 40, 'vin_doux_muscat.jpg', 27.50, 6, 1, 2019, 'Un vin doux aux notes de miel et d’abricot.', 5, 10, 5),
(24, 'Grand Cru Bourgogne Pinot Noir', 50, 'grand_cru_bourgogne.jpg', 42.00, 6, 1, 2016, 'Un pinot noir d’exception.', 1, 6, 6),
(25, 'Crémant d Alsace Élégance', 45, 'cremant_alsace.jpg', 33.00, 6, 1, 2017, 'Un crémant fin et délicat.', 6, 9, 8),
(26, 'Sauternes Liquoreux', 35, 'sauternes.jpg', 55.00, 6, 1, 2015, 'Un vin liquoreux au bouquet complexe.', 5, 4, 4),
(27, 'Côte-Rôtie Vieilles Vignes', 38, 'cote_rotie.jpg', 48.00, 6, 1, 2016, 'Un vin rouge puissant et élégant.', 1, 8, 9),
(28, 'Vin Naturel Rouge Authentique', 40, 'naturel_rouge.jpg', 30.00, 6, 1, 2021, 'Un vin naturel sans sulfites.', 8, 2, 5),
(29, 'Vin Primeur Fruité', 70, 'vin_primeur.jpg', 15.50, 6, 1, 2023, 'Un primeur léger et fruité.', 9, 1, 3),
(30, 'Châteauneuf-du-Pape Excellence', 45, 'chateauneuf.jpg', 50.00, 6, 1, 2017, 'Un rouge complexe et structuré.', 1, 8, 9)
(31, 'Maison Mumm Cordon Rouge', 200, 'mumm_cordon_rouge.jpg', 35, 12, 6, 2023, 'Champagne brut aux notes de pomme et de brioche.', 4, 3, 2),
(32, 'Chateau d Yquem 2010', 30, 'yquem_2010.jpg', 300, 6, 1, 2010, 'Vin doux liquoreux avec des aromes de miel et de fruits exotiques.', 5, 4, 2),
(33, 'Chateau Petrus 2012', 20, 'petrus_2012.jpg', 3000, 3, 1, 2012, 'Vin rouge exceptionnel avec des notes de prune et de truffe.', 1, 5, 1),
(34, 'Domaine Leroy Bourgogne Blanc 2020', 100, 'leroy_blanc_2020.jpg', 150, 6, 2, 2020, 'Vin blanc bio aux aromes floraux et mineraux.', 2, 6, 3),
(35, 'Domaine Leflaive Puligny-Montrachet 2019', 80, 'leflaive_puligny_2019.jpg', 450, 6, 1, 2019, 'Vin blanc complexe avec une belle acidite et des notes de noisette.', 2, 7, 4),
(36, 'Chateau Haut-Brion 2016', 150, 'haut_brion_2016.jpg', 900, 6, 1, 2016, 'Vin rouge equilibre avec des tanins soyeux et des notes de cassis.', 1, 8, 2),
(37, 'Maison Ruinart Blanc de Blancs', 200, 'ruinart_blanc.jpg', 70, 12, 6, 2022, 'Champagne elegant avec des aromes de citron et de fleurs blanches.', 4, 9, 3),
(38, 'Chateau Cheval Blanc 2018', 60, 'cheval_blanc_2018.jpg', 1200, 6, 1, 2018, 'Vin rouge intense aux notes de fruits noirs et d epices.', 1, 10, 5);

-- --------------------------------------------------------

--
-- Table structure for table `articlescommandes`
--

DROP TABLE IF EXISTS `articlescommandes`;
CREATE TABLE `articlescommandes` (
  `id` int(10) UNSIGNED NOT NULL,
  `quantite` int(10) UNSIGNED NOT NULL,
  `articles_id` int(10) UNSIGNED DEFAULT NULL,
  `commandes_id` int(10) UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `articlescommandes`
--

INSERT INTO `articlescommandes` (`quantite`, `articles_id`, `commandes_id`) VALUES
(3, 5, 1),
(2, 10, 1),
(6, 13, 1),
(3, 26, 1),
(4, 13, 1),
(4, 3, 2),
(6, 4, 2),
(5, 1, 3),
(3, 2, 3),
(2, 3, 3),
(7, 9, 4),
(3, 18, 4),
(6, 25, 4),
(3, 18, 4),
(9, 14, 4),
(4, 12, 5),
(6, 20, 5),
(2, 27, 5),
(3, 12, 5),
(9, 16, 5),
(3, 6, 6),
(5, 22, 6),
(2, 8, 7),
(7, 30, 7),
(6, 29, 7),
(3, 17, 7),
(9, 23, 7),
(4, 14, 8),
(5, 25, 8),
(6, 19, 9),
(3, 28, 9),
(5, 16, 10),
(4, 27, 10),
(3, 7, 11),
(5, 8, 11),
(2, 26, 11),
(4, 11, 12),
(3, 12, 12),
(5, 24, 12),
(6, 15, 13),
(2, 16, 13),
(4, 25, 13),
(3, 13, 14),
(5, 14, 14);




-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

DROP TABLE IF EXISTS `clients`;
CREATE TABLE `clients` (
  `id` int(10) UNSIGNED NOT NULL,
  `nom` varchar(200) NOT NULL,
  `adresse` varchar(400) DEFAULT NULL,
  `mail` varchar(320) DEFAULT NULL,
  `mot_de_passe` varchar(500) NOT NULL,
  `telephone` varchar(12) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`id`, `nom`, `adresse`, `mail`, `mot_de_passe`, `telephone`) VALUES
(1, 'Caviste Parisien', '15 rue de la Vigne, Paris', 'caviste.paris@gmail.com', 'default', '0142234455'),
(2, 'Restaurant etoile', '12 avenue des Grands Crus, Lyon', 'etoile.lyon@gmail.com', 'default', '0478223344'),
(3, 'Collectionneur Prive', '8 rue des Vins Rares, Bordeaux', 'prive.bordeaux@gmail.com', 'default', '0556778899'),
(4, 'Grande Surface', '1 boulevard du Commerce, Lille', 'gs.lille@gmail.com', 'default', '0322984455'),
(5, 'Exportateur USA', '47 avenue des Vignerons, Marseille', 'export.usa@gmail.com', 'default', '0491123344'),
(6, 'Caviste Bio', '22 rue des Vins Bios, Toulouse', 'bio.toulouse@gmail.com', 'default', '0567341234'),
(7, 'Hotel de Luxe', '9 rue des Sommeliers, Cannes', 'hotel.luxe@gmail.com', 'default', '0493945566'),
(8, 'Boutique Vinotheque', '6 avenue des Cepages, Strasbourg', 'vinotheque.strasbourg@gmail.com', 'default', '0388123345'),
(9, 'Particulier Passionne', '18 rue des Amateurs, Nice', 'particulier.nice@gmail.com', 'default', '0493145567'),
(10, 'Organisation evenementielle', '5 rue des Receptions, Nantes', 'events.nantes@gmail.com', 'default', '0256341122'),
(11, 'Jeans', 'Adresszijdzeijdi', 'test@tes33t.fr', 'default', '+33145786523');

-- --------------------------------------------------------

--
-- Table structure for table `commandes`
--

DROP TABLE IF EXISTS `commandes`;
CREATE TABLE `commandes` (
  `id` int(10) UNSIGNED NOT NULL,
  `reference` varchar(16) NOT NULL,
  `date` datetime NOT NULL,
  `status` varchar(30) DEFAULT NULL,
  `clients_id` int(10) UNSIGNED DEFAULT NULL,
  `fournisseurs_id` int(10) UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `commandes`
--

INSERT INTO `commandes` (`id`, `reference`, `date`, `status`, `clients_id`, `fournisseurs_id`) VALUES
(1, 'CMD001', '2024-11-01 10:00:00', 'En cours', 1, NULL),
(2, 'CMD002', '2024-11-03 14:00:00', 'Receptionnee', NULL, 2),
(3, 'CMD003', '2024-11-03 16:00:00', 'En cours', NULL, 1),
(4, 'CMD004', '2024-11-04 16:00:00', 'Annulee', 4, NULL),
(5, 'CMD005', '2024-11-05 18:00:00', 'En cours', 5, NULL),
(6, 'CMD006', '2024-11-06 20:00:00', 'Livree', 6, NULL),
(7, 'CMD007', '2024-11-07 22:00:00', 'Confirmee', 7, NULL),
(8, 'CMD008', '2024-11-08 08:00:00', 'Livree', 8, NULL),
(9, 'CMD009', '2024-11-09 11:00:00', 'En cours', 9, NULL),
(10, 'CMD010', '2024-11-10 15:00:00', 'Livree', 10, NULL),
(11, 'CMD011', '2024-11-08 08:00:00', 'Receptionnee', NULL, 4),
(12, 'CMD012', '2024-11-09 11:00:00', 'En attente', NULL, 6),
(13, 'CMD013', '2024-11-10 15:00:00', 'Receptionnee', NULL, 8),
(14, 'CMD014', '2024-11-11 12:00:00', 'En attente', NULL, 7);

-- --------------------------------------------------------

--
-- Table structure for table `familles`
--

DROP TABLE IF EXISTS `familles`;
CREATE TABLE `familles` (
  `id` int(10) UNSIGNED NOT NULL,
  `nom` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `familles`
--

INSERT INTO `familles` (`id`, `nom`) VALUES
(1, 'Rouge'),
(2, 'Blanc'),
(3, 'Rosé'),
(4, 'Champagne'),
(5, 'Vin doux'),
(6, 'Vin effervescent'),
(7, 'Vin bio'),
(8, 'Vin naturel'),
(9, 'Vin primeur'),
(10, 'Vin de garde');

-- --------------------------------------------------------

--
-- Table structure for table `fournisseurs`
--

DROP TABLE IF EXISTS `fournisseurs`;
CREATE TABLE `fournisseurs` (
  `id` int(10) UNSIGNED NOT NULL,
  `nom` varchar(200) NOT NULL,
  `adresse` varchar(400) DEFAULT NULL,
  `mail` varchar(320) DEFAULT NULL,
  `telephone` varchar(12) DEFAULT NULL,
  `SIRET` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `fournisseurs`
--

INSERT INTO `fournisseurs` (`id`, `nom`, `adresse`, `mail`, `telephone`, `SIRET`) VALUES
(1, 'Maison Bordeaux Sud', '34 rue des Graves, Bordeaux', 'contact@bordeauxsud.fr', '0556341122', '11223344556677'),
(2, 'Maison de Champagne', '8 avenue des Champagnes, Reims', 'contact@champagne.fr', '0326347788', '22334455667788'),
(3, 'Vignobles de Provence', '12 route des Roses, Aix-en-Provence', 'contact@vignoblesprovence.fr', '0490112233', '33445566778899'),
(4, 'Domaines Languedoc', '45 chemin des Cepages, Montpellier', 'contact@languedoc.fr', '0467231122', '44556677889900'),
(5, 'Vin Naturel Bio', '25 avenue des Vins Bios, Nantes', 'contact@vinbio.fr', '0244113344', '55667788990011'),
(6, 'Grands Crus Bourgogne', '14 allée des Chardonnays, Dijon', 'contact@grandscrus.fr', '0388223344', '66778899001122'),
(7, 'Champagnes Millesimes', '10 place des Vins Effervescents, epernay', 'contact@champagnesmill.fr', '0322445566', '77889900112233'),
(8, 'Caves Alsaciennes', '22 rue des Rieslings, Colmar', 'contact@cavesalsace.fr', '0389112233', '88990011223344'),
(9, 'Vins du Rhone', '38 route des Syrahs, Lyon', 'contact@vinsdurhone.fr', '0478223345', '99001122334455'),
(10, 'Vignobles Corse', '7 chemin des Domaines, Ajaccio', 'contact@vignoblescorse.fr', '0495112234', '10112233445566');

-- --------------------------------------------------------

--
-- Table structure for table `maisons`
--

DROP TABLE IF EXISTS `maisons`;
CREATE TABLE `maisons` (
  `id` int(10) UNSIGNED NOT NULL,
  `nom` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `maisons`
--

INSERT INTO `maisons` (`id`, `nom`) VALUES
(1, 'Chateau Margaux'),
(2, 'Domaine de la Romanee-Conti'),
(3, 'Maison Mumm'),
(4, 'Chateau d Yquem'),
(5, 'Chateau Petrus'),
(6, 'Domaine Leroy'),
(7, 'Domaine Leflaive'),
(8, 'Chateau Haut-Brion'),
(9, 'Maison Ruinart'),
(10, 'Chateau Cheval Blanc');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `articles`
--
ALTER TABLE `articles`
  ADD PRIMARY KEY (`id`),
  ADD KEY `articles_ibfk_1` (`familles_id`),
  ADD KEY `articles_ibfk_2` (`maisons_id`),
  ADD KEY `articles_ibfk_3` (`fournisseurs_id`);

--
-- Indexes for table `articlescommandes`
--
ALTER TABLE `articlescommandes`
  ADD PRIMARY KEY (`id`),
  ADD KEY `articlescommandes_ibfk_1` (`articles_id`),
  ADD KEY `articlescommandes_ibfk_2` (`commandes_id`);

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `commandes`
--
ALTER TABLE `commandes`
  ADD PRIMARY KEY (`id`),
  ADD KEY `clients_id` (`clients_id`),
  ADD KEY `fournisseurs_id` (`fournisseurs_id`);

--
-- Indexes for table `familles`
--
ALTER TABLE `familles`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `fournisseurs`
--
ALTER TABLE `fournisseurs`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `maisons`
--
ALTER TABLE `maisons`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `articles`
--
ALTER TABLE `articles`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `articlescommandes`
--
ALTER TABLE `articlescommandes`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `commandes`
--
ALTER TABLE `commandes`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `familles`
--
ALTER TABLE `familles`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `fournisseurs`
--
ALTER TABLE `fournisseurs`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `maisons`
--
ALTER TABLE `maisons`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `articles`
--
ALTER TABLE `articles`
  ADD CONSTRAINT `articles_ibfk_1` FOREIGN KEY (`familles_id`) REFERENCES `familles` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `articles_ibfk_2` FOREIGN KEY (`maisons_id`) REFERENCES `maisons` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `articles_ibfk_3` FOREIGN KEY (`fournisseurs_id`) REFERENCES `fournisseurs` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `articlescommandes`
--
ALTER TABLE `articlescommandes`
  ADD CONSTRAINT `articlescommandes_ibfk_1` FOREIGN KEY (`articles_id`) REFERENCES `articles` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `articlescommandes_ibfk_2` FOREIGN KEY (`commandes_id`) REFERENCES `commandes` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `commandes`
--
ALTER TABLE `commandes`
  ADD CONSTRAINT `commandes_ibfk_1` FOREIGN KEY (`clients_id`) REFERENCES `clients` (`id`),
  ADD CONSTRAINT `commandes_ibfk_2` FOREIGN KEY (`fournisseurs_id`) REFERENCES `fournisseurs` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
