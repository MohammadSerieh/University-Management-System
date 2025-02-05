﻿using System.Collections.Generic;
using Universities.Interfaces;
using Universities.models.dto;

namespace Universities.services
{
    public class minorService : IminorService
    {

        private readonly Ilookuprepositry ilookuprepositry;
        public minorService(Ilookuprepositry minorrepo)
        {
            this.ilookuprepositry = minorrepo;
        }


        public async Task<List<dropdown>> getUniversites()
        {
            List<dropdown> dropdownList = new List<dropdown>();
            var lst = await this.ilookuprepositry.retriveLookupByMajor(1);

            if (lst != null)
            {
                lst.ForEach(l => dropdownList.Add(new dropdown() { id = l.minorid, name = l.descs }));
            }

            return dropdownList;
        }
        public async Task<List<dropdown>> getMajores()
        {
            List<dropdown> dropdownList = new List<dropdown>();
            var lst = await this.ilookuprepositry.retriveLookupByMajor(3);

            if (lst != null)
            {
                lst.ForEach(l => dropdownList.Add(new dropdown() { id = l.minorid, name = l.descs }));
            }

            return dropdownList;
        }
        public async Task<int> addOrUpdate(minorDto dto)
        {
            var found = await this.ilookuprepositry.getbyid(dto.minorId);

            if (found != null)
            {
                found.descs = dto.name;
                await this.ilookuprepositry.updateLookup(found);
            }
            else
            {
                found = await this.ilookuprepositry.addNewLookup(dto.majorId, dto.name);
            }

            return found.minorid;
        }

        public async Task deletelookup(int minorid)
        {
            var found = await this.ilookuprepositry.getbyid(minorid);

            if (found != null)
            {

                await this.ilookuprepositry.deleteLookup(minorid);
            }
            throw new Exception("Not Found");


        }

    }
}
