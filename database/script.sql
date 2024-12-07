CREATE DATABASE pharmagest
CHARACTER SET utf8mb4
COLLATE utf8mb4_unicode_ci;


CREATE TABLE company ( 
    id INT AUTO_INCREMENT PRIMARY KEY,         -- ID autoincrementale, chiave primaria
    country_code CHAR(2) NOT NULL,             -- Stato membro EU, 2 caratteri
    vat_number VARCHAR(20) NOT NULL,           -- Partita IVA (VAT)
    request_time DATETIME NOT NULL,            -- Orario della ricezione della richiesta
    name VARCHAR(255) NOT NULL,                -- Nome dell'azienda
    address VARCHAR(255) NOT NULL,             -- Indirizzo dell'azienda
    INDEX idx_vat_country (vat_number, country_code)  -- Indice composto
) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;


13157440960

