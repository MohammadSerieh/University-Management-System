using Microsoft.EntityFrameworkCore;
using Universities.Entities;
using Universities.Interfaces;
using Universities.models;
using Universities.models.dto;

namespace Universities.Repositry
{
    public class lookuprepositry : Ilookuprepositry
    {
        private universityDBContext dBContext;
        public lookuprepositry(universityDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<List<CommonZakat_MinorLookUpTable>> retriveLookupByMajor(int majorID)
        {
            return await this.dBContext.Set<CommonZakat_MinorLookUpTable>()
                .Where(x => x.majorid == majorID)
                .ToListAsync();
        }

        public async Task<CommonZakat_MinorLookUpTable?> getbyid(int minorid)
        {
            CommonZakat_MinorLookUpTable? obj = await this.dBContext.Set<CommonZakat_MinorLookUpTable>().FindAsync(minorid);

            return obj;
        }

        public async Task<CommonZakat_MinorLookUpTable> addNewLookup(int majorID, string descs)
        {
            CommonZakat_MinorLookUpTable obj = new CommonZakat_MinorLookUpTable();
            obj.majorid = majorID;
            obj.descs = descs;
            var result = await this.dBContext.Set<CommonZakat_MinorLookUpTable>().AddAsync(obj);
            await SaveChanges();
            return obj;
        }
        public async Task<CommonZakat_MinorLookUpTable> updateLookup(int minorid, string descs)
        {
            CommonZakat_MinorLookUpTable? obj = await getbyid(minorid);
            if (obj == null)
                throw new Exception("The Id Is Not Valid");
 
            obj.descs = descs;
            this.dBContext.Entry(obj).State = EntityState.Modified;
            await SaveChanges();
            return obj;
        }

        public async Task<CommonZakat_MinorLookUpTable> updateLookup(CommonZakat_MinorLookUpTable obj)
        {

            this.dBContext.Entry(obj).State = EntityState.Modified;
            await SaveChanges();
            return obj;
        }

        public async Task deleteLookup(int minorid)
        {
            CommonZakat_MinorLookUpTable? obj = await getbyid(minorid);
            if (obj == null)
                throw new Exception("The Id Is Not Valid");


            dBContext.Set<CommonZakat_MinorLookUpTable>().Remove(obj);
            await SaveChanges();
        }

        public async Task<List<UniversityApplicationSummaryDto>> GetUniversityDataAsync()
        {
            var query = await (from application in dBContext.UniversityApplicationReserve
                               join university in dBContext.CommonZakat_MinorLookUpTable
                                   on application.UniID equals university.minorid
                                   into uniGroup
                               from university in uniGroup.DefaultIfEmpty()
                               where university.majorid == 5

                               join major in dBContext.CommonZakat_MinorLookUpTable
                                   on application.UniMajor equals major.minorid
                                   into majorGroup
                               from major in majorGroup.DefaultIfEmpty()
                               where major.majorid == 2

                               group application by new { UniversityName = university.descs, MajorName = major.descs } into grouped
                               select new UniversityApplicationSummaryDto
                               {
                                   University = grouped.Key.UniversityName,
                                   Major = grouped.Key.MajorName,
                                   HighestCommulativeRate = grouped.Max(a => a.CommulativeRate),
                                   LowestCommulativeRate = grouped.Min(a => a.CommulativeRate)
                               })
                               .OrderByDescending(a => a.HighestCommulativeRate)
                               .ToListAsync();

            return query;
        }

        private async Task SaveChanges()
        {
            await this.dBContext.SaveChangesAsync();
        }
    }
}
