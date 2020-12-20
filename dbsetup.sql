-- CREATE TABLE profiles (
--     id VARCHAR(255) NOT NULL,
--     name VARCHAR(255) NOT NULL,
--     email VARCHAR(255) NOT NULL,
--     picture VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id)
-- )
-- CREATE TABLE items(
--     title VARCHAR(80) NOT NULL,
--     body VARCHAR(255) NOT NULL,
--     image VARCHAR(255) NOT NULL,
--     price INT NOT NULL,
--     salePrice DECIMAL,
--     quantity INT NOT NULL,
--     isAvailable TINYINT NOT NULL,
--     isPublished TINYINT NOT NULL,
--     id INT AUTO_INCREMENT NOT NULL,
--     creatorId VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id),
--     FOREIGN KEY(creatorId)
--     REFERENCES profiles(id)
--     ON DELETE CASCADE
-- )
CREATE TABLE lists(
    title VARCHAR(80) NOT NULL,
    isPublished TINYINT NOT NULL,
    id INT AUTO_INCREMENT NOT NULL,
    creatorId VARCHAR(255) NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY(creatorId)
    REFERENCES profiles(id)
    ON DELETE CASCADE
)