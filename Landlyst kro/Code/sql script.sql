USE master
GO

DROP DATABASE LandLyst_Kro
GO

CREATE DATABASE LandLyst_Kro
GO

USE LandLyst_Kro
GO


CREATE TABLE Customers (
    FirstName varchar(250),
	MiddleName varchar(250),
    LastName varchar(250),
	PhoneNumber varchar(250) NOT NULL,
    Email varchar(250)
);
GO

CREATE TABLE Requests (
	RequestID integer IDENTITY NOT NULL,
	Contact varchar(250)NOT NULL,
	RequestedAttributes varchar(5),
	RequestDate datetime,
	CheckInDate datetime,
	CheckOutDate datetime,
	RequestInformation varchar(500)
);
GO

CREATE TABLE RoomRequests (
	RoomNumber INTEGER NOT NULL,
	RequestID INTEGER NOT NULL
);


CREATE TABLE Rooms (
	RoomNumber INTEGER NOT NULL,
	Price INTEGER,
	Occupied BIT,
	Cleaned BIT
);
GO

CREATE TABLE Attributes (
	RoomNumber INTEGER NOT NULL,
	Attribute varchar(250) NOT NULL
);
Go

ALTER TABLE Customers
ADD 
CONSTRAINT Email_Constraint  CHECK(Email LIKE '%___@___%'),
PRIMARY KEY (PhoneNumber);
Go

ALTER TABLE Requests
ADD 
PRIMARY KEY (RequestID),
FOREIGN KEY (Contact) REFERENCES Customers(PhoneNumber);
Go

ALTER TABLE Rooms
ADD
PRIMARY KEY (RoomNumber)
Go


ALTER TABLE Attributes
ADD
PRIMARY KEY (RoomNumber, Attribute),
FOREIGN KEY (RoomNumber) REFERENCES Rooms(RoomNumber)
Go

ALTER TABLE RoomRequests
ADD 
FOREIGN KEY (RequestID) REFERENCES Requests(RequestID),
FOREIGN KEY (RoomNumber) REFERENCES Rooms(RoomNumber),
PRIMARY KEY (RoomNumber);
Go


INSERT INTO Rooms(RoomNumber, Price, Occupied, Cleaned)
VALUES 
(100, 945, 0 , 1),
(101, 895, 0 , 1),
(102, 945, 0 , 1),
(103, 945, 0 , 1),
(104, 945, 0 , 1),
(105, 945, 0 , 1),
(106, 945, 0 , 1),
(107, 945, 0 , 1),
(108, 945, 0 , 1),
(109, 895, 0 , 1),
(110, 945, 0 , 1),

(200, 1220, 0 , 1),
(201, 945, 0 , 1),
(202, 945, 0 , 1),
(203, 945, 0 , 1),
(204, 945, 0 , 1),
(205, 1570, 0 , 1),
(206, 945, 0 , 1),
(207, 945, 0 , 1),
(208, 945, 0 , 1),
(209, 1120, 0 , 1),

(300, 1220, 0 , 1),
(301, 945, 0 , 1),
(302, 945, 0 , 1),
(303, 945, 0 , 1),
(304, 945, 0 , 1),
(305, 1420, 0 , 1),
(306, 945, 0 , 1),
(307, 945, 0 , 1),
(308, 945, 0 , 1),
(309, 1120, 0 , 1),

(400, 1220, 0 , 1),
(401, 895, 0 , 1),
(402, 945, 0 , 1),
(403, 945, 0 , 1),
(404, 745, 0 , 1),
(405, 1570, 0 , 1),
(406, 845, 0 , 1),
(407, 845, 0 , 1),
(408, 695, 0 , 1),
(409, 1120, 0 , 1),

(500, 1220, 0 , 1),
(501, 945, 0 , 1),
(502, 945, 0 , 1),
(503, 945, 0 , 1),
(504, 745, 0 , 1),
(506, 1045, 0 , 1),
(507, 945, 0 , 1),
(508, 945, 0 , 1),
(509, 945, 0 , 1),
(510, 945, 0 , 1);



INSERT INTO Attributes(RoomNumber, Attribute)
VALUES 
(100, 'DoubleBed'),
(100, 'Bathtub'),
(101, 'DoubleBed'),
(102, 'DoubleBed'),
(102, 'Bathtub'),
(103, 'DoubleBed'),
(103, 'Bathtub'),
(104, 'DoubleBed'),
(104, 'Bathtub'),
(105, 'DoubleBed'),
(105, 'Bathtub'),
(106, 'DoubleBed'),
(106, 'Bathtub'),
(107, 'DoubleBed'),
(107, 'Bathtub'),
(108, 'DoubleBed'),
(108, 'Bathtub'),
(109, 'DoubleBed'),
(110, 'DoubleBed'),
(110, 'Bathtub'),

(200, 'DoubleBed'),
(200, 'Jacuzzi'),
(200, 'Balcony'),
(201, 'DoubleBed'),
(201, 'Bathtub'),
(202, 'DoubleBed'),
(202, 'Bathtub'),
(203, 'DoubleBed'),
(203, 'Bathtub'),
(204, 'DoubleBed'),
(204, 'Bathtub'),
(205, 'DoubleBed'),
(205, 'Balcony'),
(205, 'Jacuzzi'),
(205, 'Kitchen'),
(206, 'DoubleBed'),
(206, 'Bathtub'),
(207, 'DoubleBed'),
(207, 'Bathtub'),
(208, 'DoubleBed'),
(208, 'Bathtub'),
(209, 'DoubleBed'),
(209, 'Bathtub'),
(209, 'Jacuzzi'),

(300, 'DoubleBed'),
(300, 'Jacuzzi'),
(300, 'Balcony'),
(301, 'DoubleBed'),
(301, 'Bathtub'),
(302, 'DoubleBed'),
(302, 'Bathtub'),
(303, 'DoubleBed'),
(303, 'Bathtub'),
(304, 'DoubleBed'),
(304, 'Bathtub'),
(305, 'DoubleBed'),
(305, 'Jacuzzi'),
(305, 'Balcony'),
(305, 'Kitchen'),
(306, 'DoubleBed'),
(306, 'Bathtub'),
(307, 'DoubleBed'),
(307, 'Bathtub'),
(308, 'DoubleBed'),
(308, 'Bathtub'),
(309, 'DoubleBed'),
(309, 'Bathtub'),
(309, 'Jacuzzi'),


(400, 'Jacuzzi'),
(400, 'DoubleBed'),
(400, 'Balcony'),
(401, 'Balcony'),
(401, 'Bathtub'),
(402, 'DoubleBed'),
(402, 'Bathtub'),
(403, 'DoubleBed'),
(403, 'Bathtub'),
(404, 'Bathtub'),
(405, 'DoubleBed'),
(405, 'Jacuzzi'),
(405, 'Balcony'),
(405, 'Kitchen'),
(406, 'Balcony'),
(407, 'Balcony'),
(409, 'DoubleBed'),
(409, 'Bathtub'),
(409, 'Jacuzzi'),

(500, 'DoubleBed'),
(500, 'Jacuzzi'),
(500, 'Balcony'),
(501, 'DoubleBed'),
(501, 'Bathtub'),
(502, 'DoubleBed'),
(502, 'Bathtub'),
(503, 'DoubleBed'),
(503, 'Bathtub'),
(504, 'Bathtub'),
(506, 'DoubleBed'),
(506, 'Balcony'),
(507, 'DoubleBed'),
(507, 'Bathtub'),
(508, 'DoubleBed'),
(508, 'Bathtub'),
(509, 'DoubleBed'),
(509, 'Bathtub'),
(510, 'DoubleBed'),
(510, 'Bathtub');

INSERT INTO Customers
Values
('Mads', 'Emil' ,'Stasel', '60141070', 'Mads464@yahoo.com'),
('Jens', NULL ,'Hansen', '12345678', 'Jens@Gmail.Com'),
('Jo', 'Ar' ,'Erikson', '87654321', 'JA.Erik@outlook.swe')


INSERT INTO Requests
Values
('60141070','10101', '2020-12-11 09:57:24.780', '2020-12-24 00:00:00.000', '2021-01-10 00:00:00.000', 'Good internet'),
('12345678','00001', '2020-12-11 09:57:24.780', '2020-12-24 00:00:00.000', '2021-01-10 00:00:00.000', 'Good view'),
('87654321','11111', '2020-12-11 09:57:24.780', '2020-12-24 00:00:00.000', '2021-01-10 00:00:00.000', 'Ive no request')


USE LandLyst_Kro
Go

CREATE PROC RequestUpdateOrDelete AS 
Go
CREATE PROC DeleteByRequestID AS 
Go
CREATE PROC ViewAll AS
Go
CREATE PROC ViewByRequestID AS
Go
CREATE PROC BookRoom AS
Go
CREATE PROC SubmitRequest AS
Go

ALTER PROC RequestUpdateOrDelete
@FirstName varchar(250),
@MiddleName varchar(250),
@LastName varchar(250),
@PhoneNumber varchar(250),
@Email varchar(250),
@RequestedAttributes varchar(5),
@OrderDate datetime,
@CheckInDate datetime,
@CheckOutDate datetime,
@OrderDetails varchar(250)
AS
BEGIN
	
	Update Requests
	SET
		RequestedAttributes = @RequestedAttributes,
		RequestDate = @OrderDate,
		CheckInDate = @CheckInDate,
		CheckOutDate = @CheckOutDate,
		RequestInformation = @OrderDetails
	    WHERE Requests.Contact = @PhoneNumber

		Update Customers
	SET
		FirstName = @FirstName,
		MiddleName = @MiddleName,
		LastName = @LastName,
		Email = @Email
	    WHERE Customers.PhoneNumber = @PhoneNumber

END
GO


ALTER PROC ViewAll
AS
	BEGIN
	SELECT Customers.FirstName, Customers.MiddleName, Customers.LastName, Customers.PhoneNumber, Customers.Email, 
	Requests.RequestID, Requests.RequestDate, Requests.CheckInDate, Requests.CheckOutDate, Requests.RequestedAttributes, Requests.RequestInformation
	FROM Customers
	INNER JOIN Requests ON Requests.Contact = PhoneNumber
END
GO

ALTER PROC ViewByRequestID
@RequestID INTEGER
AS
	BEGIN
	SELECT Customers.FirstName, Customers.MiddleName, Customers.LastName, Customers.PhoneNumber, Customers.Email, 
	Requests.RequestDate, Requests.CheckInDate, Requests.CheckOutDate, Requests.RequestedAttributes, Requests.RequestInformation
	FROM Requests
	INNER JOIN Customers ON Customers.PhoneNumber = Contact
	Where Requests.RequestID = @RequestID
END
GO

ALTER PROC DeleteByRequestID
@RequestID INTEGER,
@Contact varchar(250)
AS
BEGIN
BEGIN
	DELETE FROM RoomRequests
    WHERE RoomRequests.RequestID = @RequestID
	END

	BEGIN
	DELETE FROM Requests 
	WHERE Requests.RequestID = @RequestID 
	END

	BEGIN
	DELETE FROM Customers
    WHERE Customers.PhoneNumber = @Contact
	END

END
GO

ALTER PROC BookRoom
@RoomNumber INTEGER,
@RequestID INTEGER
AS
BEGIN
	Insert into RoomRequests(RoomNumber, RequestID)
	Values (@RoomNumber, @RequestID)
END
GO

ALTER PROC SubmitRequest
@FirstName varchar(250),
@MiddleName varchar(250),
@LastName varchar(250),
@PhoneNumber varchar(250),
@Email varchar(250),
@RequestedAttributes varchar(5),
@OrderDate datetime,
@CheckInDate datetime,
@CheckOutDate datetime,
@OrderDetails varchar(250)
AS
BEGIN
	Insert into Customers(FirstName, MiddleName, LastName, PhoneNumber, Email)
	Values (@FirstName, @MiddleName, @LastName, @PhoneNumber, @Email)

	Insert into Requests(RequestedAttributes, Contact, RequestDate, CheckInDate, CheckOutDate, RequestInformation)
	Values (@RequestedAttributes, @PhoneNumber, @OrderDate, @CheckInDate, @CheckOutDate, @OrderDetails)
END
GO

USE master
GO

DROP DATABASE Users
GO

CREATE DATABASE Users
GO

USE Users
GO

CREATE TABLE Users(
	Username varchar(50) NOT NULL, 
	Salt varchar(20), 
	HashedPassword varbinary(max)
	);

ALTER TABLE Users
ADD 
PRIMARY KEY (Username);
Go


INSERT INTO Users
VALUES 
('admin', '#OuaJmSfVcUEyI#jvkH+', 0x52C1358FB829E1F5539237A2DD7B2614EC564BD234502842AD89EA9EE6415EAF)









