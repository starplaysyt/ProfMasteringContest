using ProfMasteringProject.DTO;
using ProfMasteringProject.Entities;
using ProfMasteringProject.Repositories;

namespace ProfMasteringProject.Services;

public class UserService(UserEntityRepository userRepository, 
    IFileService fileService)
{
    public async Task<int> RegisterUser(UserRegistrationDTO userDto)
    {
        var filePath = await fileService.SaveFileAsync(userDto.AvatarPicture, "Images");

        var userEntity = new UserEntity
        {
            Username = userDto.Username,
            PasswordHash = userDto.Password,
            Phone = userDto.Phone,
            Email = userDto.Email,
            FirstName = userDto.FirstName,
            SecondName = userDto.LastName,
            AvatarPicturePath = filePath,
            Status = UserStatusEnum.Inactive,
            EmailVerified = false,
            PhoneVerified = false,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            LastLoginAt = default
        };

        await userRepository.AddUserEntity(userEntity);

        return 1;
    }
    
    public async Task<int> ValidateUserRegistration(UserRegistrationDTO user)
    {
        return 1;
    }
    
    public async Task<bool> CheckUser(string username, string passwordHash)
    {
        var user = await userRepository.GetUserEntityByUsername(username);

        if (user is null) return false;
        
        return user.PasswordHash == passwordHash;
    }
}