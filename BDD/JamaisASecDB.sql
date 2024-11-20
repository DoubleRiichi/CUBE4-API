CREATE DATABASE IF NOT EXISTS JamaisASecDB;
USE JamaisASecDB;

-- Table Familles
CREATE TABLE Familles (
    id INT UNSIGNED  AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(200) NOT NULL
);

-- Table Maisons
CREATE TABLE Maisons (
    id INT UNSIGNED  AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(200) NOT NULL
);

-- Table Articles
CREATE TABLE Articles (
    id INT UNSIGNED  AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(200) NOT NULL,
    quantité INT UNSIGNED  NOT NULL,
    image VARCHAR(400),
    prix_unitaire INT UNSIGNED  NOT NULL,
    colissage VARCHAR(200),
    quantité_min INT UNSIGNED  NOT NULL,
    année INT UNSIGNED  NOT NULL,
    description TEXT,
    familles_id INT UNSIGNED ,
    maisons_id INT UNSIGNED ,
    FOREIGN KEY (familles_id) REFERENCES Familles(id),
    FOREIGN KEY (maisons_id) REFERENCES Maisons(id)
);

-- Table Clients
CREATE TABLE Clients (
    id INT UNSIGNED  AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(200) NOT NULL,
    adresse VARCHAR(400),
    mail VARCHAR(320),
    téléphone VARCHAR(12)
);

-- Table Fournisseurs
CREATE TABLE Fournisseurs (
    id INT UNSIGNED  AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(200) NOT NULL,
    adresse VARCHAR(400),
    mail VARCHAR(320),
    téléphone VARCHAR(12),
    SIRET VARCHAR(20)
);

-- Table Commandes
CREATE TABLE Commandes (
    id INT UNSIGNED  AUTO_INCREMENT PRIMARY KEY,
    référence VARCHAR(16) NOT NULL,
    date DATETIME NOT NULL,
    status VARCHAR(30),
    articles_commandes_id INT UNSIGNED ,
    clients_id INT UNSIGNED ,
    fournisseurs_id INT UNSIGNED ,
    FOREIGN KEY (articles_commandes_id) REFERENCES ArticlesCommandes(id),
    FOREIGN KEY (clients_id) REFERENCES Clients(id),
    FOREIGN KEY (fournisseurs_id) REFERENCES Fournisseurs(id)
);

-- Table ArticlesCommandes
CREATE TABLE ArticlesCommandes (
    id INT UNSIGNED  AUTO_INCREMENT PRIMARY KEY,
    articles_id INT UNSIGNED ,
    commandes_id INT UNSIGNED ,
    FOREIGN KEY (articles_id) REFERENCES Articles(id),
    FOREIGN KEY (commandes_id) REFERENCES Commandes(id)
);

