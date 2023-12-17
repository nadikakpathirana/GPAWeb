using GPAWeb.DTO.DTOs;

namespace GPAWeb.BLL.Services.IServices
{
    public interface IUserService
    {
        Task<UserDTO> AddUserAsync(UserToAddDTO userToAddDTO);
        Task<List<UserDTO>> GetUsersAsync(CancellationToken cancellationToken = default);
        Task<UserDTO> GetUserAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<bool> UpdateUser(UserToUpdateDTO userToUpdateDTO);
        Task<bool> DeleteUser(Guid userId);
    }
}
