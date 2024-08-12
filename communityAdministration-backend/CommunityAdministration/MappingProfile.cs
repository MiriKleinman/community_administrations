using AutoMapper;
using BusinessLogic.Dto;
using DataAccess.DBModels;
using System.Collections.Generic;

namespace EmployeesLayersDI
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<ActivityDto, Activity>();
            CreateMap<Activity, ActivityDto>();
            CreateMap<LibraryDto, Library>();
            CreateMap<Library, LibraryDto>();
            CreateMap<PlayingCenterDto, PlayingCenter>();
            CreateMap<PlayingCenter, PlayingCenterDto>();
            CreateMap<CommunityAdministrationDto,DataAccess.DBModels.CommunityAdministration>();
            CreateMap<DataAccess.DBModels.CommunityAdministration, CommunityAdministrationDto>();
            CreateMap<CourseDto, Course>();
            CreateMap<Course, CourseDto>();
            CreateMap<MessageDto, Message>();
            CreateMap<Message, MessageDto>();
            CreateMap<UnitTimeOfLibraryDto, UnitTimeOfLibrary>();
            CreateMap<UnitTimeOfLibrary, UnitTimeOfLibraryDto>();
            CreateMap<UnitTimeOfPlayingCenterDto, UnitTimeOfPlayingCenter>();
            CreateMap<UnitTimeOfPlayingCenter, UnitTimeOfPlayingCenterDto>();
            CreateMap<ParticipantInActivityDto, ParticipantInActivity>();
            CreateMap<ParticipantInActivity, ParticipantInActivityDto>();
            CreateMap<CourseRegistered, CourseRegisteredDto>();
            CreateMap<CourseRegisteredDto, CourseRegistered>();

        }
    }

    
}
