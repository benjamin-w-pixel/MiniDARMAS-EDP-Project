# Mini-DARMAS: Digital Meeting Recording and Transcript Management System

## Project Overview

Mini-DARMAS is a WinForms-based desktop application designed to manage the complete workflow of meeting documentation, from creation to final approval. The system supports four primary user roles: Admin, Operator, Transcriber, and Editor/Approver.

## Technology Stack

- **.NET 6.0** (Windows Forms)
- **C#**
- **SQL Server Express** (LocalDB)
- **ADO.NET** for database operations

## Project Structure

```
MiniDARMAS/
├── MiniDARMAS/              # Main WinForms application
├── MiniDARMAS.Models/        # Domain models
├── MiniDARMAS.Data/          # Data access layer (ADO.NET)
├── MiniDARMAS.Business/      # Business logic layer
├── Database/                 # SQL schema script
└── README.md
```

## Setup Instructions

### 1. Database Setup

1. Open SQL Server Management Studio (SSMS) or use `sqlcmd`
2. Execute the `Database/Schema.sql` script to create the database and tables
3. The script will create:
   - Database: `MiniDARMAS`
   - Tables: Users, Meetings, Agendas, Recordings, Assignments, Transcriptions
   - Sample data for testing

### 2. Connection String

The default connection string in `DatabaseHelper.cs` is:
```
Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MiniDARMAS;Integrated Security=True
```

If you're using a different SQL Server instance, update the connection string in:
- `MiniDARMAS.Data/DatabaseHelper.cs`

### 3. Build and Run

1. Open the solution file `MiniDARMAS.sln` in Visual Studio 2022 or later
2. Restore NuGet packages
3. Build the solution (Ctrl+Shift+B)
4. Run the application (F5)

## Default Login Credentials

The database script includes sample users:

| Username | Password | Role |
|----------|----------|------|
| admin | admin123 | Admin |
| operator | op123 | Operator |
| transcriber1 | trans123 | Transcriber |
| editor1 | editor123 | Editor |
| approver1 | approve123 | Approver |

## System Features

### Admin Module
- User account management
- Create, edit, delete users
- Activate/deactivate users
- Search and filter users

### Operator Module
- **Meeting Management**: Create, edit, delete meetings
- **Agenda Management**: Add agendas to meetings
- **Recording Management**: Attach audio files to agendas
- **Assignment Management**: Assign recordings to transcribers

### Transcriber Module
- View assigned recordings
- Transcribe audio into text
- Save drafts
- Submit transcriptions to editor

### Editor Module
- Review submitted transcriptions
- Edit transcription text
- Approve or return transcriptions for correction
- Add comments

### Approver Module
- View approved transcriptions for a meeting
- Generate final meeting document
- Export document as .txt or .rtf
- Mark meeting as Final Approved

## Workflow

1. **Operator** creates a meeting
2. **Operator** adds agendas to the meeting
3. **Operator** attaches audio recordings to agendas
4. **Operator** assigns recordings to transcribers
5. **Transcriber** transcribes assigned recordings
6. **Transcriber** submits transcriptions to editor
7. **Editor** reviews and approves/returns transcriptions
8. **Approver** generates final meeting document and marks meeting as approved

## Database Schema

### Tables

1. **Users**: User accounts and roles
2. **Meetings**: Meeting information
3. **Agendas**: Agenda items for meetings
4. **Recordings**: Audio file information
5. **Assignments**: Recording-to-transcriber assignments
6. **Transcriptions**: Transcription text and status

## Status Flow

### Assignment Status
- Assigned
- In Progress
- Completed

### Transcription Status
- Submitted
- Under Review
- Approved
- Returned

## Export Features

The Approver module can export final meeting documents as:
- Text files (.txt)
- Rich Text Format (.rtf)

## Notes

- Audio playback feature is not implemented (bonus feature)
- The system stores file paths for audio files but does not copy files
- Ensure audio files exist at the specified paths when testing
- All dates are stored in the database as DATE/DATETIME types

## Troubleshooting

### Database Connection Issues
- Ensure SQL Server LocalDB is installed
- Check that the database `MiniDARMAS` exists
- Verify the connection string matches your SQL Server instance

### Build Errors
- Ensure .NET 6.0 SDK is installed
- Restore NuGet packages: `dotnet restore`
- Clean and rebuild the solution

## Future Enhancements (Bonus Features)

- Audio playback integration
- Logging system (activity log)
- Multi-language UI (Amharic/English)
- Administrator dashboard with statistics
- Digital signature placeholder
- Export final document as PDF

## License

This is a course capstone project for educational purposes.


