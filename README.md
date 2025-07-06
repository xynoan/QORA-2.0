# Qora - Student Information Management System

## Overview

Qora is a comprehensive web-based student information management system designed for QCians (Quezon City students). The application facilitates student registration, enrollment management, academic records, and administrative operations through a modern ASP.NET Core MVC architecture.

## Features

### 🎓 Student Management
- **Student Registration**: Complete student onboarding with personal, family, and educational information
- **Profile Management**: Comprehensive student profiles with personal and academic details
- **Enrollment Processing**: Streamlined enrollment workflows and status tracking
- **Academic Records**: Grade management and academic history tracking

### 👥 User Roles & Authentication
- **Student Portal**: Self-service registration and profile management
- **Registrar Dashboard**: Administrative tools for student management
- **Multi-role Support**: Different access levels for students, registrars, and administrators

### 📧 Communication
- **Email Integration**: Automated email notifications using MailKit
- **Account Verification**: Email-based account verification system
- **Status Notifications**: Real-time updates on enrollment and academic status

### 📊 Data Management
- **Comprehensive Database**: Full student lifecycle data management
- **File Upload Support**: Large file handling (up to 100GB)
- **Session Management**: Secure user session handling with 30-minute timeout

## Technology Stack

### Backend
- **Framework**: ASP.NET Core 8.0 MVC
- **Database**: Microsoft SQL Server with Entity Framework Core 8.0.10
- **Authentication**: Custom session-based authentication
- **Email**: MailKit 4.8.0 and MimeKit 4.8.0

### Frontend
- **Views**: Razor Views with MVC pattern
- **Static Files**: Managed through wwwroot directory
- **UI Framework**: (Based on project structure, likely Bootstrap/custom CSS)

### Development Tools
- **IDE**: Visual Studio / Visual Studio Code
- **Package Manager**: NuGet
- **Database Tools**: Entity Framework Core Tools for migrations

## Project Structure

```
prototype/
├── Controllers/           # MVC Controllers
│   ├── HomeController.cs
│   ├── LoginController.cs
│   ├── RegisterController.cs
│   ├── StudentController.cs
│   ├── RegistrarController.cs
│   ├── BeAQcianController.cs
│   └── AccountController.cs
├── Models/               # Data Models
│   ├── User.cs
│   ├── AccountCreationModel.cs
│   ├── Register/         # Registration-related models
│   │   ├── BasicInformation.cs
│   │   ├── PersonalInformation.cs
│   │   ├── Educations.cs
│   │   ├── Family.cs
│   │   └── EmergencyContact.cs
│   └── Student/          # Student-related models
│       ├── StudentEnlistment.cs
│       ├── StudentGrading.cs
│       ├── StudentReference.cs
│       └── StudentYrScreening.cs
├── Views/                # Razor Views
├── Data/                 # Database Context
│   └── ApplicationDbContext.cs
├── Services/             # Business Logic
│   └── EmailService.cs
├── wwwroot/              # Static Files
├── Migrations/           # Database Migrations
└── Properties/           # Application Properties
```

## Database Schema

### Core Tables

#### Users Table
- **USERID** (Primary Key): Unique user identifier
- **ACC_STUDENT_ID**: Student account ID
- **EMAIL**: User email address
- **PASSWORD**: Encrypted password
- **ENROLLMENT_STATUS**: Current enrollment status
- **STATUS**: Account status
- **USER_TYPE**: Role-based user type
- **VERIFICATION**: Email verification status

#### Student Information Tables
- **BASIC_INFORMATION**: Application details, LRN, preferred courses/campuses
- **PERSONAL_INFORMATION**: Personal details and demographics
- **EDUCATION**: Educational background and history
- **FAMILY**: Family information and contacts
- **PERSON_INCASEOF_EMERGENCY**: Emergency contact details

#### Academic Management Tables
- **STUDENT_ENLISTMENT**: Course enrollment records
- **STUDENT_GRADING**: Academic grades and assessments
- **STUDENT_REFERENCE**: Student references and recommendations
- **StudentYrScreenings**: Year-level screening information

## Setup and Installation

### Prerequisites
- .NET 8.0 SDK
- SQL Server (LocalDB or full installation)
- Visual Studio 2022 or Visual Studio Code

### Installation Steps

1. **Clone the Repository**
   ```bash
   git clone <repository-url>
   cd prototype
   ```

2. **Restore Dependencies**
   ```bash
   dotnet restore
   ```

3. **Database Setup**
   ```bash
   # Update connection string in appsettings.json if needed
   dotnet ef database update
   ```

4. **Run the Application**
   ```bash
   dotnet run
   ```

5. **Access the Application**
   - Navigate to `https://localhost:5001` or `http://localhost:5000`

### Configuration

#### Database Connection
Update the connection string in `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=Qora;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

#### Email Configuration
Configure email settings in `EmailService.cs` for SMTP functionality.

## API Endpoints

### Authentication Routes
- `GET /Login` - Login page
- `POST /Login` - Process login
- `GET /Register` - Registration page
- `POST /Register` - Process registration

### Student Management
- `GET /Student` - Student dashboard
- `POST /Student/UpdateProfile` - Update student information
- `GET /Student/Grades` - View academic records

### Administrative Routes
- `GET /Registrar` - Registrar dashboard
- `POST /Registrar/ProcessEnrollment` - Process student enrollment
- `GET /Registrar/Reports` - Generate reports

### BeAQcian Portal
- `GET /BeAQcian` - BeAQcian portal access
- `POST /BeAQcian/Apply` - Submit application

## Development Guidelines

### Code Standards
- Follow C# naming conventions
- Use async/await for database operations
- Implement proper error handling and logging
- Maintain separation of concerns (MVC pattern)

### Database Migrations
```bash
# Create new migration
dotnet ef migrations add MigrationName

# Update database
dotnet ef database update

# Remove last migration
dotnet ef migrations remove
```

### Testing
- Unit tests for business logic
- Integration tests for API endpoints
- Database testing with in-memory provider

## Security Features

- **Session Management**: 30-minute timeout with secure cookies
- **HTTPS Redirection**: Enforced HTTPS in production
- **Input Validation**: Data annotation validation on models
- **SQL Injection Protection**: Entity Framework parameterized queries
- **HSTS**: HTTP Strict Transport Security enabled

## Performance Considerations

- **Large File Uploads**: Configured for up to 100GB file uploads
- **Database Optimization**: Indexed primary keys and foreign keys
- **Session Efficiency**: HttpOnly and essential cookie settings
- **Static File Caching**: Optimized static file serving

## Troubleshooting

### Common Issues

1. **Database Connection Issues**
   - Verify SQL Server is running
   - Check connection string format
   - Ensure database exists

2. **Migration Errors**
   - Check model configurations
   - Verify DbContext registration
   - Review migration files

3. **Email Service Issues**
   - Verify SMTP configuration
   - Check firewall settings
   - Validate email credentials

## Contributing

1. Fork the repository
2. Create a feature branch
3. Implement changes with proper testing
4. Submit a pull request with detailed description

## License

[Specify your license here]

## Support

For support and questions, please contact [your contact information].

---

*This documentation covers the core functionality of the Qora Student Information Management System. For specific implementation details, refer to the source code and inline comments.*