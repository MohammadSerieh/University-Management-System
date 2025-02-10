using Microsoft.EntityFrameworkCore;
using Universities.Entities;
using Universities.Interfaces;
using Universities.models;

namespace Universities.Repositry
{
    public class ApplicationsRepository : IApplicationsRepository
    {
        private universityDBContext dBContext;
        public ApplicationsRepository(universityDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<List<UniversityApplicationReserve>> getApplications()
        {
            return await this.dBContext.Set<UniversityApplicationReserve>().ToListAsync();
        }

        public async Task<UniversityApplicationReserve?> getbyAppno(int Appno)
        {
            UniversityApplicationReserve? obj = await this.dBContext.Set<UniversityApplicationReserve>().FindAsync(Appno);

            return obj;
        }

        public async Task AddOrUpdateApplication(UniversityApplicationReserve entity)
        {
            if (entity.Appno == 0) 
            {
                entity.Appno = default; 
                await this.dBContext.Set<UniversityApplicationReserve>().AddAsync(entity);
            }
            else
            {
                var existingApplication = await this.dBContext.Set<UniversityApplicationReserve>()
                    .FirstOrDefaultAsync(a => a.Appno == entity.Appno);

                if (existingApplication != null)
                {
                    
                    existingApplication.StudentName = entity.StudentName;
                    existingApplication.StudentNameEn = entity.StudentNameEn;
                    existingApplication.ApplicationID = entity.ApplicationID;
                    existingApplication.UniID = entity.UniID;
                    existingApplication.UniNumber = entity.UniNumber;
                    existingApplication.UniCollege = entity.UniCollege;
                    existingApplication.UniMajor = entity.UniMajor;
                    existingApplication.SemesterRate = entity.SemesterRate;
                    existingApplication.CommulativeRate = entity.CommulativeRate;
                    existingApplication.HighSchoolGrade = entity.HighSchoolGrade;
                    existingApplication.HighSchoolGraduate = entity.HighSchoolGraduate;
                    existingApplication.UniGrantID = entity.UniGrantID;
                    existingApplication.UniGrantDate = entity.UniGrantDate;
                    existingApplication.UniGrantRateLimit = entity.UniGrantRateLimit;
                    existingApplication.nationalityCategory = entity.nationalityCategory;

                    this.dBContext.Set<UniversityApplicationReserve>().Update(existingApplication);
                }
                else
                {
                    await this.dBContext.Set<UniversityApplicationReserve>().AddAsync(entity);
                }
            }

            await this.dBContext.SaveChangesAsync();
        }
        public async Task<UniversityApplicationReserve?> getByAppno(int appno)
        {
            return await this.dBContext.Set<UniversityApplicationReserve>()
                .FirstOrDefaultAsync(a => a.Appno == appno);
        }

        
        public async Task<bool> deleteApplication(int appno)
        {
            var application = await getByAppno(appno); 

            if (application != null)
            {
                this.dBContext.Set<UniversityApplicationReserve>().Remove(application);
                await this.dBContext.SaveChangesAsync();
                return true; 
            }

            return false; 
        }


    }
}
