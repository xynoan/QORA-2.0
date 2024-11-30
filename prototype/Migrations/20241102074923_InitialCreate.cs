using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prototype.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasicInformations",
                columns: table => new
                {
                    BASIC_INFO_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ACCREDITATION_OF_SUBJECTS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    APPLICATION_DATE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    APPLYING_AS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BI_STUDENT_ACC_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LRN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STRAND = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TRACK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PREFERRED_CAMPUS1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PREFERRED_CAMPUS2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PREFERRED_CAMPUS3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PREFERRED_COURSE1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PREFERRED_COURSE2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PREFERRED_COURSE3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicInformations", x => x.BASIC_INFO_ID);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    COLLEGE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COLLEGE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_COURSE_YR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_DATE_GRADUATED = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_HONORS_RECEIVED = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_LOCATION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_SCHOOL_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_STUDENT_ACC_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TV_ID = table.Column<int>(type: "int", nullable: false),
                    TECH_VOC_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TV_ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TV_COURSE_YR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TV_DATE_GRADUATED = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TV_HONORS_RECEIVED = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TV_LOCATION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TV_STUDENT_ACC_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HS_ID = table.Column<int>(type: "int", nullable: false),
                    HIGH_SCHOOL_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HS_ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HS_COURSE_YR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HS_DATE_GRADUATE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HS_HONORS_RECEIVED = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HS_LOCATION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HS_STUDENT_ACC_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PERSONAL_INFO_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.COLLEGE_ID);
                });

            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    FAMILY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FATHER_FIRST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_MIDDLE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_LAST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_SUFFIX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_OCCUPATION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_EDUCATIONAL_ATTAINMENT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_CONTACT_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_BARANGAY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_DISTRICT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_MUNICIPALITY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_STREET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_ZIPCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_FIRST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_MIDDLE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_LAST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_CONTACT_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_EDUCATIONAL_ATTAINMENT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_OCCUPATION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_BARANGAY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_DISTRICT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_MUNICIPALITY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_STREET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_ZIPCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_FIRST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_MIDDLE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_LAST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_SUFFIX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_CONTACT_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_RELATIONSHIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_BARANGAY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_DISTRICT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_MUNICIPALITY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_STREET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_ZIPCODE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.FAMILY_ID);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInformations",
                columns: table => new
                {
                    PERSONAL_INFO_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MIDDLE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LAST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUFFIX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATE_OF_BIRTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BIRTH_PLACE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GENDER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RELIGION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CITIZENSHIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIVIL_STATUS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P_STUDENT_ACC_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HOUSE_STREET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BARANGAY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MUNICIPALITY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DISTRICT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZIPCODE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInformations", x => x.PERSONAL_INFO_ID);
                });

            migrationBuilder.CreateTable(
                name: "PersonInCaseOfEmergency",
                columns: table => new
                {
                    PICOE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PICOE_FIRSTNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_MIDDLENAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_LASTNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_SUFFIX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_CONTACTNUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_HOUSESTREET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_BRGY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_DISTRICT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_MUNICIPALITY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_ZIPCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_RELATIONSHIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_STUDENT_ACC_ID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInCaseOfEmergency", x => x.PICOE_ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ACC_STUDENT_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ENROLLMENT_STATUS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCE_STATUS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STATUS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USER_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VERIFICATION = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    USERID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ACC_STUDENT_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ENROLLMENT_STATUS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCE_STATUS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STATUS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USER_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VERIFICATION = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.USERID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasicInformations");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Families");

            migrationBuilder.DropTable(
                name: "PersonalInformations");

            migrationBuilder.DropTable(
                name: "PersonInCaseOfEmergency");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
