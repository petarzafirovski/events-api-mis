CREATE DATABASE IF NOT EXISTS eventsdb;
USE eventsdb;

CREATE TABLE IF NOT EXISTS Event (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Type VARCHAR(255),
    Name VARCHAR(255),
    EventEndDate DATETIME,
    Poster VARCHAR(255),
    EventCenter VARCHAR(255),
    EventCenterLocation VARCHAR(255),
    BriefDescription TEXT,
    TicketSalesLink VARCHAR(255),
    IsFree BOOLEAN,
    Picture VARCHAR(255),
    EventUrl VARCHAR(255),
    EventStartDate DATETIME,
    Artist VARCHAR(255),
	CreatedById VARCHAR(255)
    );
	
CREATE TABLE IF NOT EXISTS JoinedEvents(
	UserId VARCHAR(255) NOT NULL,
	EventId INT NOT NULL,
	FOREIGN KEY(EventId)
		REFERENCES Event(Id)
		ON DELETE CASCADE
	);