CREATE TABLE Users (
    Id UUID PRIMARY KEY,
    Name VARCHAR(100),
    Email VARCHAR(100) UNIQUE,
    PasswordHash VARCHAR(255),
    CreatedAt TIMESTAMP DEFAULT NOW()
);

CREATE TABLE Accounts (
    Id UUID PRIMARY KEY,
    UserId UUID REFERENCES Users(Id),
    CardNumber VARCHAR(16),
    CardHolder VARCHAR(100),
    ExpirationDate DATE,
    Balance DECIMAL
);

CREATE TABLE Bets (
    Id UUID PRIMARY KEY,
    UserId UUID REFERENCES Users(Id),
    Amount DECIMAL,
    BetDate TIMESTAMP DEFAULT NOW(),
    Event VARCHAR(255),
    Odds DECIMAL,
    Status VARCHAR(20)
);
