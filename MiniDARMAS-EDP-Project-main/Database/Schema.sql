-- Create Database
-- CREATE DATABASE MiniDARMAS;
GO
USE MiniDARMAS;
GO

-- Users Table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
BEGIN
    CREATE TABLE Users (
        UserId INT PRIMARY KEY IDENTITY(1,1),
        Username NVARCHAR(50) NOT NULL UNIQUE,
        Password NVARCHAR(255) NOT NULL,
        FullName NVARCHAR(100) NOT NULL,
        Role NVARCHAR(20) NOT NULL, -- Admin, Operator, Transcriber, Editor, Approver
        IsActive BIT DEFAULT 1,
        CreatedAt DATETIME DEFAULT GETDATE()
    );
END

-- Meetings Table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Meetings')
BEGIN
    CREATE TABLE Meetings (
        MeetingId INT PRIMARY KEY IDENTITY(1,1),
        MeetingNo NVARCHAR(50) NOT NULL UNIQUE,
        Title NVARCHAR(200) NOT NULL,
        Description NVARCHAR(MAX),
        MeetingDate DATETIME NOT NULL,
        Status NVARCHAR(20) DEFAULT 'Scheduled', -- Scheduled, Ongoing, Completed, Closed
        CreatedAt DATETIME DEFAULT GETDATE()
    );
END

-- Agendas Table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Agendas')
BEGIN
    CREATE TABLE Agendas (
        AgendaId INT PRIMARY KEY IDENTITY(1,1),
        MeetingId INT FOREIGN KEY REFERENCES Meetings(MeetingId),
        Title NVARCHAR(200) NOT NULL,
        Description NVARCHAR(MAX),
        Status NVARCHAR(20) DEFAULT 'Pending'
    );
END

-- Recordings Table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Recordings')
BEGIN
    CREATE TABLE Recordings (
        RecordingId INT PRIMARY KEY IDENTITY(1,1),
        MeetingId INT FOREIGN KEY REFERENCES Meetings(MeetingId),
        AgendaId INT FOREIGN KEY REFERENCES Agendas(AgendaId),
        FilePath NVARCHAR(MAX) NOT NULL,
        Duration INT, -- in seconds
        CreatedAt DATETIME DEFAULT GETDATE()
    );
END

-- Assignments Table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Assignments')
BEGIN
    CREATE TABLE Assignments (
        AssignmentId INT PRIMARY KEY IDENTITY(1,1),
        RecordingId INT FOREIGN KEY REFERENCES Recordings(RecordingId),
        TranscriberId INT FOREIGN KEY REFERENCES Users(UserId),
        TranscriptionText NVARCHAR(MAX),
        Status NVARCHAR(20) DEFAULT 'Assigned', -- Assigned, InProgress, Completed, Submitted, Approved, Returned
        AssignedDate DATETIME DEFAULT GETDATE(),
        CompletedDate DATETIME
    );
END

-- Activity Logs Table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ActivityLogs')
BEGIN
    CREATE TABLE ActivityLogs (
        LogId INT PRIMARY KEY IDENTITY(1,1),
        UserId INT FOREIGN KEY REFERENCES Users(UserId),
        ActivityType NVARCHAR(50),
        Description NVARCHAR(MAX),
        LogDate DATETIME DEFAULT GETDATE()
    );
END

-- Seed Data (Only if empty)
IF NOT EXISTS (SELECT 1 FROM Users WHERE Username = 'admin')
BEGIN
    INSERT INTO Users (Username, Password, FullName, Role) VALUES 
    ('admin', 'admin123', 'Administrator', 'Admin'),
    ('operator', 'op123', 'Project Operator', 'Operator'),
    ('trans', 'trans123', 'Audio Transcriber', 'Transcriber'),
    ('editor', 'ed123', 'Content Editor', 'Editor'),
    ('approver', 'app123', 'Final Approver', 'Approver');
END
GO