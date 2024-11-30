namespace prototype.Models.Registrar
{
    public class StudentDetailsViewModel
    {
          //PersonalInformation///
             public string? FirstName { get; set; }
            public string? MiddleName { get; set; }
            public string? LastName { get; set; }
            public string? Suffix { get; set; }
            public string? BirthDate { get; set; }
            public string? BirthPlace { get; set; }
            public string? Citizenship { get; set; }
            public string? Gender { get; set; }
            public string? Religion { get; set; }
            public string? CivilStatus { get; set; }
            public string? Barangay { get; set; }
            public string? District { get; set; }
            public string? Municipality { get; set; }
            public string? Street { get; set; }
        public string? ZipCode { get; set; }

        //Education - College///
        public string? CollegeName { get; set; }
        public string? CollegeAddress { get; set; }
        public string? CollegeCourseYr { get; set; }
        public string? CollegeDateGraduated { get; set; }
        public string? CollegeHonorsReceived { get; set; }
        public string? CollegeLocation { get; set; }
        public string? CollegeSchoolType { get; set; }


        //Family///
        public string? FatherFirstName { get; set; }
        public string? FatherMiddleName { get; set; }
        public string? FatherLastName { get; set; }
        public string? FatherSuffix { get; set; }
        public string? FatherOccupation { get; set; }
        public string? FatherEducationalAttainment { get; set; }
        public string? FatherContactNumber { get; set; }

        public string? MotherFirstName { get; set; }
        public string? MotherMiddleName { get; set; }
        public string? MotherLastName { get; set; }
        public string? MotherContactNumber { get; set; }
        public string? MotherEducationalAttainment { get; set; }
        public string? MotherOccupation { get; set; }

        public string? FamilyBarangay { get; set; }
        public string? FamilyDistrict { get; set; }
        public string? FamilyMunicipality { get; set; }
        public string? FamilyStreet { get; set; }
        public string? FamilyZipCode { get; set; }

        public string? GuardianFirstName { get; set; }
        public string? GuardianMiddleName { get; set; }
        public string? GuardianLastName { get; set; }
        public string? GuardianSuffix { get; set; }
        public string? GuardianContactNumber { get; set; }
        public string? GuardianRelationship { get; set; }

        //Emergency///

        public string? PicoeFirstName { get; set; }
        public string? PicoeMiddleName { get; set; }
        public string? PicoeLastName { get; set; }
        public string? PicoeSuffix { get; set; }
        public string? PicoeContactNumber { get; set; }
        public string? PicoeHouseStreet { get; set; }
        public string? PicoeBrgy { get; set; }
        public string? PicoeDistrict { get; set; }
        public string? PicoeMunicipality { get; set; }
        public string? PicoeZipCode { get; set; }
        public string? PicoeRelationship { get; set; }



        //BasicInformation///
        public string? Lrn { get; set; }
        public string? ApplyingAs { get; set; }
        public string? Application_DATE { get; set; }


        //StudentScreening///
        public string FormatYearLevelTerm { get; set; }
        public string? YearLevel { get; set; }
            public string? Term { get; set; }
            public string? Gwa { get; set; }
        public string? Academic_FROM { get; set; }
        public string? Academic_TO { get; set; }


        //UserInformation///
        public string? StudentId { get; set; }


        //Student Reference///
        public string? ReferenceNumber { get; set; }

        //StudentEnlistment///
        public string? PhotoUrl { get; set; }



        
    }
}
