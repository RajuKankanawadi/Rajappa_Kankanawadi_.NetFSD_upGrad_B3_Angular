CREATE DATABASE EventDB;
USE EventDB;

--- 1 Query---

CREATE Table UserInfo(
EmailId VARCHAR(100) PRIMARY KEY,
UserName VARCHAR(50) NOT NULL,
Role VARCHAR(20) NOT NULL,
Password VARCHAR(20) NOT NULL,
CONSTRAINT CHK_UserName_Length CHECK (LEN(UserName) BETWEEN 1 AND 50),
CONSTRAINT CHK_User_Role CHECK (Role IN ('Admin', 'Participant')),
CONSTRAINT CHK_Password_Length CHECK (LEN(Password) BETWEEN 6 AND 20)
);

INSERT INTO UserInfo (EmailId, UserName, Role, Password)
VALUES ('rajappa@gmail.com', 'Rajappa', 'Admin', 'Rajappa123');

SELECT * FROM UserInfo;

use EventDB;

--- 2 Query---

CREATE TABLE EventDetails
(
EventId INT PRIMARY KEY,
EventName VARCHAR(50) NOT NULL,
EventCategory VARCHAR(50) NOT NULL,
EventDate DATETIME NOT NULL,
Description VARCHAR(255),
Status VARCHAR(20) NOT NULL,
CONSTRAINT CHK_EventName_Length CHECK (LEN(EventName) BETWEEN 1 AND 50),
CONSTRAINT CHK_EventCategory_Length CHECK (LEN(EventCategory) BETWEEN 1 AND 50),
CONSTRAINT CHK_Event_Status CHECK (Status IN ('Active','In-Active'))
);

use EventDB;

--- 3 Query---

CREATE TABLE SpeakersDetails
(
SpeakerId INT PRIMARY KEY,
SpeakerName VARCHAR(50) NOT NULL,
CONSTRAINT CHK_SpeakerName_Length CHECK (LEN(SpeakerName) BETWEEN 1 AND 50)
);

----4 Query----

CREATE TABLE SessionInfo
(
SessionId INT PRIMARY KEY,
EventId INT NOT NULL,
SessionTitle VARCHAR(50) NOT NULL,
SpeakerId INT NOT NULL,
Description VARCHAR(255),
SessionStart DATETIME NOT NULL,
SessionEnd DATETIME NOT NULL,
SessionUrl VARCHAR(255),
CONSTRAINT CHK_SessionTitle_Length CHECK (LEN(SessionTitle) BETWEEN 1 AND 50),
CONSTRAINT FK_Session_Event FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
CONSTRAINT FK_Session_Speaker FOREIGN KEY (SpeakerId) REFERENCES SpeakersDetails(SpeakerId)
);

select * from UserInfo;

select * from SpeakersDetails;

INSERT INTO EventDetails (EventId, EventName, EventCategory, EventDate, Description, Status)
VALUES
(1, 'tech event', 'Technology', '2026-05-10', 'tech category', 'Active'),

(2, 'business event ', 'Business', '2026-06-15', 'business category', 'In-Active');

select * from EventDetails;

INSERT INTO SpeakersDetails (SpeakerId, SpeakerName)
VALUES
(1, 'Shiva'), (2, 'Anita');

---- 5 Query ----

CREATE TABLE ParticipantEventDetails
(
Id INT PRIMARY KEY,
ParticipantEmailId VARCHAR(100) NOT NULL,
EventId INT NOT NULL,
SessionId INT NOT NULL,
IsAttended BIT NOT NULL,
CONSTRAINT CHK_IsAttended CHECK (IsAttended IN (0,1)),
CONSTRAINT FK_Participant_User FOREIGN KEY (ParticipantEmailId) REFERENCES UserInfo(EmailId),
CONSTRAINT FK_Participant_Event FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
CONSTRAINT FK_Participant_Session FOREIGN KEY (SessionId) REFERENCES SessionInfo(SessionId)
);


