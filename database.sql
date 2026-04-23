CREATE TABLE Donors (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(100),
    Email VARCHAR(100),
    Phone VARCHAR(20),
    CreatedAt TIMESTAMP,
    UpdatedAt TIMESTAMP,
    DeletedAt TIMESTAMP
);

CREATE TABLE DisabledPersons (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(100),
    DisabilityType VARCHAR(100),
    Address TEXT,
    CreatedAt TIMESTAMP,
    UpdatedAt TIMESTAMP,
    DeletedAt TIMESTAMP
);

CREATE TABLE Needs (
    Id SERIAL PRIMARY KEY,
    DisabledPersonId INT,
    ItemName VARCHAR(100),
    Description TEXT,
    TargetAmount DECIMAL(12,2),
    CreatedAt TIMESTAMP,
    UpdatedAt TIMESTAMP,
    DeletedAt TIMESTAMP,
    CONSTRAINT fk_need_person
        FOREIGN KEY (DisabledPersonId)
        REFERENCES DisabledPersons(Id)
);

CREATE TABLE Donations (
    Id SERIAL PRIMARY KEY,
    DonorId INT,
    NeedId INT,
    Amount DECIMAL(12,2),
    DonationDate TIMESTAMP,
    CreatedAt TIMESTAMP,
    UpdatedAt TIMESTAMP,
    DeletedAt TIMESTAMP,
    CONSTRAINT fk_donation_donor
        FOREIGN KEY (DonorId)
        REFERENCES Donors(Id),
    CONSTRAINT fk_donation_need
        FOREIGN KEY (NeedId)
        REFERENCES Needs(Id)
);

INSERT INTO Donors (Name, Email, Phone, CreatedAt) VALUES
('Andi Pratama','andi@email.com','08123456701',NOW()),
('Budi Santoso','budi@email.com','08123456702',NOW()),
('Citra Lestari','citra@email.com','08123456703',NOW()),
('Dewi Anggraini','dewi@email.com','08123456704',NOW()),
('Eko Nugroho','eko@email.com','08123456705',NOW());

INSERT INTO DisabledPersons (Name, DisabilityType, Address, CreatedAt) VALUES
('Siti Aminah','Tunanetra','Jakarta',NOW()),
('Rahmat Hidayat','Tunarungu','Bandung',NOW()),
('Ahmad Fauzi','Tunadaksa','Surabaya',NOW()),
('Lina Marlina','Tunawicara','Yogyakarta',NOW()),
('Rudi Hartono','Tunanetra','Semarang',NOW());

INSERT INTO Needs (DisabledPersonId, ItemName, Description, TargetAmount, CreatedAt) VALUES
(1,'Tongkat Tunanetra','Tongkat bantu berjalan',500000,NOW()),
(2,'Alat Bantu Dengar','Hearing aid untuk tunarungu',2000000,NOW()),
(3,'Kursi Roda','Kursi roda manual',3500000,NOW()),
(4,'Alat Terapi Bicara','Alat latihan bicara',1500000,NOW()),
(5,'Laptop Aksesibel','Laptop dengan screen reader',7000000,NOW());

INSERT INTO Donations (DonorId, NeedId, Amount, DonationDate, CreatedAt) VALUES
(1,1,200000,NOW(),NOW()),
(2,2,500000,NOW(),NOW()),
(3,3,750000,NOW(),NOW()),
(4,4,300000,NOW(),NOW()),
(5,5,1000000,NOW(),NOW());