using Microsoft.AspNetCore.Identity;
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

        userEntity.PasswordHash = userDto.Password.GetHashCode().ToString();

        await userRepository.AddUserEntity(userEntity);

        return 1;
    }
    
    public async Task<int> ValidateUserRegistration(UserRegistrationDTO user)
    {
        return 1;
    }

    public async Task<UserEntity?> LoginUser(UserLoginDTO userDto)
    {
        var user = await userRepository.GetUserEntityByUsername(userDto.Username);
        
        if (user is null) return null;
        
        var passwordHash = userDto.Password.GetHashCode().ToString();
        
        Console.WriteLine($"DTO PASS: {user.PasswordHash} - INTERNAL: {passwordHash}");
        
        return passwordHash != user.PasswordHash ? null : user;
    }
    
    public async Task<bool> CheckUser(string username, string passwordHash)
    {
        var user = await userRepository.GetUserEntityByUsername(username);

        if (user is null) return false;
        
        return user.PasswordHash == passwordHash;
    }

    public async Task UpdateEntityLoginTime(UserEntity userEntity, DateTime time)
    {
        await userRepository.UpdateUserLoginTime(userEntity, time);
    }
}