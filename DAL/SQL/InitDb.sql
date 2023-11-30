CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY,
	[Email] varchar(255) NOT NULL,
	[Password] varchar(255) NOT NULL,
	[NickName] varchar(255) NOT NULL,
	[FirstName] varchar(255) NOT NULL,
	[LastName] varchar(255) NOT NULL,
	[Age] int NOT NULL,
	[Wallet] Money DEFAULT 0,
	RegisterDate DATETIME NOT NULL,
	[Role] int DEFAULT 0,
	[Status] int DEFAULT 0,
);

CREATE TABLE Friends(
	[Status] int DEFAULT 0,
	UserIdRequester int FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	UserIdRequest int FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	CONSTRAINT PK_Friends PRIMARY KEY(UserIdRequester, UserIdRequest)
);

CREATE TABLE Game(
	Id INT PRIMARY KEY IDENTITY,
	[Name] varchar(255) NOT NULL,
	[Version] varchar(255) NOT NULL,
	[CreationDate] DATETIME NOT NULL,
	UserIdDev INT FOREIGN KEY REFERENCES Users(id) NOT NULL,
	[Status] int DEFAULT 0,
);

CREATE TABLE Prices(
	Id INT PRIMARY KEY IDENTITY,
	GameId int FOREIGN KEY REFERENCES Game(id) NOT NULL,
	[PriceDate] DATETIME NOT NULL,
	Price int NOT NULL,
);

CREATE TABLE GameList(
	Id int PRIMARY KEY IDENTITY,
	UserId int FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	GameId int FOREIGN KEY REFERENCES Game(Id) NOT NULL,
	PurchaseDate DATETIME NOT NULL,
	PlayTime int DEFAULT 0,
	[Status] int DEFAULT 0,
	GiftUserId int FOREIGN KEY REFERENCES Users(Id),
);
