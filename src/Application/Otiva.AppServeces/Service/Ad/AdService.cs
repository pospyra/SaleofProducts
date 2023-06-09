﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Otiva.AppServeces.IRepository;
using Otiva.AppServeces.Service.User;
using Otiva.Contracts.AdDto;
using Otiva.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Otiva.AppServeces.Service.Ad
{
    public class AdService : IAdService
    {
        public readonly IAdRepository _adRepository;
        public readonly IUserService _userService;
        public readonly IMapper _mapper;
        public AdService(IAdRepository adRepository,  IMapper mapper, IUserService userService)
        {
            _adRepository = adRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<Guid> CreateAdAsync(CreateOrUpdateAdRequest createAd, CancellationToken cancellation, byte[] photo)
        {
            try
            {
                var newAd = _mapper.Map<Domain.Product>(createAd);

                if (photo != null)
                {
                    if (photo.Length > 5242880)
                        throw new Exception("Слишклм большой размер фото");
                    newAd.KodBase64 = Convert.ToBase64String(photo, 0, photo.Length);
                }

                await _adRepository.Add(newAd);

                return newAd.Id;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingUser = await _adRepository.FindByIdAsync(id);
            if (existingUser == null)
                throw new Exception("Объявления с таким идентификатором не сущесвует");

            await _adRepository.DeleteAsync(existingUser);
        }

        public async Task<InfoAdResponse> EditAdAsync(Guid Id, CreateOrUpdateAdRequest editAd)
        {
            var existingAd = await _adRepository.FindByIdAsync(Id);
            if (existingAd == null)
                throw new Exception("Объявления с таким идентификатором не сущесвует");

            existingAd.Name = editAd.Name;
            existingAd.Description = editAd.Description;
            existingAd.Price = editAd.Price;
            existingAd.KodBase64 = editAd.KodBase64;
            await _adRepository.EditAdAsync(existingAd);

            return _mapper.Map<InfoAdResponse>(editAd);

        }

        public async Task<IReadOnlyCollection<InfoAdResponse>> GetAllAsync(int take, int skip)
        {
            return await _adRepository.GetAll()
                 .Select(a => new InfoAdResponse
                 {
                     Id = a.Id,
                     Name = a.Name,
                     Description = a.Description,
                     SubcategoryId = a.SubcategoryId,
                     CreateTime = a.CreateTime,
                     Price = a.Price,
                     KodBase64 = a.KodBase64,
                 }).OrderBy(d=>d.CreateTime).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<IReadOnlyCollection<InfoAdResponse>> GetByFilterAsync(SearchFilterAd search)
        {
            var query = _adRepository.GetAll();

            //if (search == null)
            //    throw new Exception("Не задан фильтр");


            if (!string.IsNullOrEmpty(search.Name))
                query = query.Where(p => p.Name.ToLower().Contains(search.Name.ToLower()));

            if (search.SubcategoryId.HasValue)
                query = query.Where(c => c.SubcategoryId == search.SubcategoryId);

            if (search.PriceFrom != null)
                query = query.Where(c => c.Price >= search.PriceFrom);

            if (search.PriceTo != null)
                query = query.Where(c => c.Price <= search.PriceTo);

           // var res = _adRepository.FindWhere(query => query.Price <= search.PriceTo);
            return await query.Select(p => new InfoAdResponse
            {
                Id = p.Id,
                Name = p.Name,
                SubcategoryId = p.SubcategoryId,
                Description = p.Description,
                Price = p.Price,
                KodBase64 = p.KodBase64,
                CreateTime = p.CreateTime
            }).OrderBy(x => x.CreateTime).Skip(search.skip).Take(search.take).ToListAsync();
        }

        public async  Task<InfoAdResponse> GetByIdAsync(Guid id)
        {
            var exitAd = await _adRepository.FindByIdAsync(id);
            if (exitAd == null)
                throw new Exception("Объявления с таким идентификатором не сущесвует");
            return _mapper.Map<InfoAdResponse>(exitAd);
        }

    }
}
