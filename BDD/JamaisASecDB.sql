-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 20, 2024 at 12:00 PM
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

-- --------------------------------------------------------

--
-- Table structure for table `articles`
--

CREATE TABLE `articles` (
  `id` int(10) UNSIGNED NOT NULL,
  `nom` varchar(200) NOT NULL,
  `quantité` int(10) UNSIGNED NOT NULL,
  `image` varchar(400) DEFAULT NULL,
  `prix_unitaire` int(10) UNSIGNED NOT NULL,
  `colisage` int(10) UNSIGNED NOT NULL,
  `quantité_min` int(10) UNSIGNED NOT NULL,
  `année` int(10) UNSIGNED NOT NULL,
  `description` text DEFAULT NULL,
  `familles_id` int(10) UNSIGNED DEFAULT NULL,
  `maisons_id` int(10) UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `articles`
--

INSERT INTO `articles` (`id`, `nom`, `quantité`, `image`, `prix_unitaire`, `colisage`, `quantité_min`, `année`, `description`, `familles_id`, `maisons_id`) VALUES
(1, 'Chateau Margaux 2015', 120, 'margaux_2015.jpg', 1200, 6, 1, 2015, 'Vin rouge elegant aux aromes de fruits rouges et notes boisees.', 1, 1),
(2, 'Romanee-Conti 2018', 50, 'romanee_conti_2018.jpg', 20000, 1, 1, 2018, 'Un vin mythique, riche et complexe.', 1, 2),
(3, 'Maison Mumm Cordon Rouge', 200, 'mumm_cordon_rouge.jpg', 35, 12, 6, 2023, 'Champagne brut aux notes de pomme et de brioche.', 4, 3),
(4, 'Chateau d Yquem 2010', 30, 'yquem_2010.jpg', 300, 6, 1, 2010, 'Vin doux liquoreux avec des aromes de miel et de fruits exotiques.', 5, 4),
(5, 'Chateau Petrus 2012', 20, 'petrus_2012.jpg', 3000, 3, 1, 2012, 'Vin rouge exceptionnel avec des notes de prune et de truffe.', 1, 5),
(6, 'Domaine Leroy Bourgogne Blanc 2020', 100, 'leroy_blanc_2020.jpg', 150, 6, 2, 2020, 'Vin blanc bio aux aromes floraux et mineraux.', 2, 6),
(7, 'Domaine Leflaive Puligny-Montrachet 2019', 80, 'leflaive_puligny_2019.jpg', 450, 6, 1, 2019, 'Vin blanc complexe avec une belle acidite et des notes de noisette.', 2, 7),
(8, 'Chateau Haut-Brion 2016', 150, 'haut_brion_2016.jpg', 900, 6, 1, 2016, 'Vin rouge equilibre avec des tanins soyeux et des notes de cassis.', 1, 8),
(9, 'Maison Ruinart Blanc de Blancs', 200, 'ruinart_blanc.jpg', 70, 12, 6, 2022, 'Champagne elegant avec des aromes de citron et de fleurs blanches.', 4, 9),
(10, 'Chateau Cheval Blanc 2018', 60, 'cheval_blanc_2018.jpg', 1200, 6, 1, 2018, 'Vin rouge intense aux notes de fruits noirs et d epices.', 1, 10);

-- --------------------------------------------------------

--
-- Table structure for table `articlescommandes`
--

CREATE TABLE `articlescommandes` (
  `id` int(10) UNSIGNED NOT NULL,
  `articles_id` int(10) UNSIGNED DEFAULT NULL,
  `commandes_id` int(10) UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `articlescommandes`
--

INSERT INTO `articlescommandes` (`id`, `articles_id`, `commandes_id`) VALUES
(1, 4, 1),
(2, 6, 6),
(3, 4, 1),
(4, 6, 6),
(5, 5, 2),
(6, 2, 3),
(7, 3, 5),
(8, 1, 4),
(9, 3, 6),
(10, 8, 7),
(11, 9, 8),
(12, 4, 9),
(13, 4, 10),
(14, 4, 9);

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `id` int(10) UNSIGNED NOT NULL,
  `nom` varchar(200) NOT NULL,
  `adresse` varchar(400) DEFAULT NULL,
  `mail` varchar(320) DEFAULT NULL,
  `téléphone` varchar(12) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`id`, `nom`, `adresse`, `mail`, `téléphone`) VALUES
(1, 'Caviste Parisien', '15 rue de la Vigne, Paris', 'caviste.paris@gmail.com', '0142234455'),
(2, 'Restaurant etoile', '12 avenue des Grands Crus, Lyon', 'etoile.lyon@gmail.com', '0478223344'),
(3, 'Collectionneur Prive', '8 rue des Vins Rares, Bordeaux', 'prive.bordeaux@gmail.com', '0556778899'),
(4, 'Grande Surface', '1 boulevard du Commerce, Lille', 'gs.lille@gmail.com', '0322984455'),
(5, 'Exportateur USA', '47 avenue des Vignerons, Marseille', 'export.usa@gmail.com', '0491123344'),
(6, 'Caviste Bio', '22 rue des Vins Bios, Toulouse', 'bio.toulouse@gmail.com', '0567341234'),
(7, 'Hotel de Luxe', '9 rue des Sommeliers, Cannes', 'hotel.luxe@gmail.com', '0493945566'),
(8, 'Boutique Vinotheque', '6 avenue des Cepages, Strasbourg', 'vinotheque.strasbourg@gmail.com', '0388123345'),
(9, 'Particulier Passionne', '18 rue des Amateurs, Nice', 'particulier.nice@gmail.com', '0493145567'),
(10, 'Organisation evenementielle', '5 rue des Receptions, Nantes', 'events.nantes@gmail.com', '0256341122');

-- --------------------------------------------------------

--
-- Table structure for table `commandes`
--

CREATE TABLE `commandes` (
  `id` int(10) UNSIGNED NOT NULL,
  `référence` varchar(16) NOT NULL,
  `date` datetime NOT NULL,
  `status` varchar(30) DEFAULT NULL,
  `clients_id` int(10) UNSIGNED DEFAULT NULL,
  `fournisseurs_id` int(10) UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `commandes`
--

INSERT INTO `commandes` (`id`, `référence`, `date`, `status`, `clients_id`, `fournisseurs_id`) VALUES
(1, 'CMD001', '2024-11-01 10:00:00', 'En attente', 1, 1),
(2, 'CMD002', '2024-11-02 12:00:00', 'Confirmee', 2, 2),
(3, 'CMD003', '2024-11-03 14:00:00', 'Livree', 3, 3),
(4, 'CMD004', '2024-11-04 16:00:00', 'Annulee', 4, 4),
(5, 'CMD005', '2024-11-05 18:00:00', 'En attente', 5, 5),
(6, 'CMD006', '2024-11-06 20:00:00', 'Livree', 6, 6),
(7, 'CMD007', '2024-11-07 22:00:00', 'Confirmee', 7, 7),
(8, 'CMD008', '2024-11-08 08:00:00', 'Livree', 8, 8),
(9, 'CMD009', '2024-11-09 11:00:00', 'En attente', 9, 9),
(10, 'CMD010', '2024-11-10 15:00:00', 'Confirmee', 10, 10);

-- --------------------------------------------------------

--
-- Table structure for table `familles`
--

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

CREATE TABLE `fournisseurs` (
  `id` int(10) UNSIGNED NOT NULL,
  `nom` varchar(200) NOT NULL,
  `adresse` varchar(400) DEFAULT NULL,
  `mail` varchar(320) DEFAULT NULL,
  `téléphone` varchar(12) DEFAULT NULL,
  `SIRET` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `fournisseurs`
--

INSERT INTO `fournisseurs` (`id`, `nom`, `adresse`, `mail`, `téléphone`, `SIRET`) VALUES
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
  ADD KEY `articles_ibfk_2` (`maisons_id`);

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
  ADD KEY `commandes_ibfk_2` (`clients_id`),
  ADD KEY `commandes_ibfk_3` (`fournisseurs_id`);

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
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `commandes`
--
ALTER TABLE `commandes`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

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
  ADD CONSTRAINT `articles_ibfk_2` FOREIGN KEY (`maisons_id`) REFERENCES `maisons` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

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
  ADD CONSTRAINT `commandes_ibfk_2` FOREIGN KEY (`clients_id`) REFERENCES `clients` (`id`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `commandes_ibfk_3` FOREIGN KEY (`fournisseurs_id`) REFERENCES `fournisseurs` (`id`) ON DELETE SET NULL ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
