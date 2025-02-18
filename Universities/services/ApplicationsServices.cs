using Universities.Entities;
using Universities.Interfaces;
using Universities.models.dto;
using Universities.Repositry;

namespace Universities.services
{
    public class ApplicationsServices : IApplicationsServices
    {
        private readonly IApplicationsRepository iapplicationrepositry;
        private readonly Ilookuprepositry ilookuprepositry; // Added Lookup Repository

        public ApplicationsServices(IApplicationsRepository apprepo, Ilookuprepositry lookuprepo)
        {
            this.iapplicationrepositry = apprepo;
            this.ilookuprepositry = lookuprepo; // Injected Lookup Repository
        }

        public async Task<List<ApplicationsDto>> getApplications()
        {
            var applications = await iapplicationrepositry.getApplications();

            return applications.Select(a => new ApplicationsDto
            {
                ApplicationNumber = a.Appno,
                ApplicationType = a.ApplicationCategory,
                FullName = a.StudentName,
                FullNameEn = a.StudentNameEn,
                AppID = a.ApplicationID,
                UniversityId = a.UniID,
                UniversityNumber = a.UniNumber,
                CollegeId = a.UniCollege,
                MajorId = a.UniMajor,
                SemesterGPA = a.SemesterRate,
                OverallGPA = a.CommulativeRate,
                HighSchoolScore = a.HighSchoolGrade,
                HighSchoolGraduationDate = a.HighSchoolGraduate,
                UniversityGrantID = a.UniGrantID,
                UniversityGrantDate = a.UniGrantDate,
                GrantRateLimit = a.UniGrantRateLimit,
                NationalityCategory = a.nationalityCategory
            }).ToList();
        }

        public async Task AddOrUpdateApplication(ApplicationsDto dto)
        {
            var application = new UniversityApplicationReserve
            {
                Appno = dto.ApplicationNumber == 0 ? default : dto.ApplicationNumber, 
                ApplicationCategory = dto.ApplicationType,
                StudentName = dto.FullName,
                StudentNameEn = dto.FullNameEn,
                ApplicationID = dto.AppID,
                UniID = dto.UniversityId,
                UniNumber = dto.UniversityNumber,
                UniCollege = dto.CollegeId,
                UniMajor = dto.MajorId,
                SemesterRate = dto.SemesterGPA,
                CommulativeRate = dto.OverallGPA,
                HighSchoolGrade = dto.HighSchoolScore,
                HighSchoolGraduate = dto.HighSchoolGraduationDate,
                UniGrantID = dto.UniversityGrantID,
                UniGrantDate = dto.UniversityGrantDate,
                UniGrantRateLimit = dto.GrantRateLimit,
                nationalityCategory = dto.NationalityCategory
            };

            await this.iapplicationrepositry.AddOrUpdateApplication(application);
        }

        public async Task<bool> deleteApplication(int appno)
        {
            return await iapplicationrepositry.deleteApplication(appno);
        }

        public async Task<List<UniversityApplicationSummaryDto>> GetUniversityDataAsync()
        {
            return await this.ilookuprepositry.GetUniversityDataAsync();
        }


    }
}
