using System.Data.Common;
using AutoMapper; //.Extensions.Microsoft.DependencyInjection;
using Repository;
using ServiceModels;
using Domain = DomainModels;

namespace Services;

public class ServiceProvider
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ServiceProvider(UnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UserInfo> GetUser(int id)
    {
        var user = await _unitOfWork.GetRepository<Domain.User>().GetById(id);
        if (user != null)
        {
            var address = await _unitOfWork
                .GetRepository<Domain.Address>()
                .GetByFilter(filter => filter.User.Id == user.Id);
            return new UserInfo
            {
                User = _mapper.Map<User>(user),
                Addresses = _mapper.Map<List<Address>>(address)
            };
        }
        return new UserInfo { User = _mapper.Map<User>(user), Addresses = new List<Address>() };
    }

    public async Task<bool> DeleteUser(int id)
    {
        var userInfo = await GetUser(id);
        foreach (var item in userInfo.Addresses)
        {
            await _unitOfWork.GetRepository<Domain.Address>().Delete(item.Id);
        }
        await _unitOfWork.GetRepository<Domain.User>().Delete(id);
        await _unitOfWork.Commit();
        return true;
    }

    public async Task<List<User>> GetUsers()
    {
        var user = await _unitOfWork.GetRepository<Domain.User>().GetAll();
        return _mapper.Map<List<User>>(user);
    }

    public async Task<bool> CreateUser(UserInfo userInfo)
    {
        var _user = _mapper.Map<Domain.User>(userInfo.User);
        var id = 0;
        if (_user.Id > 0)
            await _unitOfWork.GetRepository<Domain.User>().Update(_user.Id, _user);
        else
            id = await _unitOfWork.GetRepository<Domain.User>().Create(_user);
        foreach (var address in userInfo.Addresses)
        {
            var _address = _mapper.Map<Domain.Address>(address);
            _address.UserId = _user.Id;
            if (_address.Id > 0)
                await _unitOfWork.GetRepository<Domain.Address>().Update(_address.Id, _address);
            else
                id = await _unitOfWork.GetRepository<Domain.Address>().Create(_address);
            // await _unitOfWork.GetRepository<Domain.Address>().Create(_address);
        }
        await _unitOfWork.Commit();
        return true;
    }
}
