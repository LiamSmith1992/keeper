CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture',
        coverImg VARCHAR(255) COMMENT 'User Cover Img'
    ) default charset utf8 COMMENT '';

DROP TABLE accounts;

CREATE TABLE
    keeps(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        creatorId VARCHAR(255) NOT NULL,
        name VARCHAR(55) NOT NULL,
        description TEXT NOT NULL,
        img VARCHAR(255) NOT NULL DEFAULT 'https://www.beano.com/wp-content/uploads/legacy/81700_rose.jpg?w=485&strip=all&quality=85',
        views INT NOT NULL DEFAULT 0,
        kept INT NOT NULL DEFAULT 0,
        FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

DROP Table keeps;

CREATE TABLE
    vaults(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        creatorId VARCHAR(255) NOT NULL,
        name VARCHAR(55) NOT NULL,
        description TEXT NOT NULL,
        img VARCHAR(255) NOT NULL,
        isPrivate BOOL DEFAULT false,
        FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

DROP TABLE vaults;

CREATE TABLE
    vaultKeeps(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        creatorId VARCHAR(255) NOT NULL,
        vaultId INT NOT NULL,
        keepId INT NOT NULL,
        Foreign Key (creatorId) REFERENCES accounts (id) ON DELETE CASCADE,
        Foreign Key (vaultId) REFERENCES vaults (id) ON DELETE CASCADE,
        Foreign Key (keepId) REFERENCES keeps (id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

DROP TABLE vaultKeeps;