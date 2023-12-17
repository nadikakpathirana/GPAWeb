using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Microsoft.EntityFrameworkCore;
using AutoMapper;

using GPAWeb.DTO.DTOs;
using GPAWeb.DAL.Infrastructure.Interfaces;
using GPAWeb.DAL.DataContext;
using GPAWeb.DAL.Models;

using GPAWeb.BLL.Utilities.CustomExceptions;
using GPAWeb.BLL.Services.IServices;



namespace GPAWeb.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork<GPADbContext> _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork<GPADbContext> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDTO> AddUserAsync(UserToAddDTO userToAddDTO)
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var addedUser = await userRepo.AddAsync(_mapper.Map<User>(userToAddDTO));
            _unitOfWork.Commit();
            return _mapper.Map<UserDTO>(addedUser);
        }

        public async Task<UserDTO> GetUserAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var userToReturn = await userRepo.GetAsync(x => x.Id == userId, cancellationToken);

            if (userToReturn == null) {
                throw new NotFoundException();
            }

            return _mapper.Map<UserDTO>(userToReturn);
        }

        public async Task<List<UserDTO>> GetUsersAsync(CancellationToken cancellationToken = default)
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var returnUserList = await userRepo.GetListAsync();

            return _mapper.Map<List<UserDTO>>(returnUserList);
        }

        public Task<bool> UpdateUser(UserToUpdateDTO userToUpdateDTO)
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            if (!userRepo.IsExists(_mapper.Map<User>(userToUpdateDTO)))
            {
                throw new NotFoundException();
            }
            var status = userRepo.Update(_mapper.Map<User>(userToUpdateDTO));
            _unitOfWork.Commit();

            return Task.FromResult(status == EntityState.Modified);

            
        }

        public async Task<bool> DeleteUser(Guid userId)
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var user = await userRepo.GetAsync(x => x.Id == userId);

            if (user == null)
            {
                throw new NotFoundException();
            }

            var status = userRepo.Delete(user);
            _unitOfWork.Commit();

            return await Task.FromResult(status == EntityState.Deleted);
        }
    }
}
