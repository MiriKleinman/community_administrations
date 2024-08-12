using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DBModels;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;


namespace DataAccess.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        CommunityAdministrationContext _dbContext;
        ILogger<Message> logger;
        IUtilsRepository utilsRepository;
        public MessageRepository(CommunityAdministrationContext _dbContext, ILogger<Message> logger, IUtilsRepository utilsRepository)
        {
            this._dbContext = _dbContext;
            this.logger = logger;
            this.utilsRepository = utilsRepository;
        }

        public async Task<int> AddMessage(Message message, string userId)
        {
            int res = await checkCorrectMessage(message, userId);
            if (res != 1)
                //return res;
                //await _dbContext.Messages.AddAsync(message);
                //await _dbContext.SaveChangesAsync();
                //return 1;
                using (SmtpClient client = new SmtpClient()
                {
                    Host = "smtp.office365.com",
                    Port = 587,
                    UseDefaultCredentials = false, // This require to be before setting Credentials property
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential("36214128290@mby.co.il", "Student@264"), // you must give a full email address for authentication 
                    TargetName = "STARTTLS/smtp.office365.com", // Set to avoid MustIssueStartTlsFirst exception
                    EnableSsl = true // Set to avoid secure connection exception
                })
                {
                    MailMessage messages = new MailMessage()
                    {
                        From = new MailAddress("36214128290@mby.co.il"), // sender must be a full email address
                        Subject = "הודעה",
                        IsBodyHtml = true,
                        Body = message.MessageContent,
                        BodyEncoding = System.Text.Encoding.UTF8,
                        SubjectEncoding = System.Text.Encoding.UTF8,

                    };

                    messages.To.Add(message.MessageContent);

                    try
                    {
                        client.Send(messages);
                        _dbContext.Messages.AddAsync(message);
                        await _dbContext.SaveChangesAsync();
                        return 1;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return 3;
                    }
                }
            return 2;

        }

        public async Task<List<Message>> GetMessageByAdresseeId(int? courseId, int? activityId, int? playingCenterId, int? libraryId, string? communityAdministrationId)
        {
            return await _dbContext.Messages.Where(message => (message.CourseId == courseId || courseId == 0) &&
                                                              (message.ActivityId == activityId || activityId == 0) &&
                                                              (message.PlayingCenterId == playingCenterId || playingCenterId == 0) &&
                                                              (message.LibraryId == libraryId || libraryId == 0)).ToListAsync();
        }
        public async Task<List<Message>> GetMessagesByUserId(string userId)
        {
            User user = await _dbContext.Users.FindAsync(userId);
            List<Message> userMessages = new List<Message>();
            List<CourseRegistered> courses = await _dbContext.CourseRegistereds.Where(c => c.UserId == userId).ToListAsync();
            List<ParticipantInActivity> activities = await _dbContext.ParticipantInActivities.Where(p => p.UserId == userId).ToListAsync();
            Library library = await _dbContext.Libraries.Where(l => l.CommunityAdministrationId == user.CommunityAdministrationId).FirstOrDefaultAsync();
            PlayingCenter playingCenter = await _dbContext.PlayingCenters.Where(p => p.CommunityAdministrationId == user.CommunityAdministrationId).FirstOrDefaultAsync();
            CommunityAdministration communityAdministration = await _dbContext.CommunityAdministrations.Where(c => c.CommunityAdministrationId == user.CommunityAdministrationId).FirstOrDefaultAsync();
            foreach (var m in await _dbContext.Messages.ToListAsync())
            {
                foreach (var c in courses)
                {
                    if (c.CourseId == m.CourseId || m.LibraryId == library.LibraryId || m.PlayingCenterId == playingCenter.PlayingCenterId || m.CommunityAdministrationId == communityAdministration.CommunityAdministrationId)
                        userMessages.Add(m);
                }
                foreach (var a in activities)
                {
                    if (a.ActivityId == m.ActivityId)
                        userMessages.Add(m);
                }
            }
            return userMessages;
        }
        //public async Task SendWatsApp(string watsapp)
        //{
        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://graph.facebook.com/v14.0/[RFCTC0BECGL]/messages"))
        //        {

        //            request.Content = new StringContent("{ \"messaging_product\": \"whatsapp\", \"to\": \"[0524413668]\", \"type\": \"template\", \"template\": { \"name\": \"hello_world\", \"language\": { \"code\": \"en_US\" } } }");
        //            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

        //            var response = await httpClient.SendAsync(request);
        //        }

        public async Task<int> UpdateMessage(int messageId, Message message, string userId)
        {
            int res = await checkCorrectMessage(message, userId);
            if (res != 1)
                return res;
            Message prevMessage = await _dbContext.Messages.FindAsync(messageId);
            if (prevMessage == null)
                return 4;
            prevMessage.EndTimeOfMessage = message.EndTimeOfMessage;
            prevMessage.MessageContent = message.MessageContent;
            _dbContext.Messages.Update(prevMessage);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
        public async Task<int> checkCorrectMessage(Message message, string userId)
        {
            Course course = await _dbContext.Courses.FindAsync(message.CourseId);
            Library library = await _dbContext.Libraries.FindAsync(message.LibraryId);
            CommunityAdministration communityAdministration = await _dbContext.CommunityAdministrations.FindAsync(message.CommunityAdministrationId);
            PlayingCenter playingCenter = await _dbContext.PlayingCenters.FindAsync(message.PlayingCenterId);
            Activity activity = await _dbContext.Activities.FindAsync(message.ActivityId);

            if ((message.CourseId != 0 && course == null) || (message.LibraryId == 1 && library == null) || (message.CommunityAdministrationId == "1" && communityAdministration == null)
                || (message.PlayingCenterId == 1 && playingCenter == null) || (message.ActivityId == 1 && activity == null))
                return 2;
            if ((message.CourseId != 0 && !await utilsRepository.CheckPermissionOfManager(userId, course.CommunityAdministrationId)) ||
               (message.LibraryId != 0 && !await utilsRepository.CheckPermissionOfManager(userId, library.CommunityAdministrationId)) ||
               (message.CommunityAdministrationId != "" && !await utilsRepository.CheckPermissionOfManager(userId, communityAdministration.CommunityAdministrationId)) ||
               (message.PlayingCenterId != 0 && !await utilsRepository.CheckPermissionOfManager(userId, playingCenter.CommunityAdministrationId)) ||
               (message.ActivityId != 0 && !await utilsRepository.CheckPermissionOfManager(userId, activity.CommunityAdministrationId)))
                return 3;
            return 1;
        }

    }
}



//using (SmtpClient client = new SmtpClient()
//{
//    Host = "smtp.office365.com",
//    Port = 587,
//    UseDefaultCredentials = false, // This require to be before setting Credentials property
//    DeliveryMethod = SmtpDeliveryMethod.Network,
//    Credentials = new NetworkCredential("36213869407@mby.co.il", "Student@264"), // you must give a full email address for authentication 
//    TargetName = "STARTTLS/smtp.office365.com", // Set to avoid MustIssueStartTlsFirst exception
//    EnableSsl = true // Set to avoid secure connection exception
//})
//{

//    MailMessage messages = new MailMessage()
//    {
//        From = new MailAddress("36213869407@mby.co.il"), // sender must be a full email address
//        Subject = "הרשמה",
//        IsBodyHtml = true,
//        Body = "http://localhost:3000/AddNewStudent/",
//        BodyEncoding = System.Text.Encoding.UTF8,
//        SubjectEncoding = System.Text.Encoding.UTF8,

//    };

//    messages.To.Add(message.MessageContent);

//    try
//    {
//        client.Send(messages);
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//    }
//    }