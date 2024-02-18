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
    Artist VARCHAR(255)
    );

INSERT INTO Event (Type, Name, EventEndDate, Poster, EventCenter, EventCenterLocation, BriefDescription, TicketSalesLink, IsFree, Picture, EventUrl, EventStartDate, Artist) VALUES
('Type1', 'Event1', '2024-01-01 00:00:00', 'Poster1', 'Center1', 'Location1', 'Description1', 'Link1', true, 'Picture1', 'Url1', '2023-12-01 00:00:00', 'Artist1', 'peceid123'),
('Type2', 'Event2', '2024-02-01 00:00:00', 'Poster2', 'Center2', 'Location2', 'Description2', 'Link2', false, 'Picture2', 'Url2', '2023-12-02 00:00:00', 'Artist2' 'peceid123'),
('Type3', 'Event3', '2024-03-01 00:00:00', 'Poster3', 'Center3', 'Location3', 'Description3', 'Link3', true, 'Picture3', 'Url3', '2023-12-03 00:00:00', 'Artist3' 'staskaid123'),
('Type4', 'Event4', '2024-04-01 00:00:00', 'Poster4', 'Center4', 'Location4', 'Description4', 'Link4', false, 'Picture4', 'Url4', '2023-12-04 00:00:00', 'Artist4', 'staskaid123'),
('Type5', 'Event5', '2024-05-01 00:00:00', 'Poster5', 'Center5', 'Location5', 'Description5', 'Link5', true, 'Picture5', 'Url5', '2023-12-05 00:00:00', 'Artist5', 'staskaid123');