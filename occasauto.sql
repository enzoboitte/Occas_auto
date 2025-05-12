DROP DATABASE IF EXISTS `dboccasauto`;
CREATE DATABASE IF NOT EXISTS `dboccasauto`;
USE `dboccasauto`;

-- --------------------------------------------------------

--
-- Structure de la table `account`
--

DROP TABLE IF EXISTS `account`;
CREATE TABLE IF NOT EXISTS `account` (
  `id` int NOT NULL AUTO_INCREMENT,
  `idConces` int DEFAULT NULL,
  `passwd` varchar(100) DEFAULT NULL,
  `level` int NOT NULL DEFAULT '10',
  PRIMARY KEY (`id`),
  KEY `idConcessionnaire` (`idConces`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `account`
--

INSERT INTO `account` (`id`, `idConces`, `passwd`, `level`) VALUES
(1, 32, '1234', 1),
(2, 7, '1234', 10),
(3, 34, '1234', 10);

-- --------------------------------------------------------

--
-- Structure de la table `cartegrise`
--

DROP TABLE IF EXISTS `cartegrise`;
CREATE TABLE IF NOT EXISTS `cartegrise` (
  `id_proprietaire` int NOT NULL,
  `immatriculation` varchar(15) NOT NULL,
  `date_carte_grise` date DEFAULT NULL,
  PRIMARY KEY (`id_proprietaire`,`immatriculation`),
  KEY `immatriculation` (`immatriculation`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `cartegrise`
--

INSERT INTO `cartegrise` (`id_proprietaire`, `immatriculation`, `date_carte_grise`) VALUES
(1, 'BR-363-SJ', '2019-10-03'),
(1, 'SR-163-RJ', '2021-09-01'),
(1, 'BB-222-DE', '2023-01-31'),
(2, 'TB-652-OP', '2023-03-08'),
(3, 'SE-987-DD', '2021-05-01'),
(4, 'RT-578-CD', '2020-06-21'),
(4, 'CF-699-ZE', '2022-01-01'),
(4, 'AQ-748-UK', '2023-01-01'),
(5, 'TT-123-PM', '2019-09-22'),
(5, 'EY-745-NM', '2022-12-15'),
(6, 'AB-487-RE', '2022-10-25'),
(7, 'CV-789-XS', '2023-03-18'),
(8, 'FR-657-TX', '2023-03-10'),
(8, 'UI-325-FD', '2023-03-13');

-- --------------------------------------------------------

--
-- Structure de la table `concessionnaire`
--

DROP TABLE IF EXISTS `concessionnaire`;
CREATE TABLE IF NOT EXISTS `concessionnaire` (
  `idConces` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(15) NOT NULL,
  `prenom` varchar(15) NOT NULL,
  `adresse` varchar(50) NOT NULL,
  `codePostal` varchar(5) NOT NULL,
  `ville` varchar(20) NOT NULL,
  PRIMARY KEY (`idConces`)
) ENGINE=MyISAM AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `concessionnaire`
--

INSERT INTO `concessionnaire` (`idConces`, `nom`, `prenom`, `adresse`, `codePostal`, `ville`) VALUES
(1, 'Davolio', 'Jeanne', '5 rue de la poste', '63000', 'CLERMONT-FERRAND'),
(2, 'Fuller', 'Philippe', '254 avenue Berthelot', '63000', 'CLERMONT-FERRAND'),
(3, 'Daverling', 'Laura', '1 place de Jaude', '63000', 'CLERMONT-FERRAND'),
(4, 'Peacock', 'Emilie', '23, Impasse des Fleurs', '63000', 'CLERMONT-FERRAND'),
(5, 'Buchanan', 'Pierre', '32 place de l\'Hôtel de Ville', '63200', 'RIOM'),
(6, 'Bucyama', 'Michel', '15 rue des pinsons', '63200', 'RIOM'),
(7, 'King', 'Louis', '57 rue de la gare', '63500', 'ISSOIRE'),
(8, 'Callahan', 'Jean', '23 boulevard Central', '63500', 'ISSOIRE'),
(9, 'Bucsworth', 'Pierre', '7 rue de la paix', '63500', 'ISSOIRE'),
(10, 'Ducroc', 'Jacques', '12 rue des Lilas', '63000', 'CLERMONT-FERRAND'),
(11, 'Lemoine', 'Claire', '6 rue des Peupliers', '63000', 'CLERMONT-FERRAND'),
(12, 'Rochefort', 'Bernard', '47 rue des Acacias', '63000', 'CLERMONT-FERRAND'),
(13, 'Leblanc', 'Marie', '22 avenue des Champs', '63100', 'CLERMONT-FERRAND'),
(14, 'Monge', 'Julien', '14 rue Victor Hugo', '63100', 'CLERMONT-FERRAND'),
(15, 'Dufresne', 'Sophie', '78 boulevard Gambetta', '63100', 'CLERMONT-FERRAND'),
(16, 'Blanchet', 'Luc', '90 avenue des Volcans', '63200', 'RIOM'),
(17, 'Morel', 'Émilie', '34 rue de la Liberté', '63200', 'RIOM'),
(18, 'Durand', 'Alain', '7 rue de la République', '63200', 'RIOM'),
(19, 'Giraud', 'Manon', '13 place de la Résistance', '63300', 'THIERS'),
(20, 'Martin', 'Jean', '4 rue de l\'Horloge', '63300', 'THIERS'),
(21, 'Dupont', 'Hélène', '20 place des Forges', '63300', 'THIERS'),
(22, 'Bernard', 'Louis', '9 rue du Moulin', '63500', 'ISSOIRE'),
(23, 'Renard', 'Lucie', '44 rue des Tilleuls', '63500', 'ISSOIRE'),
(24, 'Collet', 'Mathieu', '56 avenue des Moulins', '63500', 'ISSOIRE'),
(25, 'Petit', 'Nathalie', '17 place du Marché', '63600', 'AMBERIEUX'),
(26, 'Girard', 'Alexandre', '5 avenue des Cerisiers', '63600', 'AMBERIEUX'),
(27, 'Leroux', 'Isabelle', '12 rue des Roches', '63600', 'AMBERIEUX'),
(28, 'Faure', 'Antoine', '8 boulevard des Écoles', '63700', 'ST ELOY LES MINES'),
(32, 'Boitte', 'Enzo', '7 rue du 19 mars', '63250', 'CELLES-SUR-DUROLLE');

-- --------------------------------------------------------

--
-- Structure de la table `modele`
--

DROP TABLE IF EXISTS `modele`;
CREATE TABLE IF NOT EXISTS `modele` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) NOT NULL,
  `marque` varchar(50) NOT NULL,
  `carburant` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `modele`
--

INSERT INTO `modele` (`id`, `nom`, `marque`, `carburant`) VALUES
(1, '207', 'Peugeot', 'essence'),
(2, '207', 'Peugeot', 'diesel'),
(3, '308', 'Peugeot', 'essence'),
(4, '308', 'Peugeot', 'diesel'),
(5, 'C2', 'Citroën', 'essence'),
(6, 'C2', 'Citroën', 'diesel'),
(7, 'C3 Picasso', 'Citroën', 'diesel'),
(8, 'A3', 'Audi', 'diesel'),
(9, 'A4', 'Audi', 'diesel'),
(10, '308', 'peugeot', 'diesel');

-- --------------------------------------------------------

--
-- Structure de la table `proprietaire`
--

DROP TABLE IF EXISTS `proprietaire`;
CREATE TABLE IF NOT EXISTS `proprietaire` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) NOT NULL,
  `prenom` varchar(50) NOT NULL,
  `adresse` varchar(100) DEFAULT NULL,
  `codepostal` varchar(10) DEFAULT NULL,
  `ville` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `proprietaire`
--

INSERT INTO `proprietaire` (`id`, `nom`, `prenom`, `adresse`, `codepostal`, `ville`) VALUES
(1, 'DURAND', 'Yves', '40 rue du Breuil', '63118', 'CEBAZAT'),
(2, 'DUPUY', 'Charles', '5 place de Jaude', '63000', 'CLERMONT'),
(3, 'DURAND', 'Bernard', '130 avenue Berthelot', '66500', 'ISSOIRE'),
(4, 'MERLE', 'Caroline', '85 rue du temple', '63000', 'CLERMONT'),
(5, 'GARDY', 'Sylvie', '10 rue du port', '63000', 'CLERMONT'),
(6, 'JOBALET', 'Pascal', '54 avenue de la liberté', '63500', 'ISSOIRE'),
(7, 'VAISSEL', 'Stéphane', '18 place de Jaude', '63000', 'CLERMONT'),
(8, 'VAITOLET', 'Sabine', '30 impasse du fort', '63200', 'RIOM'),
(9, 'VAITOLET', 'Jean', '30 impasse du fort', '63200', 'RIOM'),
(10, 'VAZEL', 'Pascal', '3 rue Zola', '63000', 'CLERMONT');

-- --------------------------------------------------------

--
-- Structure de la table `voiture`
--

DROP TABLE IF EXISTS `voiture`;
CREATE TABLE IF NOT EXISTS `voiture` (
  `immatriculation` varchar(15) NOT NULL,
  `id_modele` int DEFAULT NULL,
  `places` int DEFAULT NULL,
  `mise_en_circulation` date DEFAULT NULL,
  PRIMARY KEY (`immatriculation`),
  KEY `id_modele` (`id_modele`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `voiture`
--

INSERT INTO `voiture` (`immatriculation`, `id_modele`, `places`, `mise_en_circulation`) VALUES
('BR-363-SJ', 1, 5, '2018-09-04'),
('SR-163-RJ', 2, 5, '2020-04-01'),
('BB-222-DE', 2, 5, '2022-10-01'),
('CV-789-XS', 2, 5, '2021-09-07'),
('SE-987-DD', 4, 5, '2020-01-01'),
('RT-578-CD', 4, 5, '2020-01-01'),
('CF-699-ZE', 5, 4, '2021-03-01'),
('AQ-748-UK', 5, 4, '2021-10-05'),
('TT-123-PM', 6, 4, '2016-12-10'),
('EY-745-NM', 7, 5, '2022-05-02'),
('AB-487-RE', 7, 7, '2022-04-20'),
('TB-652-OP', 7, 7, '2023-02-01'),
('FR-657-TX', 8, 4, '2023-01-05'),
('UI-325-FD', 8, 4, '2022-08-04');
COMMIT;
